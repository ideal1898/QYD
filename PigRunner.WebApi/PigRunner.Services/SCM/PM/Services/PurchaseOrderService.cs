using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using PigRunner.DTO.CommonView;
using PigRunner.DTO.SCM.PM;
using PigRunner.Entitys.Basic;
using PigRunner.Entitys.Basic.Gop;
using PigRunner.Entitys.SCM.PM;
using PigRunner.Public;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Context;
using PigRunner.Repository.Basic;
using PigRunner.Repository.Basic.Gop;
using PigRunner.Repository.MM.PM;
using PigRunner.Repository.SCM.PM;
using PigRunner.Services.SCM.PM.IServices;
using SqlSugar;
using SqlSugar.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.SCM.PM.Services
{
    /// <summary>
    /// 采购订单服务
    /// </summary>
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private PurchaseOrderRepository orderRepository;
        private WebSession session;
        private IMapper mapper;
        /// <summary>
        /// 服务注册
        /// </summary>
        public PurchaseOrderService(PurchaseOrderRepository _orderRepository, WebSession _session, IMapper _mapper)
        {
            this.orderRepository = _orderRepository;
            this.session = _session;
            this.mapper = _mapper;
        }
        #region 业务操作
        public ResponseBusBody Save(PurchaseOrderView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                PurchaseOrder purchaseOrder = null;
                long SysVersion = 0;
                if (view.id > 0)
                {
                    purchaseOrder = orderRepository.AsQueryable().Includes(item => item.Lines).Where(w => w.ID == view.id).First();
                    SysVersion = purchaseOrder.SysVersion;
                    if (SysVersion != view.SysVersion)
                        throw new Exception($"采购订单【{purchaseOrder.DocNo}】数据已被修改");
                }

                purchaseOrder = mapper.Map<PurchaseOrder>(view);
                if (view.id > 0)
                    purchaseOrder.SysVersion = SysVersion + 1;

                if (purchaseOrder.Supplier == 0 && !string.IsNullOrEmpty(view.SupplierCode))
                {
                    var Supplier = orderRepository.Context.Queryable<Supplier>().Single(item => item.Code == view.SupplierCode);
                    if (Supplier != null)
                        purchaseOrder.Supplier = Supplier.ID;
                }

                foreach (var item in purchaseOrder.Lines)
                {
                    if (item.PurchaseOrder == 0)
                        item.PurchaseOrder = purchaseOrder.ID;
                    if (view.id > 0)
                        item.SysVersion += 1;
                    if (item.ItemId == 0)
                    {
                        var Item = orderRepository.Context.Queryable<Item>().Single(it => it.Code == item.ItemCode);
                        if (Item != null)
                            item.ItemId = Item.ID;
                    }
                }
                bool flag = false;
                if (view.id == 0)
                    flag = orderRepository.Context.InsertNav(purchaseOrder).Include(item => item.Lines,
                            new InsertNavOptions() { OneToManyIfExistsNoInsert = true }).ExecuteCommand();
                else
                    flag = orderRepository.Context.UpdateNav(purchaseOrder).Include(item => item.Lines, new UpdateNavOptions() { OneToManyInsertOrUpdate = true }).ExecuteCommand();

                //重新查询单据
                purchaseOrder = orderRepository.Context.Queryable<PurchaseOrder>()
                    .Includes(item => item.Supp)
                    .Includes(item => item.Symbols)
                    .Includes(item => item.Lines, line => line.Item).Where(item => item.ID == purchaseOrder.ID).First();
                //将实体转化成View
                var vo = mapper.Map<PurchaseOrderView>(purchaseOrder);
                stopwatch.Stop();
                response.code = flag ? 200 : 401;
                response.data = JObject.FromObject(vo);
                response.msg = $"采购订单保存成功，耗时：{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ResponseBusBody Delete(List<long> ids)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                orderRepository.BeginTran();
                foreach (long id in ids)
                    orderRepository.Context.DeleteNav<PurchaseOrder>(item => item.ID == id).Include(item => item.Lines).ExecuteCommand();

                orderRepository.CommitTran();
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"成功删除：{ids.Count}条记录,执行耗时：{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
                orderRepository.RollbackTran();
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;

        }

        public ResponseBusBody Submit(PurchaseOrderView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var purchaseOrder = orderRepository.GetFirst(item => item.ID == view.id);
                if (purchaseOrder == null)
                    throw new Exception($"采购订单【{view.DocNo}】为空，不允许提交");

                if (view.SysVersion != purchaseOrder.SysVersion)
                    throw new Exception($"采购订单【{view.DocNo}】数据已被修改，不允许提交");

                orderRepository.BeginTran();
                orderRepository.Context.Updateable<PurchaseOrder>().SetColumns(it => new PurchaseOrder() { SysVersion = it.SysVersion + 1, Status = 1 }).Where(w => w.ID == view.id).ExecuteCommand();
                orderRepository.CommitTran();
                var vo = GetPurcheseOrderViewById(view.id);
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"采购订单提交完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
                response.data = JObject.FromObject(vo);
            }
            catch (Exception ex)
            {
                orderRepository.RollbackTran();
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        public ResponseBusBody Approve(PurchaseOrderView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var purchaseOrder = orderRepository.GetFirst(item => item.ID == view.id);
                if (purchaseOrder == null)
                    throw new Exception($"采购订单【{view.DocNo}】为空，不允许审核");

                if (view.SysVersion != purchaseOrder.SysVersion)
                    throw new Exception($"采购订单【{view.DocNo}】数据已被修改，不允许审核");

                orderRepository.BeginTran();
                orderRepository.Context.Updateable<PurchaseOrder>().SetColumns(it => new PurchaseOrder() { SysVersion = it.SysVersion + 1, Status = 2 }).Where(w => w.ID == view.id).ExecuteCommand();
                orderRepository.CommitTran();
                var vo = GetPurcheseOrderViewById(view.id);
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"采购订单审核完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
                response.data = JObject.FromObject(vo);
            }
            catch (Exception ex)
            {
                orderRepository.RollbackTran();
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        public ResponseBusBody UnApprove(PurchaseOrderView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var purchaseOrder = orderRepository.GetFirst(item => item.ID == view.id);
                if (purchaseOrder == null)
                    throw new Exception($"采购订单【{view.DocNo}】为空，不允许弃审");

                if (view.SysVersion != purchaseOrder.SysVersion)
                    throw new Exception($"采购订单【{view.DocNo}】数据已被修改，不允许弃审");

                orderRepository.BeginTran();
                orderRepository.Context.Updateable<PurchaseOrder>().SetColumns(it => new PurchaseOrder() { SysVersion = it.SysVersion + 1, Status = 0 }).Where(w => w.ID == view.id).ExecuteCommand();
                orderRepository.CommitTran();
                var vo = GetPurcheseOrderViewById(view.id);
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"采购订单弃审完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
                response.data = JObject.FromObject(vo);
            }
            catch (Exception ex)
            {
                orderRepository.RollbackTran();
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        public ResponseBody BatchSubmit(List<DoActionView> views)
        {
            ResponseBody response = new ResponseBody();
            try
            {
                var ids = views.Select(item => item.id);
                Stopwatch stopwatch = Stopwatch.StartNew();
                orderRepository.BeginTran();
                orderRepository.Context.Updateable<PurchaseOrder>().SetColumns(it => new PurchaseOrder() { SysVersion = it.SysVersion + 1, Status = 1 }).Where(w => ids.Contains(w.ID)).ExecuteCommand();
                orderRepository.CommitTran();
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"采购订单提交完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
                orderRepository.RollbackTran();
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        public ResponseBody BatchApprove(List<DoActionView> views)
        {
            ResponseBody response = new ResponseBody();
            try
            {
                var ids = views.Select(item => item.id);
                Stopwatch stopwatch = Stopwatch.StartNew();
                orderRepository.BeginTran();
                orderRepository.Context.Updateable<PurchaseOrder>().SetColumns(it => new PurchaseOrder() { SysVersion = it.SysVersion + 1, Status = 2 }).Where(w => ids.Contains(w.ID)).ExecuteCommand();
                orderRepository.CommitTran();
                stopwatch.Stop();
                orderRepository.CommitTran();
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"采购订单审核完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
                orderRepository.RollbackTran();
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        public ResponseBody BatchUnApprove(List<DoActionView> views)
        {
            ResponseBody response = new ResponseBody();
            try
            {
                var ids = views.Select(item => item.id);
                Stopwatch stopwatch = Stopwatch.StartNew();
                orderRepository.BeginTran();
                orderRepository.Context.Updateable<PurchaseOrder>().SetColumns(it => new PurchaseOrder() { SysVersion = it.SysVersion + 1, Status = 0 }).Where(w => ids.Contains(w.ID)).ExecuteCommand();
                orderRepository.CommitTran();
                stopwatch.Stop();
                orderRepository.CommitTran();
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"采购订单弃审完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
                orderRepository.RollbackTran();
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        #endregion

        #region 查询
        public ResponseBody QueryAllByPage(PageView view)
        {
            //全局获取变量,每次登录会根据用户变化获取用户与组织信息          
            ResponseBody response = new ResponseBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                int total = 0;
                var purchaseOrders = orderRepository.Context.Queryable<PurchaseOrder>()
                    .Includes(item => item.Symbols)
                    .Includes(item => item.Supp)
                    .ToOffsetPage(view.PageNumber, view.PageSize, ref total);
                var views = mapper.Map<List<PurchaseOrderView>>(purchaseOrders);
                stopwatch.Stop();
                response.code = 200;
                response.total = total;
                response.msg = $"采购订单查询完成，共计{total}条记录，耗时：{total}";
                response.data = JArray.FromObject(views);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }
        /// <summary>
        /// 根据ID查询采购订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseBusBody QueryDocById(long id)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                var purchaseOrder = orderRepository.Context.Queryable<PurchaseOrder>()
                    .Includes(item => item.Symbols)
                    .Includes(item => item.Supp)
                    .Includes(item => item.Lines, line => line.Item).Where(item => item.ID == id);
                var view = mapper.Map<PurchaseOrderView>(purchaseOrder.First());
                response.data = JObject.FromObject(view);
                response.code = 200;
                response.msg = $"采购订单查询耗时:{stopwatch.ElapsedMilliseconds} 毫秒";
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// 根据单号查询采购订单
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        public ResponseBusBody QueryDocByDocNo(string DocNo)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                var purchaseOrder = orderRepository.Context.Queryable<PurchaseOrder>()
                    .Includes(item => item.Symbols)
                    .Includes(item => item.Supp)
                    .Includes(item => item.Lines, line => line.Item).Where(item => item.DocNo == DocNo);
                var view = mapper.Map<PurchaseOrderView>(purchaseOrder.First());
                response.data = JObject.FromObject(view);
                response.code = 200;
                response.msg = $"采购订单查询耗时:{stopwatch.ElapsedMilliseconds} 毫秒";
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        private PurchaseOrderView GetPurcheseOrderViewById(long id)
        {
            var purchaseOrder = orderRepository.Context.Queryable<PurchaseOrder>()
                       .Includes(item => item.Symbols)
                       .Includes(item => item.Supp)
                       .Includes(item => item.Lines, line => line.Item).Where(item => item.ID == id);
            return mapper.Map<PurchaseOrderView>(purchaseOrder.First());
        }
        /// <summary>
        /// 查询采购订单明细
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ResponseBody queryLineByPage(PageView view)
        {
            ResponseBody response = new ResponseBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                int total = 0;
                var docs = orderRepository.Context.Queryable<POLine>()
                     .IncludesAllFirstLayer()
                    .OrderBy(item => item.CreatedTime, OrderByType.Desc)
                    .ToOffsetPage(view.PageNumber, view.PageSize, ref total);
                var views = mapper.Map<List<POLineView>>(docs);
                stopwatch.Stop();
                response.code = 200;
                response.total = total;
                response.msg = $"采购订单明细查询完成，共计{total}条记录，耗时：{total}";
                response.data = JArray.FromObject(views);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        public ResponseBody PRToPO(List<PrToPoView> views)
        {
            ResponseBody response = new ResponseBody();

            try
            {
                var PrIds= views.Where(w=>w.id>0)?.Select(item => item.id);
                var PrDocNos = views.Where(w => !string.IsNullOrEmpty(w.DocNo)).Select(item => item.DocNo);
                List<Requisition> requisitions = new List<Requisition>();
                //根据ID查询
                if (PrIds != null && PrIds.Any()) {
                  List<Requisition> list= orderRepository.Context.Queryable<Requisition>().IncludesAllFirstLayer().Where(w => PrIds.Contains(w.ID)).ToList();
                
                }
                //根据单据号查询


                orderRepository.BeginTran();


                orderRepository.CommitTran();

                response.code = 200;
                response.msg = "请购转采购业务处理完成";
            }
            catch (Exception ex)
            {
                response.code = 200;
                response.msg = ex.Message;
            }
            return response;
        }

        #endregion
    }
}

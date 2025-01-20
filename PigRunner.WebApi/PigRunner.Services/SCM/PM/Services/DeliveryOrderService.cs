using AutoMapper;
using Newtonsoft.Json.Linq;
using PigRunner.DTO.CommonView;
using PigRunner.DTO.SCM.PM;
using PigRunner.Entitys.SCM.PM;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.SCM.PM;
using PigRunner.Services.SCM.PM.IServices;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PigRunner.Entitys.Basic.Gop;
using PigRunner.Entitys.Basic;

namespace PigRunner.Services.SCM.PM.Services
{
    /// <summary>
    /// 采购到货单服务
    /// </summary>
    public class DeliveryOrderService : IDeliveryOrderService
    {
        private DeliveryOrderRepository repository;
        private WebSession session;
        private IMapper mapper;
        /// <summary>
        /// 服务注册
        /// </summary>
        public DeliveryOrderService(DeliveryOrderRepository _repository, WebSession _session, IMapper _mapper)
        {
            this.repository = _repository;
            this.session = _session;
            this.mapper = _mapper;
        }

        #region 业务操作
        public ResponseBusBody Save(DeliveryOrderView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                DeliveryOrder doc = null;
                long SysVersion = 0;
                if (view.id > 0)
                {
                    doc = repository.AsQueryable().Includes(item => item.Lines).Where(w => w.ID == view.id).First();
                    SysVersion = doc.SysVersion;
                    if (SysVersion != view.SysVersion)
                        throw new Exception($"采购到货单【{doc.DocNo}】数据已被修改");
                }

                doc = mapper.Map<DeliveryOrder>(view);
                if (view.id > 0)
                {
                    doc.SysVersion = SysVersion + 1;
                    doc.ModifiedBy = session.UserName;
                }
                else
                {
                    if (string.IsNullOrEmpty(doc.CreatedBy))
                        doc.CreatedBy = session.UserName;
                    if (doc.CreatedTime == DateTime.MinValue)
                        doc.CreatedTime = DateTime.Now;
                }
                if (doc.Supplier == 0 && !string.IsNullOrEmpty(view.SupplierCode))
                {
                    var Supp = repository.Context.Queryable<Supplier>().Single(item => item.Code == view.SupplierCode);
                    if (Supp != null)
                        doc.Supplier = Supp.ID;
                }

                foreach (var item in doc.Lines)
                {
                    if (item.DeliveryOrder == 0)
                        item.DeliveryOrder = doc.ID;
                    if (view.id > 0)
                        item.SysVersion += 1;
                    if (item.Material == 0)
                    {
                        var mertial = repository.Context.Queryable<Item>().Single(it => it.Code == item.ItemCode);
                        if (mertial != null)
                            item.Material = mertial.ID;
                    }
                }
                bool flag = false;
                if (view.id == 0)
                    flag = repository.Context.InsertNav(doc).Include(item => item.Lines,
                            new InsertNavOptions() { OneToManyIfExistsNoInsert = true }).ExecuteCommand();
                else
                    flag = repository.Context.UpdateNav(doc).Include(item => item.Lines, new UpdateNavOptions() { OneToManyInsertOrUpdate = true }).ExecuteCommand();

                var vo = GetViewById(doc.ID);
                stopwatch.Stop();
                response.code = flag ? 200 : 401;
                response.data = JObject.FromObject(vo);
                response.msg = $"采购到货单保存成功，耗时：{stopwatch.ElapsedMilliseconds}毫秒";
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
                repository.BeginTran();
                foreach (long id in ids)
                    repository.Context.DeleteNav<DeliveryOrder>(item => item.ID == id).Include(item => item.Lines).ExecuteCommand();

                repository.CommitTran();
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"成功删除：{ids.Count}条记录,执行耗时：{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
                repository.RollbackTran();
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;

        }

        public ResponseBusBody Submit(DeliveryOrderView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var doc = repository.GetFirst(item => item.ID == view.id);
                if (doc == null)
                    throw new Exception($"采购到货单【{view.DocNo}】为空，不允许提交");

                if (view.SysVersion != doc.SysVersion)
                    throw new Exception($"采购到货单【{view.DocNo}】数据已被修改，不允许提交");

                repository.BeginTran();
                repository.Context.Updateable<DeliveryOrder>().SetColumns(it => new DeliveryOrder()
                {
                    SysVersion = it.SysVersion + 1,
                    Status = 1,
                    ModifiedBy = session.UserName,
                    ModifiedTime = DateTime.Now,
                    SubmitBy = session.UserName,
                    SubmitDate = DateTime.Now
                }
                ).Where(w => w.ID == view.id).ExecuteCommand();
                repository.CommitTran();
                var vo = GetViewById(view.id);
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"采购到货单提交完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
                response.data = JObject.FromObject(vo);
            }
            catch (Exception ex)
            {
                repository.RollbackTran();
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        public ResponseBusBody Approve(DeliveryOrderView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var doc = repository.GetFirst(item => item.ID == view.id);
                if (doc == null)
                    throw new Exception($"采购到货单【{view.DocNo}】为空，不允许审核");

                if (view.SysVersion != doc.SysVersion)
                    throw new Exception($"采购到货单【{view.DocNo}】数据已被修改，不允许审核");

                repository.BeginTran();
                repository.Context.Updateable<DeliveryOrder>().SetColumns(it => new DeliveryOrder()
                {
                    SysVersion = it.SysVersion + 1,
                    Status = 2,
                    ModifiedTime = DateTime.Now,
                    ModifiedBy = session.UserName,
                    ApprovedBy = session.UserName,
                    ApprovedOn = DateTime.Now
                }
                ).Where(w => w.ID == view.id).ExecuteCommand();
                repository.CommitTran();
                var vo = GetViewById(view.id);
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"采购到货单审核完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
                response.data = JObject.FromObject(vo);
            }
            catch (Exception ex)
            {
                repository.RollbackTran();
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        public ResponseBusBody UnApprove(DeliveryOrderView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var doc = repository.GetFirst(item => item.ID == view.id);
                if (doc == null)
                    throw new Exception($"采购到货单【{view.DocNo}】为空，不允许弃审");

                if (view.SysVersion != doc.SysVersion)
                    throw new Exception($"采购到货单【{view.DocNo}】数据已被修改，不允许弃审");

                repository.BeginTran();
                repository.Context.Updateable<DeliveryOrder>().SetColumns(it => new DeliveryOrder()
                {
                    SysVersion = it.SysVersion + 1,
                    Status = 0,
                    ModifiedBy = session.UserName,
                    ModifiedTime = DateTime.Now
                }).Where(w => w.ID == view.id).ExecuteCommand();
                repository.CommitTran();
                var vo = GetViewById(view.id);
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"采购到货单弃审完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
                response.data = JObject.FromObject(vo);
            }
            catch (Exception ex)
            {
                repository.RollbackTran();
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
                repository.BeginTran();
                repository.Context.Updateable<DeliveryOrder>().SetColumns(it => new DeliveryOrder()
                {
                    SysVersion = it.SysVersion + 1,
                    Status = 1,
                    ModifiedTime = DateTime.Now,
                    ModifiedBy = session.UserName,
                    SubmitBy = session.UserName,
                    SubmitDate = DateTime.Now
                }).Where(w => ids.Contains(w.ID)).ExecuteCommand();
                repository.CommitTran();
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"采购到货单提交完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
                repository.RollbackTran();
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
                repository.BeginTran();
                repository.Context.Updateable<DeliveryOrder>().SetColumns(it => new DeliveryOrder()
                {
                    SysVersion = it.SysVersion + 1,
                    Status = 2,
                    ModifiedTime = DateTime.Now,
                    ModifiedBy = session.UserName,
                    ApprovedBy = session.UserName,
                    ApprovedOn = DateTime.Now
                }).Where(w => ids.Contains(w.ID)).ExecuteCommand();
                repository.CommitTran();
                stopwatch.Stop();
                repository.CommitTran();
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"采购到货单审核完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
                repository.RollbackTran();
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
                repository.BeginTran();
                repository.Context.Updateable<DeliveryOrder>().SetColumns(it => new DeliveryOrder()
                {
                    SysVersion = it.SysVersion + 1,
                    Status = 0,
                    ModifiedBy = session.UserName,
                    ModifiedTime = DateTime.Now
                }).Where(w => ids.Contains(w.ID)).ExecuteCommand();
                repository.CommitTran();
                stopwatch.Stop();
                repository.CommitTran();
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"采购到货单弃审完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
                repository.RollbackTran();
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        #endregion

        #region 查询
        public ResponseBody QueryAllByPage(PageView view)
        {
            ResponseBody response = new ResponseBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                int total = 0;
                var docs = repository.Context.Queryable<DeliveryOrder>()
                    .Includes(item => item.Supp)
                    .Includes(item => item.Operators)
                    .Includes(item => item.Dept)
                    .Includes(item => item.Organization)
                    .OrderBy(item => item.CreatedTime,OrderByType.Desc)
                    .ToOffsetPage(view.PageNumber, view.PageSize, ref total);
                var views = mapper.Map<List<DeliveryOrderView>>(docs);
                stopwatch.Stop();
                response.code = 200;
                response.total = total;
                response.msg = $"采购到货单查询完成，共计{total}条记录，耗时：{total}";
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
        /// 根据ID查询采购到货单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseBusBody QueryDocById(long id)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                var doc = repository.Context.Queryable<DeliveryOrder>()
                     .IncludesAllFirstLayer()
                     .IncludesAllSecondLayer(item => item.Lines).Where(item => item.ID == id);
                var view = mapper.Map<DeliveryOrderView>(doc.First());
                response.data = JObject.FromObject(view);
                response.code = 200;
                response.msg = $"采购到货单查询耗时:{stopwatch.ElapsedMilliseconds} 毫秒";
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// 根据单号查询采购到货单
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        public ResponseBusBody QueryDocByDocNo(string DocNo)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                var doc = repository.Context.Queryable<DeliveryOrder>()
                     .IncludesAllFirstLayer()
                     .IncludesAllSecondLayer(item => item.Lines)
                     .Where(item => item.DocNo == DocNo);
                var view = mapper.Map<DeliveryOrderView>(doc.First());
                response.data = JObject.FromObject(view);
                response.code = 200;
                response.msg = $"采购到货单查询耗时:{stopwatch.ElapsedMilliseconds} 毫秒";
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        private DeliveryOrderView GetViewById(long id)
        {
            var doc = repository.Context.Queryable<DeliveryOrder>()
                       .IncludesAllFirstLayer()
                       .IncludesAllSecondLayer(item => item.Lines)
                       .Where(item => item.ID == id);
            return mapper.Map<DeliveryOrderView>(doc.First());
        }

        #endregion
    
    }
}

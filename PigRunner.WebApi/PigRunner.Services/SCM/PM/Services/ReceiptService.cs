using AutoMapper;
using Newtonsoft.Json.Linq;
using PigRunner.DTO.CommonView;
using PigRunner.DTO.SCM.PM;
using PigRunner.Entitys.Basic.Gop;
using PigRunner.Entitys.Basic;
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
using PigRunner.Public.Context;
using PigRunner.Public;
using Microsoft.Extensions.DependencyInjection;

namespace PigRunner.Services.SCM.PM.Services
{
    /// <summary>
    /// 采购入库单服务
    /// </summary>
    public class ReceiptService : IReceiptService
    {
        private PurchaseReceiptsRepository repository;
        private WebSession session;
        private IMapper mapper;
        /// <summary>
        /// 服务注册
        /// </summary>
        public ReceiptService(PurchaseReceiptsRepository _repository, WebSession _session, IMapper _mapper)
        {
            this.repository = _repository;
            this.session = _session;
            this.mapper = _mapper;
        }

        #region 业务操作
        public ResponseBusBody Save(ReceiptView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                ILoginAppContext context = ServiceLocator.Instance?.GetService<ILoginAppContext>();
                string UserDisplayName = context.LoginToken.DisplayName;
                long Org = context.LoginToken.Org;
                PurchaseReceipt doc = null;
                long SysVersion = 0;
                if (view.id > 0)
                {
                    doc = repository.AsQueryable().Includes(item => item.Lines).Where(w => w.ID == view.id).First();
                    SysVersion = doc.SysVersion;
                    if (SysVersion != view.SysVersion)
                        throw new Exception($"采购收货单【{doc.DocNo}】数据已被修改");
                }

                doc = mapper.Map<PurchaseReceipt>(view);
                if (view.id > 0)
                {
                    doc.SysVersion = SysVersion + 1;
                    doc.ModifiedBy = UserDisplayName;
                }
                else
                {
                    if (string.IsNullOrEmpty(doc.CreatedBy))
                        doc.CreatedBy = UserDisplayName;
                    if (doc.CreatedTime == DateTime.MinValue)
                        doc.CreatedTime = DateTime.Now;
                    if (doc.Org == 0)
                        doc.Org = Org;
                }
                if (doc.Supplier == 0 && !string.IsNullOrEmpty(view.SupplierCode))
                {
                    var Supp = repository.Context.Queryable<Supplier>().Single(item => item.Code == view.SupplierCode);
                    if (Supp != null)
                        doc.Supplier = Supp.ID;
                }

                foreach (var item in doc.Lines)
                {
                    if (item.PurchaseReceipt == 0)
                        item.PurchaseReceipt = doc.ID;
                    if (view.id > 0)
                        item.SysVersion += 1;
                    if (item.Material == 0)
                    {
                        var mertial = repository.Context.Queryable<Item>().Single(it => it.Code == item.ItemCode);
                        if (mertial != null)
                            item.Material = mertial.ID;
                    }
                    if (string.IsNullOrEmpty(item.CreatedBy))
                        item.CreatedBy = UserDisplayName;
                    if (item.ID > 0)
                    {
                        item.ModifiedBy = UserDisplayName;
                        item.ModifiedTime = DateTime.Now;
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
                response.msg = $"采购收货单保存成功，耗时：{stopwatch.ElapsedMilliseconds}毫秒";
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
                    repository.Context.DeleteNav<PurchaseReceipt>(item => item.ID == id).Include(item => item.Lines).ExecuteCommand();

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

        public ResponseBusBody Submit(ReceiptView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var doc = repository.GetFirst(item => item.ID == view.id);
                if (doc == null)
                    throw new Exception($"采购收货单【{view.DocNo}】为空，不允许提交");

                if (view.SysVersion != doc.SysVersion)
                    throw new Exception($"采购收货单【{view.DocNo}】数据已被修改，不允许提交");

                repository.BeginTran();
                repository.Context.Updateable<PurchaseReceipt>().SetColumns(it => new PurchaseReceipt()
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
                response.msg = $"采购收货单提交完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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

        public ResponseBusBody Approve(ReceiptView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var doc = repository.GetFirst(item => item.ID == view.id);
                if (doc == null)
                    throw new Exception($"采购收货单【{view.DocNo}】为空，不允许审核");

                if (view.SysVersion != doc.SysVersion)
                    throw new Exception($"采购收货单【{view.DocNo}】数据已被修改，不允许审核");

                repository.BeginTran();
                repository.Context.Updateable<PurchaseReceipt>().SetColumns(it => new PurchaseReceipt()
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
                response.msg = $"采购收货单审核完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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

        public ResponseBusBody UnApprove(ReceiptView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var doc = repository.GetFirst(item => item.ID == view.id);
                if (doc == null)
                    throw new Exception($"采购收货单【{view.DocNo}】为空，不允许弃审");

                if (view.SysVersion != doc.SysVersion)
                    throw new Exception($"采购收货单【{view.DocNo}】数据已被修改，不允许弃审");

                repository.BeginTran();
                repository.Context.Updateable<PurchaseReceipt>().SetColumns(it => new PurchaseReceipt()
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
                response.msg = $"采购收货单弃审完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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
                repository.Context.Updateable<PurchaseReceipt>().SetColumns(it => new PurchaseReceipt()
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
                response.msg = $"采购收货单提交完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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
                repository.Context.Updateable<PurchaseReceipt>().SetColumns(it => new PurchaseReceipt()
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
                response.msg = $"采购收货单审核完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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
                repository.Context.Updateable<PurchaseReceipt>().SetColumns(it => new PurchaseReceipt()
                {
                    SysVersion = it.SysVersion + 1,
                    Status = 0,
                    ModifiedBy = session.UserName,
                    ModifiedTime = DateTime.Now
                }).Where(w => ids.Contains(w.ID)).ExecuteCommand();
                //采购收货产生库存异动
                repository.CommitTran();
                stopwatch.Stop();
                repository.CommitTran();
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"采购收货单弃审完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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
                var docs = repository.Context.Queryable<PurchaseReceipt>()
                    .Includes(item => item.Supp)
                    .Includes(item => item.Symbol)
                    .Includes(item => item.ReqDept)
                    .Includes(item => item.ReqMan)
                    .Includes(item => item.Operators)
                    .Includes(item => item.Dept)
                    .Includes(item => item.Organization)
                    .OrderBy(item => item.CreatedTime, OrderByType.Desc)
                    .ToOffsetPage(view.PageNumber, view.PageSize, ref total);
                var views = mapper.Map<List<ReceiptView>>(docs);
                stopwatch.Stop();
                response.code = 200;
                response.total = total;
                response.msg = $"采购收货单查询完成，共计{total}条记录，耗时：{total}";
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
        /// 根据ID查询采购收货单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseBusBody QueryDocById(long id)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                response.data = JObject.FromObject(GetViewById(id));
                response.code = 200;
                response.msg = $"采购收货单查询耗时:{stopwatch.ElapsedMilliseconds} 毫秒";
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// 根据单号查询采购收货单
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        public ResponseBusBody QueryDocByDocNo(string DocNo)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                var doc = repository.Context.Queryable<PurchaseReceipt>()
                     .IncludesAllFirstLayer()
                     .IncludesAllSecondLayer(item => item.Lines)
                     .Where(item => item.DocNo == DocNo);
                var view = mapper.Map<ReceiptView>(doc.First());
                response.data = JObject.FromObject(view);
                response.code = 200;
                response.msg = $"采购收货单查询耗时:{stopwatch.ElapsedMilliseconds} 毫秒";
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        private ReceiptView GetViewById(long id)
        {
            var doc = repository.Context.Queryable<PurchaseReceipt>()
                       .IncludesAllFirstLayer()
                       .IncludesAllSecondLayer(item => item.Lines)
                       .Where(item => item.ID == id);
            return mapper.Map<ReceiptView>(doc.First());
        }
        /// <summary>
        /// 查询采购收货单明细
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
                var docs = repository.Context.Queryable<PurchaseReceiptLine>()
                     .IncludesAllFirstLayer()
                    .OrderBy(item => item.CreatedTime, OrderByType.Desc)
                    .ToOffsetPage(view.PageNumber, view.PageSize, ref total);
                var views = mapper.Map<List<ReceiptLineView>>(docs);
                stopwatch.Stop();
                response.code = 200;
                response.total = total;
                response.msg = $"采购收货单明细查询完成，共计{total}条记录，耗时：{total}";
                response.data = JArray.FromObject(views);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        #endregion

    }
}

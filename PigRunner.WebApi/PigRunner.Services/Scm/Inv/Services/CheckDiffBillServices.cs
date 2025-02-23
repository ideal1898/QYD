using AutoMapper;
using Newtonsoft.Json.Linq;
using PigRunner.DTO.SCM.INV;
using PigRunner.DTO.CommonView;
using PigRunner.Entitys.Basic.Gop;
using PigRunner.Entitys.Basic;
using PigRunner.Entitys.SCM.INV;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.SCM.INV;
using PigRunner.Services.SCM.INV.IServices;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.SCM.INV.Services
{
    /// <summary>
    /// 差异核对单服务
    /// </summary>
    public class CheckDiffBillService : ICheckDiffBillService
    {
        private CheckDiffBillRepository repository;
        private WebSession session;
        private IMapper mapper;

        /// <summary>
        /// 服务注册
        /// </summary>
        public CheckDiffBillService(CheckDiffBillRepository _repository, WebSession _session, IMapper _mapper)
        {
            this.repository = _repository;
            this.session = _session;
            this.mapper = _mapper;
        }

        #region 业务操作
        public ResponseBusBody Save(CheckDiffBillView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                CheckDiffBill doc = null;
                long SysVersion = 0;
                if (view.id > 0)
                {
                    doc = repository.AsQueryable().Includes(item => item.Lines).Where(w => w.ID == view.id).First();
                    SysVersion = doc.SysVersion;
                    if (SysVersion != view.SysVersion)
                        throw new Exception($"差异核对单【{doc.DocNo}】数据已被修改");
                }

                doc = mapper.Map<CheckDiffBill>(view);
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

                foreach (var item in doc.Lines)
                {
                    if (item.CheckDiffBill == 0)
                        item.CheckDiffBill = doc.ID;
                    if (view.id > 0)
                        item.SysVersion += 1;
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
                response.msg = $"差异核对单保存成功，耗时：{stopwatch.ElapsedMilliseconds}毫秒";
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
                    repository.Context.DeleteNav<CheckDiffBill>(item => item.ID == id).Include(item => item.Lines).ExecuteCommand();

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

        public ResponseBusBody Submit(CheckDiffBillView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var doc = repository.GetFirst(item => item.ID == view.id);
                if (doc == null)
                    throw new Exception($"差异核对单【{view.DocNo}】为空，不允许提交");

                if (view.SysVersion != doc.SysVersion)
                    throw new Exception($"差异核对单【{view.DocNo}】数据已被修改，不允许提交");

                repository.BeginTran();
                repository.Context.Updateable<CheckDiffBill>().SetColumns(it => new CheckDiffBill()
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
                response.msg = $"差异核对单提交完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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

        public ResponseBusBody Approve(CheckDiffBillView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var doc = repository.GetFirst(item => item.ID == view.id);
                if (doc == null)
                    throw new Exception($"差异核对单【{view.DocNo}】为空，不允许审核");

                if (view.SysVersion != doc.SysVersion)
                    throw new Exception($"差异核对单【{view.DocNo}】数据已被修改，不允许审核");

                repository.BeginTran();
                repository.Context.Updateable<CheckDiffBill>().SetColumns(it => new CheckDiffBill()
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
                response.msg = $"差异核对单审核完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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

        public ResponseBusBody UnApprove(CheckDiffBillView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var doc = repository.GetFirst(item => item.ID == view.id);
                if (doc == null)
                    throw new Exception($"差异核对单【{view.DocNo}】为空，不允许弃审");

                if (view.SysVersion != doc.SysVersion)
                    throw new Exception($"差异核对单【{view.DocNo}】数据已被修改，不允许弃审");

                repository.BeginTran();
                repository.Context.Updateable<CheckDiffBill>().SetColumns(it => new CheckDiffBill()
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
                response.msg = $"差异核对单弃审完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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
                repository.Context.Updateable<CheckDiffBill>().SetColumns(it => new CheckDiffBill()
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
                response.msg = $"差异核对单提交完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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
                repository.Context.Updateable<CheckDiffBill>().SetColumns(it => new CheckDiffBill()
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
                response.code = 200;
                response.msg = $"差异核对单审核完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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
                repository.Context.Updateable<CheckDiffBill>().SetColumns(it => new CheckDiffBill()
                {
                    SysVersion = it.SysVersion + 1,
                    Status = 0,
                    ModifiedBy = session.UserName,
                    ModifiedTime = DateTime.Now
                }).Where(w => ids.Contains(w.ID)).ExecuteCommand();
                repository.CommitTran();
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"差异核对单弃审完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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
                var docs = repository.Context.Queryable<CheckDiffBill>()
                    .ToOffsetPage(view.PageNumber, view.PageSize, ref total);
                var views = mapper.Map<List<CheckDiffBillView>>(docs);
                stopwatch.Stop();
                response.code = 200;
                response.total = total;
                response.msg = $"差异核对单查询完成，共计{total}条记录，耗时：{stopwatch.ElapsedMilliseconds}毫秒";
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
        /// 根据ID查询差异核对单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseBusBody QueryDocById(long id)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var doc = repository.GetFirst(item => item.ID == id);
                if (doc == null)
                {
                    response.code = 404;
                    response.msg = $"未找到ID为{id}的差异核对单";
                    return response;
                }
                var view = mapper.Map<CheckDiffBillView>(doc);
                stopwatch.Stop();
                response.code = 200;
                response.data = JObject.FromObject(view);
                response.msg = $"查询ID为{id}的差异核对单完成，耗时：{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// 根据单据编号查询差异核对单
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        public ResponseBusBody QueryDocByDocNo(string DocNo)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var doc = repository.GetFirst(item => item.DocNo == DocNo);
                if (doc == null)
                {
                    response.code = 404;
                    response.msg = $"未找到单据编号为{DocNo}的差异核对单";
                    return response;
                }
                var view = mapper.Map<CheckDiffBillView>(doc);
                stopwatch.Stop();
                response.code = 200;
                response.data = JObject.FromObject(view);
                response.msg = $"查询单据编号为{DocNo}的差异核对单完成，耗时：{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// 分页查询明细
        /// </summary>
        /// <param name="Where">查询条件</param>
        /// <param name="PageSize">每页大小</param>
        /// <param name="Current">当前页面</param>
        /// <param name="Total">总数量</param>
        /// <returns></returns>
        public ResponseBody queryLineByPage(PageView view)
        {
            ResponseBody response = new ResponseBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                int total = 0;
                var lines = repository.Context.Queryable<CheckDiffBillLine>()
                    .ToOffsetPage(view.PageNumber, view.PageSize, ref total);
                var lineViews = mapper.Map<List<CheckDiffBillLineView>>(lines);
                stopwatch.Stop();
                response.code = 200;
                response.total = total;
                response.msg = $"差异核对单明细查询完成，共计{total}条记录，耗时：{stopwatch.ElapsedMilliseconds}毫秒";
                response.data = JArray.FromObject(lineViews);
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        #endregion

        /// <summary>
        /// 根据ID获取视图对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private CheckDiffBillView GetViewById(long id)
        {
            var doc = repository.GetFirst(item => item.ID == id);
            return mapper.Map<CheckDiffBillView>(doc);
        }
    }
}
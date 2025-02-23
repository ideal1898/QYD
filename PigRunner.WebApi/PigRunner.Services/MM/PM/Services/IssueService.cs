using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PigRunner.DTO.CommonView;
using PigRunner.DTO.MM.PM;
using PigRunner.Entitys.Basic;
using PigRunner.Entitys.BCP.Lot;
using PigRunner.Entitys.MM.PM;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.MM.PM;
using PigRunner.Services.MM.PM.IServices;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.MM.PM.Services
{
    public class IssueService : IIssueService
    {
        private IssueRepository repository;
        private WebSession session;
        private IMapper mapper;

        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_IssueRepository"></param>
        public IssueService(IssueRepository _repository, WebSession _session, IMapper _mapper)
        {
            this.repository = _repository;
            this.session = _session;
            this.mapper = _mapper;
        }

        #region  业务操作

        /// <summary>
        /// 领料单保存
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ResponseBusBody Save(IssueView request)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                if (request == null)
                    throw new Exception("参数不能为空！");
                if (request.IssueLines == null || request.IssueLines.Count <= 0)
                    throw new Exception("领料单行信息不能为空！");
                if (string.IsNullOrEmpty(request.BusinessDate))
                    throw new Exception("单据日期不能为空！");

                if (string.IsNullOrEmpty(request.OrgCode))
                    throw new Exception("组织不能为空！");

                int Status = request.Status;
                long SysVersion = 0;
                Issue head = null;
                if (request.id > 0)
                {
                    head = repository.GetFirst(q => q.ID == request.id);
                    if (head == null)
                        throw new Exception(string.Format("ID为【{0}】的领料单不存在！", request.id));
                    SysVersion = head.SysVersion;
                    if (SysVersion != request.SysVersion)
                        throw new Exception($"领料单【{head.DocNo}】数据已被修改");
                }

                //自动编码生成单号
                if (string.IsNullOrEmpty(request.DocNo))
                {
                    string DocNo = $"LL{DateTime.Now.ToString("yyyyMMdd")}";
                    var maxSerialNumber = repository.Context.Queryable<Issue>()
                        .Where(o => o.DocNo.Contains(DocNo))
                        .Max(o => o.DocNo);
                    if (string.IsNullOrEmpty(maxSerialNumber))
                        DocNo += "00001";
                    else
                    {
                        string MaxNum = maxSerialNumber.Substring(DocNo.Length, maxSerialNumber.Length- DocNo.Length);

                        int num = 1;
                        int.TryParse(MaxNum, out num);
                        num += 1;
                        if (num.ToString().Length == 1)
                            DocNo += "0000" + num;
                        else if (num.ToString().Length == 2)
                            DocNo += "000" + num;
                        else if (num.ToString().Length == 3)
                            DocNo += "00" + num;
                        else if (num.ToString().Length == 4)
                            DocNo += "0" + num;
                        else
                            DocNo += num;
                    }
                    request.DocNo = DocNo;
                }
                int linenum = 1;
                //先把视图中实体字段转为对应ID
                foreach (var item in request.IssueLines)
                {
                    if (string.IsNullOrEmpty(item.ItemCode))
                        throw new Exception("料号不能为空！");

                    var itemEy = repository.Context.Queryable<Item>().Single(q => q.Code == item.ItemCode);
                    if (itemEy == null)
                        throw new Exception(string.Format("编码为【{0}】的物料不存在，请检查！", item.ItemCode));
                    item.ItemID = itemEy.ID;

                    if (item.IssueUomID <= 0 && !string.IsNullOrEmpty(item.IssueUomCode))
                    {
                        var uom = repository.Context.Queryable<UOM>().Single(q => q.Code == item.IssueUomCode);
                        if (uom == null)
                            throw new Exception(string.Format("编码为【{0}】的计量单位不存在，请检查！", item.IssueUomCode));
                        item.IssueUomID = uom.ID;
                    }

                    if (item.IssueWhID <= 0 && !string.IsNullOrEmpty(item.IssueWhCode))
                    {
                        var wh = repository.Context.Queryable<Wh>().Single(q => q.Code == item.IssueWhCode);
                        if (wh == null)
                            throw new Exception(string.Format("编码为【{0}】的仓库不存在，请检查！", item.IssueWhCode));
                        item.IssueWhID = wh.ID;
                    }

                    if (item.WhShID <= 0 && !string.IsNullOrEmpty(item.WhShCode))
                    {
                        var wh = repository.Context.Queryable<WhSh>().Single(q => q.Code == item.WhShCode);
                        if (wh == null)
                            throw new Exception(string.Format("编码为【{0}】的货位不存在，请检查！", item.WhShCode));
                        item.WhShID = wh.ID;
                    }

                    if (!string.IsNullOrEmpty(item.LotCode))
                    {
                        var lot = repository.Context.Queryable<LotMaster>().Where(q => q.LotCode == item.LotCode).ToList()?.FirstOrDefault();
                        if (lot == null)
                            throw new Exception(string.Format("编码为【{0}】的批号主档不存在，请检查！", item.LotCode));

                        item.LotMasterID = lot.ID;
                    }
                    item.LineNum = linenum;
                    linenum++;
                }

                head = mapper.Map<Issue>(request);
                if (request.id > 0)
                    head.SysVersion = SysVersion + 1;

                var org = repository.Context.Queryable<Organization>().Where(q => q.Code == request.OrgCode).ToList()?.FirstOrDefault();
                if (org == null)
                    throw new Exception(string.Format("编码为【{0}】的组织机构不存在，请检查！", request.OrgCode));
                head.Org = org.ID;
                head.DocNo = request.DocNo;
                head.Status = Status;



                if (!string.IsNullOrEmpty(request.DocNo))
                {
                    Issue oldhead = repository.GetFirst(q => q.DocNo == request.DocNo && q.Org == org.ID && q.ID != head.ID);
                    if (oldhead != null)
                        throw new Exception(string.Format("单号为【{0}】的领料单已存在！", request.DocNo));
                }
                DateTime time = DateTime.Now;
                DateTime.TryParse(request.BusinessDate, out time);
                head.BusinessDate = time;

                if (!string.IsNullOrEmpty(request.BusinessCreatedOn))
                {
                    DateTime date = DateTime.Now;
                    DateTime.TryParse(request.BusinessCreatedOn, out date);
                    if (date != DateTime.MinValue)
                        head.BusinessCreatedOn = date;
                }

                foreach (var item in head.IssueLines)
                {
                    if (item.IssueID == 0)
                        item.IssueID = head.ID;
                    if (request.id > 0)
                        item.SysVersion += 1;
                }
                bool flag = false;
                if (request.id == 0)
                    flag = repository.Context.InsertNav(head).Include(item => item.IssueLines,
                            new InsertNavOptions() { OneToManyIfExistsNoInsert = true }).ExecuteCommand();
                else
                    flag = repository.Context.UpdateNav(head).Include(item => item.IssueLines, new UpdateNavOptions() { OneToManyInsertOrUpdate = true }).ExecuteCommand();
                if (!flag)
                    throw new Exception("领料单新增/修改操作失败！");

                //重新查询单据
                head = repository.Context.Queryable<Issue>()
                    .Includes(item => item.Organization)
                    .Includes(item => item.HandleDept)
                      .Includes(item => item.HandlePerson)
                    .Includes(item => item.IssueLines, line => line.ItemMaster)
                     .Includes(item => item.IssueLines, line => line.IssueUom)
                      .Includes(item => item.IssueLines, line => line.LotMaster)
                        .Includes(item => item.IssueLines, line => line.IssueWh)
                          .Includes(item => item.IssueLines, line => line.WhSh)
                    .Where(item => item.ID == head.ID).First();
                //将实体转化成View
                var vo = mapper.Map<IssueView>(head);
                stopwatch.Stop();
                response.code = flag ? 200 : 401;
                response.data = JObject.FromObject(vo);
                response.msg = $"领料单保存成功，耗时：{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
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
                    repository.Context.DeleteNav<Issue>(item => item.ID == id).Include(item => item.IssueLines).ExecuteCommand();

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

        public ResponseBusBody Submit(IssueView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var Issue = repository.GetFirst(item => item.ID == view.id);
                if (Issue == null)
                    throw new Exception($"领料单【{view.DocNo}】为空，不允许提交");

                if (view.SysVersion != Issue.SysVersion)
                    throw new Exception($"领料单【{view.DocNo}】数据已被修改，不允许提交");

                repository.BeginTran();
                repository.Context.Updateable<Issue>().SetColumns(it => new Issue() { SysVersion = it.SysVersion + 1, Status = 1 }).Where(w => w.ID == view.id).ExecuteCommand();
                repository.CommitTran();
                var vo = GetIssueViewById(view.id);
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"领料单提交完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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

        public ResponseBusBody Approve(IssueView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var Issue = repository.GetFirst(item => item.ID == view.id);
                if (Issue == null)
                    throw new Exception($"领料单【{view.DocNo}】为空，不允许审核");

                if (view.SysVersion != Issue.SysVersion)
                    throw new Exception($"领料单【{view.DocNo}】数据已被修改，不允许审核");

                repository.BeginTran();
                repository.Context.Updateable<Issue>().SetColumns(it => new Issue() { SysVersion = it.SysVersion + 1, Status = 2 }).Where(w => w.ID == view.id).ExecuteCommand();
                repository.CommitTran();
                var vo = GetIssueViewById(view.id);
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"领料单审核完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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

        public ResponseBusBody UnApprove(IssueView view)
        {
            ResponseBusBody response = new ResponseBusBody();
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var Issue = repository.GetFirst(item => item.ID == view.id);
                if (Issue == null)
                    throw new Exception($"领料单【{view.DocNo}】为空，不允许弃审");

                if (view.SysVersion != Issue.SysVersion)
                    throw new Exception($"领料单【{view.DocNo}】数据已被修改，不允许弃审");

                repository.BeginTran();
                repository.Context.Updateable<Issue>().SetColumns(it => new Issue() { SysVersion = it.SysVersion + 1, Status = 0 }).Where(w => w.ID == view.id).ExecuteCommand();
                repository.CommitTran();
                var vo = GetIssueViewById(view.id);
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"领料单弃审完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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
                repository.Context.Updateable<Issue>().SetColumns(it => new Issue() { SysVersion = it.SysVersion + 1, Status = 1 }).Where(w => ids.Contains(w.ID)).ExecuteCommand();
                repository.CommitTran();
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"领料单提交完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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
                repository.Context.Updateable<Issue>().SetColumns(it => new Issue() { SysVersion = it.SysVersion + 1, Status = 2 }).Where(w => ids.Contains(w.ID)).ExecuteCommand();
                repository.CommitTran();
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"领料单审核完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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
                repository.Context.Updateable<Issue>().SetColumns(it => new Issue() { SysVersion = it.SysVersion + 1, Status = 0 }).Where(w => ids.Contains(w.ID)).ExecuteCommand();
                repository.CommitTran();
                stopwatch.Stop();
                response.code = 200;
                response.msg = $"领料单弃审完成，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
            }
            catch (Exception ex)
            {
                repository.RollbackTran();
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        public ResponseBody MOToIssue(List<MOToIssueView> views)
        {
            ResponseBody response = new ResponseBody();

            try
            {

                if (views == null || views.Count <= 0)
                    throw new Exception("创建单据信息不能为空！");

                DateTime businessDate = DateTime.Today;

                //查询
                var Lines = views.SelectMany(item => item.Lines).ToList();
                repository.BeginTran();

                Issue doc = new Issue();

                doc.IssueLines = new List<IssueLine>();
                foreach (var requisition in views)
                {
                    foreach (var line in requisition.Lines)
                        ;


                }


                bool flag = repository.Context.InsertNav<Issue>(doc).Include(item => item.IssueLines, new InsertNavOptions() { OneToManyIfExistsNoInsert = true }).ExecuteCommand();
                //保存成功,回写数据
                repository.CommitTran();

                response.code = 200;
                response.msg = "生产转领料业务处理完成";
            }
            catch (Exception ex)
            {
                response.code = 200;
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
                string sql = "ID>0";
                if (view.Where != null && view.Where.Count > 0)
                {
                    var queryView = JsonConvert.SerializeObject(view.Where);
                    List<IssueQueryView> queryViewDTO = JsonConvert.DeserializeObject<List<IssueQueryView>>(queryView);
                    if (queryViewDTO != null && queryViewDTO.Count > 0)
                    {
                        foreach (var item in queryViewDTO)
                        {
                            if (!string.IsNullOrEmpty(item.DocNo))
                                sql += string.Format(@" and DocNo like '%{0}%'", item.DocNo);

                            if (!string.IsNullOrEmpty(item.BusinessDate))
                                sql += string.Format(@" and BusinessDate = '{0}'", item.BusinessDate);
                            if (!string.IsNullOrEmpty(item.StartDate))
                                sql += string.Format(@" and StartDate = '{0}'", item.StartDate);
                            if (!string.IsNullOrEmpty(item.Status))
                                sql += string.Format(@" and Status ={0}", item.Status);
                        }
                    }
                }

                int total = 0;
                var head = repository.Context.Queryable<Issue>()
                    .Includes(item => item.Organization)
                    .Includes(item => item.HandleDept)
                      .Includes(item => item.HandlePerson)
                    .Includes(item => item.IssueLines, line => line.ItemMaster)
                     .Includes(item => item.IssueLines, line => line.IssueUom)
                      .Includes(item => item.IssueLines, line => line.LotMaster)
                        .Includes(item => item.IssueLines, line => line.IssueWh)
                          .Includes(item => item.IssueLines, line => line.WhSh).Where(sql).ToOffsetPage(view.PageNumber, view.PageSize, ref total);
                var views = mapper.Map<List<IssueView>>(head);
                stopwatch.Stop();
                response.code = 200;
                response.total = total;
                response.msg = $"领料单查询完成，共计{total}条记录，耗时:{stopwatch.ElapsedMilliseconds}毫秒";
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
        /// 根据ID查询领料单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseBusBody QueryDocById(long id)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                var head = repository.Context.Queryable<Issue>()
                    .Includes(item => item.Organization)
                    .Includes(item => item.HandleDept)
                      .Includes(item => item.HandlePerson)
                    .Includes(item => item.IssueLines, line => line.ItemMaster)
                     .Includes(item => item.IssueLines, line => line.IssueUom)
                      .Includes(item => item.IssueLines, line => line.LotMaster)
                        .Includes(item => item.IssueLines, line => line.IssueWh)
                          .Includes(item => item.IssueLines, line => line.WhSh)
                  .Where(item => item.ID == id);
                var view = mapper.Map<IssueView>(head.First());
                response.data = JObject.FromObject(view);
                response.code = 200;
                response.msg = $"领料单查询耗时:{stopwatch.ElapsedMilliseconds} 毫秒";
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// 根据单号查询领料单
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        public ResponseBusBody QueryDocByDocNo(string DocNo)
        {
            ResponseBusBody response = new ResponseBusBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                var head = repository.Context.Queryable<Issue>()
                    .Includes(item => item.Organization)
                    .Includes(item => item.HandleDept)
                      .Includes(item => item.HandlePerson)
                    .Includes(item => item.IssueLines, line => line.ItemMaster)
                     .Includes(item => item.IssueLines, line => line.IssueUom)
                      .Includes(item => item.IssueLines, line => line.LotMaster)
                        .Includes(item => item.IssueLines, line => line.IssueWh)
                          .Includes(item => item.IssueLines, line => line.WhSh)
                  .Where(item => item.DocNo == DocNo);
                var view = mapper.Map<IssueView>(head.First());
                response.data = JObject.FromObject(view);
                response.code = 200;
                response.msg = $"领料单查询耗时:{stopwatch.ElapsedMilliseconds} 毫秒";
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.msg = ex.Message;
            }

            return response;
        }

        private IssueView GetIssueViewById(long id)
        {
            var head = repository.Context.Queryable<Issue>()
                    .Includes(item => item.Organization)
                    .Includes(item => item.HandleDept)
                      .Includes(item => item.HandlePerson)
                    .Includes(item => item.IssueLines, line => line.ItemMaster)
                     .Includes(item => item.IssueLines, line => line.IssueUom)
                      .Includes(item => item.IssueLines, line => line.LotMaster)
                        .Includes(item => item.IssueLines, line => line.IssueWh)
                          .Includes(item => item.IssueLines, line => line.WhSh)
                 .Where(item => item.ID == id);
            return mapper.Map<IssueView>(head.First());
        }

        #endregion
    }
}

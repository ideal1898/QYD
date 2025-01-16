using Newtonsoft.Json.Linq;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.MM.PM.Services
{
    public class MOService : IMOService
    {
        private MORepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_MORepository"></param>
        public MOService(MORepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 生产订单保存
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse MOSave(MOView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request == null)
                    throw new Exception("参数不能为空！");

                int Status = 0;
                int.TryParse(request.Status, out Status);

                MO head = null;
                if (request.id > 0)
                {
                    head = repository.GetFirst(q => q.ID == request.id);
                    if (head == null)
                        throw new Exception(string.Format("ID为【{0}】的生产订单不存在！", request.id));
                }
                else
                {
                    head = MO.Create();
                    Status = 0;
                }

                if (request.Lines == null || request.Lines.Count <= 0)
                    throw new Exception("生产订单行信息不能为空！");

                if (string.IsNullOrEmpty(request.BusinessDate))
                    throw new Exception("单据日期不能为空！");

                if (string.IsNullOrEmpty(request.OrgCode))
                    throw new Exception("组织不能为空！");
                var org = repository.Context.Queryable<Organization>().Where(q => q.Code == request.OrgCode).ToList()?.FirstOrDefault();
                if (org == null)
                    throw new Exception(string.Format("编码为【{0}】的组织机构不存在，请检查！", request.OrgCode));
                head.Org = org.ID;
                head.DocType = request.DocType;
                head.DocNo = request.DocNo;
                head.Status = Status;



                if (!string.IsNullOrEmpty(request.DocNo))
                {
                    MO oldhead = repository.GetFirst(q => q.DocNo == request.DocNo && q.Org == org.ID && q.ID != head.ID);
                    if (oldhead != null)
                        throw new Exception(string.Format("单号为【{0}】的生产订单已存在！", request.DocNo));
                }
                DateTime time = DateTime.Now;
                DateTime.TryParse(request.BusinessDate, out time);
                head.BusinessDate = time;

                if (!string.IsNullOrEmpty(request.StartDate))
                {
                    DateTime date = DateTime.Now;
                    DateTime.TryParse(request.StartDate, out date);
                    if (date != DateTime.MinValue)
                        head.StartDate = date;
                }

                if (!string.IsNullOrEmpty(request.CompleteDate))
                {
                    DateTime date = DateTime.Now;
                    DateTime.TryParse(request.CompleteDate, out date);
                    if (date != DateTime.MinValue)
                        head.CompleteDate = date;
                }

                if (!string.IsNullOrEmpty(request.MoDeptCode))
                {
                    var obj = repository.Context.Queryable<Department>().Where(q => q.Code == request.MoDeptCode).ToList()?.FirstOrDefault();
                    if (obj == null)
                        throw new Exception(string.Format("编码为【{0}】的部门不存在，请检查！", request.MoDeptCode));
                    head.MoDept = obj.ID;
                }

                if (!string.IsNullOrEmpty(request.BusinessPersonCode))
                {
                    var obj = repository.Context.Queryable<Operators>().Where(q => q.Code == request.BusinessPersonCode).ToList()?.FirstOrDefault();
                    if (obj == null)
                        throw new Exception(string.Format("编码为【{0}】的业务员不存在，请检查！", request.BusinessPersonCode));
                    head.BusinessPerson = obj.ID;
                }

                if (!string.IsNullOrEmpty(request.CompleteWhCode))
                {
                    var obj = repository.Context.Queryable<Wh>().Where(q => q.Code == request.CompleteWhCode).ToList()?.FirstOrDefault();
                    if (obj == null)
                        throw new Exception(string.Format("编码为【{0}】的仓库不存在，请检查！", request.CompleteWhCode));
                    head.CompleteWh = obj.ID;
                }
                head.Memo = request.Memo;
                head.MOLines = new List<MOLine>();

                //记录修改行ID，没记录则默认删除行
                List<long> lstMOLine=new List<long>();

                List<MOLine> oldLine =new  List<MOLine>();
                if (request.id > 0)
                {
                    var lst = repository.Context.Queryable<MO>().Includes(q => q.MOLines).Where(q => q.ID == request.id).ToList();
                    if (lst == null || lst.Count <= 0)
                        throw new Exception(string.Format("ID为【{0}】的生产订单不存在！", request.id));
                    oldLine = lst.FirstOrDefault().MOLines;
                }


                foreach (var item in request.Lines)
                {
                    if (string.IsNullOrEmpty(item.LineNum))
                        throw new Exception("行号不能为空！");

                    if (string.IsNullOrEmpty(item.MoQty))
                        throw new Exception("生产数量不能为空！");
                    int LineNum = Convert.ToInt32(item.LineNum);

                    decimal MoQty = 0m;
                    decimal.TryParse(item.MoQty, out MoQty);
                    if (MoQty <= 0)
                        throw new Exception(string.Format("【{0}】行生产数量要大于零！", LineNum));


                    if (string.IsNullOrEmpty(item.ItemCode))
                        throw new Exception(string.Format("【{0}】行料号不能为空！", LineNum));

                    if (string.IsNullOrEmpty(item.MoUomCode))
                        throw new Exception(string.Format("【{0}】行生产单位不能为空！", LineNum));

                    var itemEy = repository.Context.Queryable<Item>().Where(q => q.Code == item.ItemCode).ToList()?.FirstOrDefault();
                    if (itemEy == null)
                        throw new Exception(string.Format("编码为【{0}】的物料不存在，请检查！", item.ItemCode));

                    var uom = repository.Context.Queryable<UOM>().Where(q => q.Code == item.MoUomCode).ToList()?.FirstOrDefault();
                    if (uom == null)
                        throw new Exception(string.Format("编码为【{0}】的计量单位不存在，请检查！", item.MoUomCode));
                    MOLine line = null;
                    if (request.id > 0)
                    {
                        if (!string.IsNullOrEmpty(item.Action) && item.Action.Equals("Add"))
                        {
                            line = MOLine.Create();
                        }
                        else
                        {
                            line = repository.Context.Queryable<MOLine>().Where(q => q.ID == item.id).ToList()?.FirstOrDefault();
                            if (line == null)
                                throw new Exception(string.Format("行修改时，ID为【{0}】生产订单行不存在！", item.id));
                        }
                        if (item.id > 0)
                            lstMOLine.Add(item.id);
                    }
                    else
                        line = MOLine.Create();
                    line.MO = head.ID;
                    line.LineNum = LineNum;
                    line.Item = itemEy.ID;
                    line.MoUom = uom.ID;
                    line.MoQty = MoQty;

                    if (!string.IsNullOrEmpty(item.StartDate))
                    {
                        DateTime date = DateTime.Now;
                        DateTime.TryParse(item.StartDate, out date);
                        line.StartDate = date;
                    }
                    if (!string.IsNullOrEmpty(item.CompleteDate))
                    {
                        DateTime date = DateTime.Now;
                        DateTime.TryParse(item.CompleteDate, out date);
                        if (date != DateTime.MinValue)
                            line.CompleteDate = date;
                    }
                    line.SrcDocNo = item.SrcDocNo;
                    line.SrcDocType = item.SrcDocType;

                    if (!string.IsNullOrEmpty(item.ActualStartDate))
                    {
                        DateTime date = DateTime.Now;
                        DateTime.TryParse(item.ActualStartDate, out date);
                        if (date != DateTime.MinValue)
                            line.ActualStartDate = date;
                    }
                    if (!string.IsNullOrEmpty(item.ActualCompleteDate))
                    {
                        DateTime date = DateTime.Now;
                        DateTime.TryParse(item.ActualCompleteDate, out date);
                        if (date != DateTime.MinValue)
                            line.ActualCompleteDate = date;
                    }

                    line.BomVersion = item.BomVersion;
                    line.Routing = item.Routing;

                    if (!string.IsNullOrEmpty(item.LotCode))
                    {
                        var lot = repository.Context.Queryable<LotMaster>().Where(q => q.LotCode == item.LotCode).ToList()?.FirstOrDefault();
                        if (lot == null)
                            throw new Exception(string.Format("编码为【{0}】的批号主档不存在，请检查！", item.LotCode));

                        line.LotMaster = lot.ID;
                    }
                    head.MOLines.Add(line);
                }

                //删除行
                if (lstMOLine.Count > 0)
                {
                    List<MOLine> list = new List<MOLine>();
                    foreach (var item in oldLine)
                    {
                        if (lstMOLine.Contains(item.ID))
                            continue;
                        list.Add(item);
                    }
                    //批量删除行
                    if(list.Count > 0)
                    {
                        repository.Context.Deleteable<MOLine>(list).ExecuteCommand(); //批量删除
                    }
                }

                bool isSuccess = false;
                if(request.id>0)
                {
                    isSuccess= repository.Context.UpdateNav(head).Include(q => q.MOLines).ExecuteCommand();
                }
                else
                {
                    isSuccess= repository.Context.InsertNav(head).Include(q => q.MOLines).ExecuteCommand();
                }
                if (!isSuccess)
                    throw new Exception("生产订单新增/修改操作失败！");

                response.id = head.ID;
                response.success = true;
                response.code = 200;
                response.msg = "操作成功";
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 生产订单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse MOQuery(MOQueryView request)
        {

            PubResponse response = new PubResponse();
            try
            {
                if (request == null)
                    throw new Exception("查询参数不能为空！");
                string sql2Head = "1=1";
                if (!string.IsNullOrEmpty(request.DocNo))
                    sql2Head += string.Format(" and DocNo='{0}'", request.DocNo);

                int total = 0;

                int Current = 1, Size = 10;
                if (!string.IsNullOrEmpty(request.Current))
                    int.TryParse(request.Current, out Current);
                if (!string.IsNullOrEmpty(request.Size))
                    int.TryParse(request.Size, out Size);

                if (Current <= 0)
                    Current = 1;
                if (Size <= 0)
                    Size = 10;

                var lst = repository.Context.Queryable<MO>().Includes(q => q.MOLines).Where(sql2Head).ToOffsetPage(Current, Size, ref total).ToList();
                List<MOListView> list = new List<MOListView>();
                int LineNum = 1;
                foreach (var item in lst)
                {
                    string orgName = null, MoDeptName = null, CompleteWhName = null;
                    if (item.Org > 0)
                    {
                        var org = repository.Context.Queryable<Organization>().Where(q => q.ID == item.Org).ToList()?.FirstOrDefault();
                        orgName = org?.Name;
                    }
                    if (item.MoDept > 0)
                    {
                        var obj = repository.Context.Queryable<Department>().Where(q => q.ID == item.MoDept).ToList()?.FirstOrDefault();
                        MoDeptName = obj?.Name;
                    }
                    if (item.CompleteWh > 0)
                    {
                        var obj = repository.Context.Queryable<Wh>().Where(q => q.ID == item.CompleteWh).ToList()?.FirstOrDefault();
                        CompleteWhName = obj?.Name;
                    }
                    foreach (var item2 in item.MOLines)
                    {
                        MOListView line = new MOListView();
                        line.LineNum = LineNum.ToString();
                        line.id = item2.ID;
                        line.MainID = item.ID;
                        line.DocTypeName = item.DocType;
                        line.Status = item.Status.ToString();
                        if (line.Status == "0")
                            line.StatusName = "开立";
                        else if (line.Status == "1")
                            line.StatusName = "核准中";
                        else if (line.Status == "2")
                            line.StatusName = "已核准";
                        line.DocNo = item.DocNo;
                        line.BomVersion = item2.BomVersion;
                        line.OrgName = orgName;
                        line.MoDeptName = MoDeptName;
                        line.MoQty = item2.MoQty;
                        var obj = repository.Context.Queryable<Item>().Where(q => q.ID == item2.Item).ToList()?.FirstOrDefault();
                        if (obj != null)
                        {
                            line.ItemCode = obj.Code;
                            line.ItemName = obj.Name;
                            line.ItemSpecs = obj.SPECS;
                        }
                        if (item2.MoUom > 0)
                        {
                            var obj2 = repository.Context.Queryable<UOM>().Where(q => q.ID == item2.MoUom).ToList()?.FirstOrDefault();
                            if (obj2 != null)
                            {
                                line.MoUomName = obj2.Name;
                            }
                        }
                        line.CompleteWhName = CompleteWhName;
                        list.Add(line);
                        LineNum++;
                    }
                }


                response.data = JArray.FromObject(list);
                response.total = total;
                response.success = true;
                response.code = 200;
                response.msg = "操作成功";
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 根据生产订单ID查询生产订单信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse MOQueryByID(MOLineQueryView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request==null)
                    throw new Exception("查询参数ID不能为空！");

                var lst = repository.Context.Queryable<MO>().Includes(q => q.MOLines).Where(q => q.ID.ToString() == request.MainID).ToList();
                if(lst==null||lst.Count<=0)
                    throw new Exception(string.Format("ID为【{0}】的生产订单不存在！", request.MainID));

                List<MOView> list = new List<MOView>();
                MO item = lst.FirstOrDefault();
                if(item == null)
                    throw new Exception(string.Format("ID为【{0}】的生产订单不存在！", request.MainID));
                MOView headDTO = new MOView();
                list.Add(headDTO);
                headDTO.id = item.ID;
                headDTO.SysVersion = item.SysVersion;
                headDTO.CreatedBy = item.CreatedBy;
                headDTO.CreatedTime = item.CreatedTime;
                headDTO.ModifiedBy = item.ModifiedBy;
                headDTO.ModifiedTime = item.ModifiedTime;
                headDTO.DocType=item.DocType;
                headDTO.Status=item.Status.ToString();
                if(headDTO.Status=="0")
                headDTO.StatusName = "开立";
                else if (headDTO.Status == "1")
                    headDTO.StatusName = "核准中";
                else if (headDTO.Status == "2")
                    headDTO.StatusName = "已核准";

                if (item.Org > 0)
                {
                    var org = repository.Context.Queryable<Organization>().Where(q => q.ID == item.Org).ToList()?.FirstOrDefault();
                    if (org != null)
                    {
                        headDTO.Org = org.ID.ToString();
                        headDTO.OrgCode = org.Code;
                        headDTO.OrgName = org.Name;
                    }
                }
                headDTO.DocNo = item.DocNo;
                if (item.StartDate != DateTime.MinValue)
                    headDTO.StartDate = item.StartDate.ToString("yyyy-MM-dd");

                headDTO.BusinessDate = item.BusinessDate.ToString("yyyy-MM-dd");
                if (item.MoDept > 0)
                {
                    var obj = repository.Context.Queryable<Department>().Where(q => q.ID == item.MoDept).ToList()?.FirstOrDefault();
                    if (obj != null)
                    {
                        headDTO.MoDept = obj.ID;
                        headDTO.MoDeptCode = obj.Code;
                        headDTO.MoDeptName = obj.Name;
                    }
                }
                if (item.BusinessPerson > 0)
                {
                    var obj = repository.Context.Queryable<Operators>().Where(q => q.ID == item.BusinessPerson).ToList()?.FirstOrDefault();
                    if (obj != null)
                    {
                        headDTO.BusinessPerson = obj.ID;
                        headDTO.BusinessPersonCode = obj.Code;
                        headDTO.BusinessPersonName = obj.Name;
                    }
                }
                if (item.CompleteDate != DateTime.MinValue)
                    headDTO.CompleteDate = item.CompleteDate.ToString("yyyy-MM-dd");

                if (item.CompleteWh > 0)
                {
                    var obj = repository.Context.Queryable<Wh>().Where(q => q.ID == item.CompleteWh).ToList()?.FirstOrDefault();
                    if (obj != null)
                    {
                        headDTO.CompleteWh = obj.ID;
                        headDTO.CompleteWhCode = obj.Code;
                        headDTO.CompleteWhName = obj.Name;
                    }
                }
                headDTO.Memo = item.Memo;
                headDTO.Status = item.Status.ToString();
                headDTO.Lines = new List<MOLineView>();
                foreach (var item2 in item.MOLines)
                {
                    MOLineView line = new MOLineView();
                    line.LineNum = item2.LineNum.ToString();
                    line.id = item2.ID;
                    line.BomVersion = item2.BomVersion;

                    line.CreatedBy = item2.CreatedBy;
                    line.CreatedTime = item2.CreatedTime;
                    line.ModifiedBy = item2.ModifiedBy;
                    line.ModifiedTime = item2.ModifiedTime;
                    line.SysVersion = item2.SysVersion;

                    var obj = repository.Context.Queryable<Item>().Where(q => q.ID == item2.Item).ToList()?.FirstOrDefault();
                    if (obj != null)
                    {
                        line.Item=obj.ID;
                        line.ItemCode = obj.Code;
                        line.ItemName = obj.Name;
                        line.ItemSpecs = obj.SPECS;
                    }
                    line.MoQty = item2.MoQty.ToString();
                    if (item2.MoUom > 0)
                    {
                        var obj2 = repository.Context.Queryable<UOM>().Where(q => q.ID == item2.MoUom).ToList()?.FirstOrDefault();
                        if (obj2 != null)
                        {
                            line.MoUom = obj2.ID;
                            line.MoUomCode = obj2.Code;
                            line.MoUomName = obj2.Name;
                        }
                    }
                    if (item2.StartDate != DateTime.MinValue)
                        line.StartDate = item2.StartDate.ToString("yyyy-MM-dd");

                    if (item2.CompleteDate != DateTime.MinValue)
                        line.CompleteDate = item2.CompleteDate.ToString("yyyy-MM-dd");

                    line.SrcDocType = item2.SrcDocType;
                    line.SrcDocNo = item2.SrcDocNo;

                    if (item2.ActualStartDate != DateTime.MinValue)
                        line.ActualStartDate = item2.ActualStartDate.ToString("yyyy-MM-dd");
                    if (item2.ActualCompleteDate != DateTime.MinValue)
                        line.ActualCompleteDate = item2.ActualCompleteDate.ToString("yyyy-MM-dd");

                    line.BomVersion = item2.BomVersion;
                    line.Routing = item2.Routing;

                    if (item2.LotMaster > 0)
                    {
                        var obj2 = repository.Context.Queryable<LotMaster>().Where(q => q.ID == item2.LotMaster).ToList()?.FirstOrDefault();
                        if (obj2 != null)
                        {
                            line.LotCode = obj2.LotCode;
                        }
                    }
                    headDTO.Lines.Add(line);
                }

                response.data = JArray.FromObject(list);
                response.success = true;
                response.code = 200;
                response.msg = "操作成功";
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
            }
            return response;
        }


        /// <summary>
        /// 生产订单删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse MODelete(MODelView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request == null)
                    throw new Exception("参数不能为空！");

                if (request.MainIDs == null || request.MainIDs.Count <= 0)
                    throw new Exception("ID集合不能为空！");
                string sql2 = string.Format(" ID in ({0})", string.Join(",", request.MainIDs));
                var lst = repository.Context.Queryable<MO>().Where(sql2).ToList();
                if (lst != null && lst.Count > 0)
                    repository.Context.DeleteNav(lst).Include(q => q.MOLines).ExecuteCommand();

                response.success = true;
                response.code = 200;
                response.msg = "操作成功";
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 生产订单提交
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse MOSubmit(MODelView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request == null)
                    throw new Exception("参数不能为空！");
                if (request.MainIDs == null || request.MainIDs.Count <= 0)
                    throw new Exception("ID集合不能为空！");
                string sql = string.Format(" ID in ({0}) and Status=0", string.Join(",", request.MainIDs));
                var list = repository.Context.Queryable<MO>().Where(sql
                    ).ToList();

                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        item.Status = 1;
                    }
                    repository.Context.Updateable(list).ExecuteCommand();
                }
                response.success = true;
                response.code = 200;
                response.msg = "操作成功";
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 生产订单审核
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse MOApprove(MODelView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request == null)
                    throw new Exception("参数不能为空！");
                if (request.MainIDs == null || request.MainIDs.Count <= 0)
                    throw new Exception("ID集合不能为空！");
                string sql = string.Format(" ID in ({0}) and Status=1", string.Join(",", request.MainIDs));
                var list = repository.Context.Queryable<MO>().Where(sql
                    ).ToList();

                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        item.Status = 2;
                    }
                    repository.Context.Updateable(list).ExecuteCommand();
                }
                response.success = true;
                response.code = 200;
                response.msg = "操作成功";
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
            }
            return response;
        }


        /// <summary>
        /// 生产订单弃审
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse MOUnApprove(MODelView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request == null)
                    throw new Exception("参数不能为空！");
                if (request.MainIDs == null || request.MainIDs.Count <= 0)
                    throw new Exception("ID集合不能为空！");
                string sql = string.Format(" ID in ({0}) and Status=2", string.Join(",", request.MainIDs));
                var list = repository.Context.Queryable<MO>().Where(sql
                    ).ToList();

                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        item.Status = 0;
                    }
                    repository.Context.Updateable(list).ExecuteCommand();
                }
                response.success = true;
                response.code = 200;
                response.msg = "操作成功";
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
            }
            return response;
        }
    }
}

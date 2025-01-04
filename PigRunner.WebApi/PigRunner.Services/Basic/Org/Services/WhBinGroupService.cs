using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using PigRunner.DTO.Basic;
using PigRunner.Entitys.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Basic;
using PigRunner.Services.Basic.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Basic.Services
{
    /// <summary>
    /// 库区
    /// </summary>
    public class WhBinGroupService : IWhBinGroupService
    {
        private WhBinGroupRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public WhBinGroupService(WhBinGroupRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 库区增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionWhBinGroup(WhBinGroupView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request.OptType.Equals("AddWhBinGroup") || request.OptType.Equals("UpdateWhBinGroup"))
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    if (string.IsNullOrEmpty(request.Name))
                        throw new Exception("名称不能为空！");

                    WhBinGroup head = repository.GetFirst(q => q.Code == request.Code);

                    if (request.OptType.Equals("AddWhBinGroup"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("编码为【{0}】的库区已存在，不能再新增！", request.Code));
                        else
                            head = WhBinGroup.Create();
                    }
                    else
                    {
                        if (request.ID <= 0)
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID == request.ID);
                        if (head == null)
                            throw new Exception(string.Format("ID为【{0}】的库区不存在，请检查！", request.ID));

                        head.ModifiedTime = DateTime.Now;
                    }

                    WhBinGroup oldHead = repository.GetFirst(q => (q.Code == request.Code || q.Name == request.Name) && q.ID != head.ID);
                    if (oldHead != null)
                        throw new Exception(string.Format("编码为【{0}】或者名称为【{1}】的库区已存在，请检查！", request.Code, request.Name));

                    head.Code = request.Code;
                    head.Name = request.Name;
                    response.id = head.ID;
                    head.Remark = request.Remark;
                    head.IsEffective = request.IsEffective ? 1 : 0;

                    long OrgID = 0;
                    //根据编码查找实体
                    if (!string.IsNullOrEmpty(request.OrgCode))
                    {
                        var lg = repository.Context.Queryable<Organization>().Where(q => q.Code == request.OrgCode)?.First();
                        if (lg == null)
                            throw new Exception(string.Format("编码为【{0}】的组织不存在，请检查！", request.OrgCode));
                        OrgID = lg.ID;
                    }
                    head.Org = OrgID;

                    long WhID = 0;
                    //根据编码查找实体
                    if (!string.IsNullOrEmpty(request.WhCode))
                    {
                        var lg = repository.Context.Queryable<Wh>().Where(q => q.Code == request.WhCode)?.First();
                        if (lg == null)
                            throw new Exception(string.Format("编码为【{0}】的仓库不存在，请检查！", request.WhCode));
                        WhID = lg.ID;
                    }
                    head.Wh = WhID;

                   
                    head.Area = request.Area;
                    head.Volume = request.Volume;

                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("库区新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelWhBinGroup"))
                {
                    if (string.IsNullOrEmpty(request.Code) && (request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("编码不能为空！");
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        WhBinGroup head = repository.GetFirst(q => q.Code == request.Code);
                        if (head == null)
                            throw new Exception(string.Format("编码为【{0}】的库区不存在！", request.Code));

                        bool isSuccess = repository.Delete(head);
                        if (!isSuccess)
                            throw new Exception("删除失败！");
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            WhBinGroup head = repository.GetFirst(q => q.Code == item);
                            if (head == null)
                                throw new Exception(string.Format("编码为【{0}】的库区不存在！", request.Code));

                            bool isSuccess = repository.Delete(head);
                            if (!isSuccess)
                                throw new Exception("删除失败！");
                        }
                    }
                }
                else if (request.OptType.Equals("QueryWhBinGroup"))
                {
                    int total = 0;
                    List<WhBinGroupView> list = new List<WhBinGroupView>();
                    var lst = repository.AsQueryable().ToOffsetPage(request.Current, request.Size, ref total);
                    long WHID = 0;
                    if(!string.IsNullOrEmpty(request.WhCode))
                    {
                        var lg = repository.Context.Queryable<Wh>().Where(q => q.Code == request.WhCode)?.First();
                        if (lg == null)
                            throw new Exception(string.Format("编码为【{0}】的仓库不存在，请检查！", request.WhCode));
                        WHID = lg.ID;
                    }

                    if (!string.IsNullOrEmpty(request.Code) && !string.IsNullOrEmpty(request.Name)&& WHID>0)
                        lst = repository.AsQueryable().Where(q => q.Code.Contains(request.Code) && q.Name.Contains(request.Name) && q.Wh == WHID).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.Code) && !string.IsNullOrEmpty(request.Name))
                        lst = repository.AsQueryable().Where(q => q.Code.Contains(request.Code) && q.Name.Contains(request.Name)).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.Code))
                        lst = repository.AsQueryable().Where(q => q.Code.Contains(request.Code)).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.Name))
                        lst = repository.AsQueryable().Where(q => q.Name.Contains(request.Name)).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (WHID > 0)
                        lst = repository.AsQueryable().Where(q => q.Wh == WHID).ToOffsetPage(request.Current, request.Size, ref total);
                    if (lst != null && lst.Count > 0)
                    {
                        int lineNum = 1;
                        foreach (var item in lst)
                        {
                            WhBinGroupView dto = SetValue(item);
                            dto.LineNum = lineNum;
                            list.Add(dto);
                            lineNum += 1;
                        }
                    }
                    response.data = JArray.FromObject(list);
                    response.total = total;
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

        private WhBinGroupView SetValue(WhBinGroup item)
        {
            WhBinGroupView dto = new WhBinGroupView();
            dto.Code = item.Code;
            dto.Name = item.Name;
            dto.Remark = item.Remark;
            dto.ID = item.ID;
            dto.IsEffective = item.IsEffective == 1 ? true : false;
            if (dto.IsEffective)
                dto.Effective = "启用";
            else
                dto.Effective = "停用";

          
            if (item.Org > 0)
            {
                var lg = repository.Context.Queryable<Organization>().Where(q => q.ID == item.Org)?.First();
                if (lg != null)
                {
                    dto.OrgCode = lg.Code;
                    dto.OrgName = lg.Name;
                }
            }

            if (item.Wh > 0)
            {
                var lg = repository.Context.Queryable<Wh>().Where(q => q.ID == item.Wh)?.First();
                if (lg != null)
                {
                    dto.WhCode = lg.Code;
                    dto.WhName = lg.Name;
                }
            }
            dto.Area = item.Area;
            dto.Volume = item.Volume;
            return dto;
        }

        public PubResponse UploadWhBinGroup(MemoryStream stream)
        {
            PubResponse response = new PubResponse();
            try
            {
                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    if (package.Workbook == null || package.Workbook.Worksheets == null || package.Workbook.Worksheets.Count <= 0)
                        throw new Exception("Excel内容不能为空！");
                    var lst = package.Workbook.Worksheets.Cast<ExcelWorksheet>().Where(q => q.Dimension != null).ToList();
                    if (lst == null || lst.Count <= 0)
                        throw new Exception("Excel的sheet内容不能为空！");
                    List<WhBinGroup> lstCtry = new List<WhBinGroup>();
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    foreach (var worksheet in lst)
                    {
                        var rowCount = worksheet.Dimension.Rows;//行
                        var columnCount = worksheet.Dimension.Columns;//列
                        if (rowCount < 2)
                            throw new Exception(string.Format("Sheet[{0}]数据不能为空！", worksheet.Name));
                        if (columnCount < 11)
                            throw new Exception(string.Format("Sheet[{0}]数据列不能为空！", worksheet.Name));

                        for (int row = 2; row <= rowCount; row++)
                        {

                            //第1列：编码
                            string Code = string.Empty;
                            if (worksheet.GetValue(row, 1) != null)
                                Code = worksheet.GetValue(row, 1).ToString();
                            //第2列：名称
                            string Name = string.Empty;
                            if (worksheet.GetValue(row, 2) != null)
                                Name = worksheet.GetValue(row, 2).ToString();


                            long WhID = 0;
                            //第3列：仓库
                            string WhName = string.Empty;
                            if (worksheet.GetValue(row, 3) != null)
                                WhName = worksheet.GetValue(row, 3).ToString();

                            if (!string.IsNullOrEmpty(WhName))
                            {
                                var dept = repository.Context.Queryable<Wh>().Where(q => q.Name == WhName || q.Code == WhName).ToList()?.FirstOrDefault();
                                if (dept == null)
                                    throw new Exception(string.Format("编码/名称为【{0}】的仓库不存在！", WhName));
                                WhID = dept.ID;
                            }

                            //第4列：组织
                            string OrgCode = string.Empty;
                            if (worksheet.GetValue(row, 4) != null)
                                OrgCode = worksheet.GetValue(row, 4).ToString();
                            long OrgID = 0;
                            if (!string.IsNullOrEmpty(OrgCode))
                            {
                                var lg = repository.Context.Queryable<Organization>().Where(q => q.Name == OrgCode || q.Code == OrgCode)?.First();
                                if (lg != null)
                                    OrgID = lg.ID;
                            }
                            //第5列：面积
                            string strArea = string.Empty;
                            if (worksheet.GetValue(row, 5) != null)
                                strArea = worksheet.GetValue(row, 5).ToString();
                            decimal Area = 0m;
                            decimal.TryParse(strArea, out Area);

                            //第6列：容积
                            string strVolume = string.Empty;
                            if (worksheet.GetValue(row, 6) != null)
                                strVolume = worksheet.GetValue(row, 6).ToString();
                            decimal Volume = 0m;
                            decimal.TryParse(strVolume, out Volume);

                            //第7列：状态
                            string Effective = string.Empty;
                            if (worksheet.GetValue(row, 7) != null)
                                Effective = worksheet.GetValue(row, 7).ToString();

                            int IsEffective = 0;
                            if (!string.IsNullOrEmpty(Effective) && (Effective.Equals("生效") || Effective.Equals("1")))
                                IsEffective = 1;

                            //第8列：备注
                            string Remark = string.Empty;
                            if (worksheet.GetValue(row, 8) != null)
                                Remark = worksheet.GetValue(row, 8).ToString();


                            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name))
                                continue;
                            if (dic.ContainsKey(Code) || dic.ContainsValue(Name))
                                throw new Exception(string.Format("Sheet[{0}]编码或名称已重复，请检查！", worksheet.Name));
                            dic.Add(Code, Name);
                            WhBinGroup head = repository.GetFirst(q => q.Code == Code || q.Name == Name);
                            if (head != null)
                                throw new Exception(string.Format("编码为【{0}】的库区已存在！", Code));
                            head = WhBinGroup.Create();
                            head.Code = Code;
                            head.Name = Name;
                            head.Wh = WhID;
                            head.Remark = Remark;
                            head.IsEffective = IsEffective;
                            head.Area = Area;
                            head.Volume = Volume;
                            head.Org = OrgID;
                            lstCtry.Add(head);
                        }
                    }
                    int rtn = repository.Context.Insertable(lstCtry).ExecuteCommand();
                    if (rtn != lstCtry.Count)
                        throw new Exception("写入数据失败！");
                }
                response.code = 200;
                response.success = true;
                response.msg = "导入成功！";
            }
            catch (Exception ex)
            {
                response.code = 400;
                response.msg = ex.Message;
            }
            return response;
        }
    }

}


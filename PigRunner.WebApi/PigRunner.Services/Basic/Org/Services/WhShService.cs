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

    public class WhShService : IWhShService
    {
        private WhShRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public WhShService(WhShRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 货位增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionWhSh(WhShView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request == null)
                    throw new Exception("参数不能为空！");

                if (request.OptType.Equals("AddWhSh") || request.OptType.Equals("UpdateWhSh"))
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    if (string.IsNullOrEmpty(request.Name))
                        throw new Exception("名称不能为空！");

                    WhSh head = repository.GetFirst(q => q.Code == request.Code);

                    if (request.OptType.Equals("AddWhSh"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("编码为【{0}】的货位已存在，不能再新增！", request.Code));
                        else
                            head = WhSh.Create();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(request.ID))
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID.ToString() == request.ID);
                        if (head == null)
                            throw new Exception(string.Format("ID为【{0}】的货位不存在，请检查！", request.ID));

                        head.ModifiedTime = DateTime.Now;
                    }

                    WhSh oldHead = repository.GetFirst(q => (q.Code == request.Code || q.Name == request.Name) && q.ID != head.ID);
                    if (oldHead != null)
                        throw new Exception(string.Format("编码为【{0}】或者名称为【{1}】的货位已存在，请检查！", request.Code, request.Name));

                    head.Code = request.Code;
                    head.Name = request.Name;
                    response.id = head.ID;
                    head.Remark = request.Remark;
                    head.IsEffective =bool.TryParse( request.IsEffective,out bool IsEffective) ? 1 : 0;
                    head.IsWhSh = bool.TryParse(request.IsWhSh, out bool IsWhSh) ? 1 : 0;


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

                    long WHID = 0;
                    //根据编码查找实体
                    if (!string.IsNullOrEmpty(request.WhCode))
                    {
                        var lg = repository.Context.Queryable<Wh>().Where(q => q.Code == request.WhCode)?.First();
                        if (lg == null)
                            throw new Exception(string.Format("编码为【{0}】的仓库不存在，请检查！", request.WhCode));
                        WHID = lg.ID;
                    }
                    head.Wh = WHID;

                    long WhBinGroupID = 0;
                    //根据编码查找实体
                    if (!string.IsNullOrEmpty(request.WhBinGroupCode))
                    {
                        var lg = repository.Context.Queryable<WhBinGroup>().Where(q => q.Code == request.WhBinGroupCode)?.First();
                        if (lg == null)
                            throw new Exception(string.Format("编码为【{0}】的库区不存在，请检查！", request.WhBinGroupCode));
                        WhBinGroupID = lg.ID;
                    }
                    head.WhBinGroup = WhBinGroupID;
                    decimal.TryParse(request.Area, out decimal Area);
                    head.Area =Area;

                    decimal.TryParse(request.Volume, out decimal Volume);
                    head.Volume = Volume;

                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("货位新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelWhSh"))
                {
                    if (string.IsNullOrEmpty(request.Code) && (request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("编码不能为空！");
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        WhSh head = repository.GetFirst(q => q.Code == request.Code);
                        if (head == null)
                            throw new Exception(string.Format("编码为【{0}】的货位不存在！", request.Code));

                        bool isSuccess = repository.Delete(head);
                        if (!isSuccess)
                            throw new Exception("删除失败！");
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            WhSh head = repository.GetFirst(q => q.Code == item);
                            if (head == null)
                                throw new Exception(string.Format("编码为【{0}】的货位不存在！", request.Code));

                            bool isSuccess = repository.Delete(head);
                            if (!isSuccess)
                                throw new Exception("删除失败！");
                        }
                    }
                }
                else if (request.OptType.Equals("QueryWhSh"))
                {
                    int total = 0;
                    List<WhShView> list = new List<WhShView>();
                    long WhID = 0;
                    long WHbinG = 0;
                    if(!string.IsNullOrEmpty(request.WhCode))
                    {
                        var lg = repository.Context.Queryable<Wh>().Where(q => q.Code == request.WhCode)?.First();
                        if (lg == null)
                            throw new Exception(string.Format("编码为【{0}】的仓库不存在，请检查！", request.WhCode));
                        WhID = lg.ID;
                    }

                    if (!string.IsNullOrEmpty(request.WhBinGroupCode))
                    {
                        var lg = repository.Context.Queryable<WhBinGroup>().Where(q => q.Code == request.WhBinGroupCode)?.First();
                        if (lg == null)
                            throw new Exception(string.Format("编码为【{0}】的库区不存在，请检查！", request.WhBinGroupCode));
                        WHbinG = lg.ID;
                    }

                    string sql = "1=1";
                    if (!string.IsNullOrEmpty(request.Code))
                        sql += string.Format(" and Code like '%{0}%' ", request.Code);
                    if (!string.IsNullOrEmpty(request.Name))
                        sql += string.Format(" and Name like '%{0}%' ", request.Name);

                    if (WHbinG>0)
                        sql += string.Format(" and WhBinGroup={0} ", WHbinG);
                    if (WhID > 0)
                        sql += string.Format(" and Wh={0} ", WhID);

                    int.TryParse(request.Current, out int Current);
                    int.TryParse(request.Size, out int Size);
                    if (Current <= 0)
                        Current = 10;
                    if (Size <= 0)
                        Size = 1;


                    var lst = repository.AsQueryable().Where(sql).ToOffsetPage(Current, Size, ref total);

                    if (lst != null && lst.Count > 0)
                    {
                        int lineNum = 1;
                        foreach (var item in lst)
                        {
                            WhShView dto = SetValue(item);
                            dto.LineNum = lineNum.ToString();
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

        private WhShView SetValue(WhSh item)
        {
            WhShView dto = new WhShView();
            dto.Code = item.Code;
            dto.Name = item.Name;
            dto.Remark = item.Remark;
            dto.ID = item.ID.ToString();
            dto.IsEffective = false.ToString();
            if (item.IsEffective == 1)
            { dto.Effective = "启用"; dto.IsEffective = true.ToString(); }
            else
                dto.Effective = "停用";

            dto.IsWhSh = false.ToString();
            if (item.IsWhSh == 1)
            { dto.WhSh = "是"; dto.IsWhSh = true.ToString(); }
            else
                dto.WhSh = "否";
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

            //根据编码查找实体
            if (item.WhBinGroup > 0)
            {
                var lg = repository.Context.Queryable<WhBinGroup>().Where(q => q.ID == item.WhBinGroup)?.First();
                if (lg != null)
                {
                    dto.WhBinGroupCode = lg.Code;
                    dto.WhBinGroupName = lg.Name;
                }
            }
            dto.Area = item.Area.ToString();
            dto.Volume = item.Volume.ToString();
            return dto;
        }

        public PubResponse UploadWhSh(MemoryStream stream)
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
                    List<WhSh> lstCtry = new List<WhSh>();
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

                            //第3列：仓库
                            string WHCode = string.Empty;
                            if (worksheet.GetValue(row, 3) != null)
                                WHCode = worksheet.GetValue(row, 3).ToString();
                            long WhID = 0;
                            if (!string.IsNullOrEmpty(WHCode))
                            {
                                var lg = repository.Context.Queryable<Wh>().Where(q => q.Name == WHCode || q.Code == WHCode)?.First();
                                if (lg == null)
                                    throw new Exception(string.Format("编码/名称为【{0}】的仓库不存在！", WHCode));
                                WhID = lg.ID;
                            }

                            //第4列：库区
                            string WhBinGroupCode = string.Empty;
                            if (worksheet.GetValue(row, 4) != null)
                                WhBinGroupCode = worksheet.GetValue(row, 4).ToString();
                            long WhBinGroupID = 0;
                            if (!string.IsNullOrEmpty(WhBinGroupCode))
                            {
                                var lg = repository.Context.Queryable<WhBinGroup>().Where(q => q.Name == WhBinGroupCode || q.Code == WhBinGroupCode)?.First();
                                if (lg == null)
                                    throw new Exception(string.Format("编码/名称为【{0}】的库区不存在！", WhBinGroupCode));
                                WhBinGroupID = lg.ID;
                            }

                            //第5列：是否拣货货位
                            string IsPurerName = string.Empty;
                            if (worksheet.GetValue(row, 5) != null)
                                IsPurerName = worksheet.GetValue(row, 5).ToString();
                            int IsStoreBin = 0;
                            if (!string.IsNullOrEmpty(IsPurerName) && (IsPurerName.Equals("是") || IsPurerName.Equals("1")))
                                IsStoreBin = 1;

                            //第6列：组织
                            string OrgCode = string.Empty;
                            if (worksheet.GetValue(row, 6) != null)
                                OrgCode = worksheet.GetValue(row, 6).ToString();
                            long OrgID = 0;
                            if (!string.IsNullOrEmpty(OrgCode))
                            {
                                var lg = repository.Context.Queryable<Organization>().Where(q => q.Name == OrgCode || q.Code == OrgCode)?.First();
                                if (lg != null)
                                    OrgID = lg.ID;
                            }
                            //第7列：面积
                            string strArea = string.Empty;
                            if (worksheet.GetValue(row, 7) != null)
                                strArea = worksheet.GetValue(row, 7).ToString();
                            decimal Area = 0m;
                            decimal.TryParse(strArea, out Area);

                            //第8列：容积
                            string strVolume = string.Empty;
                            if (worksheet.GetValue(row, 8) != null)
                                strVolume = worksheet.GetValue(row, 8).ToString();
                            decimal Volume = 0m;
                            decimal.TryParse(strVolume, out Volume);

                            //第9列：状态
                            string Effective = string.Empty;
                            if (worksheet.GetValue(row, 9) != null)
                                Effective = worksheet.GetValue(row, 9).ToString();

                            int IsEffective = 0;
                            if (!string.IsNullOrEmpty(Effective) && (Effective.Equals("生效") || Effective.Equals("1")))
                                IsEffective = 1;

                            //第11列：备注
                            string Remark = string.Empty;
                            if (worksheet.GetValue(row, 11) != null)
                                Remark = worksheet.GetValue(row, 11).ToString();


                            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name))
                                continue;
                            if (dic.ContainsKey(Code) || dic.ContainsValue(Name))
                                throw new Exception(string.Format("Sheet[{0}]编码或名称已重复，请检查！", worksheet.Name));
                            dic.Add(Code, Name);
                            WhSh head = repository.GetFirst(q => q.Code == Code || q.Name == Name);
                            if (head != null)
                                throw new Exception(string.Format("编码为【{0}】的货位已存在！", Code));
                            head = WhSh.Create();
                            head.Code = Code;
                            head.Name = Name;
                            head.IsWhSh = IsStoreBin;
                            head.Remark = Remark;
                            head.IsEffective = IsEffective;
                            head.Wh = WhID;
                            head.WhBinGroup = WhBinGroupID;
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


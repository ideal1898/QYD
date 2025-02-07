using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using PigRunner.DTO.Basic.Gop;
using PigRunner.Entitys.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Basic.Gop;
using PigRunner.Services.Basic.Gop.IServices;

namespace PigRunner.Services.Basic.Gop.Services
{
    public class UOMService : IUOMService
    {
        private UOMRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public UOMService(UOMRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 计量单位增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionUOM(UOMView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request == null)
                    throw new Exception("参数不能为空！");

                if (request.OptType.Equals("AddUOM") || request.OptType.Equals("UpdateUOM"))
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    if (string.IsNullOrEmpty(request.Name))
                        throw new Exception("名称不能为空！");

                    UOM head = repository.GetFirst(q => q.Code == request.Code);

                    if (request.OptType.Equals("AddUOM"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("编码为【{0}】的计量单位已存在，不能再新增！", request.Code));
                        else
                            head = UOM.Create();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(request.ID))
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID.ToString() == request.ID);
                        if (head == null)
                            throw new Exception(string.Format("ID为【{0}】的计量单位不存在，请检查！", request.ID));

                        head.ModifiedTime = DateTime.Now;
                    }

                    UOM oldHead = repository.GetFirst(q => (q.Code == request.Code || q.Name == request.Name) && q.ID != head.ID);
                    if (oldHead != null)
                        throw new Exception(string.Format("编码为【{0}】或者名称为【{1}】的计量单位已存在，请检查！", request.Code, request.Name));

                    head.Code = request.Code;
                    head.Name = request.Name;
                    response.id = head.ID;
                    head.Remark = request.Remark;

                    int IsBase =bool.TryParse( request.IsBase,out bool IsBase2) ? 1 : 0;
                    head.IsBase = IsBase;

                    decimal.TryParse(request.RatioToBase, out decimal RatioToBase);
                    head.RatioToBase = RatioToBase;

                    int.TryParse(request.RoundWay, out int RoundWay);
                    head.RoundWay =RoundWay;

                    decimal.TryParse(request.UomPrecision, out decimal UomPrecision);
                    head.UomPrecision = UomPrecision;

                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("计量单位新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelUOM"))
                {
                    if (string.IsNullOrEmpty(request.Code) && (request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("编码不能为空！");
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        UOM head = repository.GetFirst(q => q.Code == request.Code);
                        if (head == null)
                            throw new Exception(string.Format("编码为【{0}】的计量单位不存在！", request.Code));

                        bool isSuccess = repository.Delete(head);
                        if (!isSuccess)
                            throw new Exception("删除失败！");
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            UOM head = repository.GetFirst(q => q.Code == item);
                            if (head == null)
                                throw new Exception(string.Format("编码为【{0}】的计量单位不存在！", request.Code));

                            bool isSuccess = repository.Delete(head);
                            if (!isSuccess)
                                throw new Exception("删除失败！");
                        }
                    }
                }
                else if (request.OptType.Equals("QueryUOM"))
                {
                    int total = 0;
                    List<UOMView> list = new List<UOMView>();
                    string sql = "1=1";
                    if (!string.IsNullOrEmpty(request.Code))
                        sql += string.Format(" and Code like '%{0}%' ", request.Code);
                    if (!string.IsNullOrEmpty(request.Name))
                        sql += string.Format(" and Name like '%{0}%' ", request.Name);

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
                            UOMView dto = SetValue(item);
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

        private UOMView SetValue(UOM item)
        {
            UOMView dto = new UOMView();
            dto.Code = item.Code;
            dto.Name = item.Name;
            dto.Remark = item.Remark;
            dto.ID = item.ID.ToString();
            dto.IsBase = false.ToString();
            if (item.IsBase == 1)
            { dto.IsBaseName = "是"; dto.IsBase = true.ToString(); }
            else
                dto.IsBaseName = "否";
            dto.RatioToBase = item.RatioToBase.ToString();
            dto.RoundWay = item.RoundWay.ToString();
            if (item.RoundWay == 1)
                dto.RoundWayName = "四舍五入";
            else if (item.RoundWay == 2)
                dto.RoundWayName = "舍位";
            else if (item.RoundWay == 3)
                dto.RoundWayName = "入位";
            dto.UomPrecision = item.UomPrecision.ToString();

            return dto;
        }

        public PubResponse UploadUOM(MemoryStream stream)
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
                    List<UOM> lstCtry = new List<UOM>();
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    foreach (var worksheet in lst)
                    {
                        var rowCount = worksheet.Dimension.Rows;//行
                        var columnCount = worksheet.Dimension.Columns;//列
                        if (rowCount < 2)
                            throw new Exception(string.Format("Sheet[{0}]数据不能为空！", worksheet.Name));
                        if (columnCount < 5)
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



                            //第3列：是否基准单位
                            string Effective = string.Empty;
                            if (worksheet.GetValue(row, 3) != null)
                                Effective = worksheet.GetValue(row, 3).ToString();

                            //第4列：转换系数
                            decimal RatioToBase = 0;
                            if (worksheet.GetValue(row, 4) != null)
                                decimal.TryParse(worksheet.GetValue(row, 4).ToString(), out RatioToBase);

                            //第5列：转换系数
                            int RoundWay = 0;
                            if (worksheet.GetValue(row, 5) != null)
                            {
                                string RtName= worksheet.GetValue(row, 5).ToString();
                                if(RtName.Equals("四舍五入"))
                                    RoundWay = 1;
                                else if (RtName.Equals("舍位"))
                                    RoundWay = 2;
                                else if (RtName.Equals("入位"))
                                    RoundWay = 3;
                            }
                            //第6列：精度
                            decimal UomPrecision = 0;
                            if (worksheet.GetValue(row, 6) != null)
                                decimal.TryParse(worksheet.GetValue(row, 6).ToString(), out UomPrecision);

                            //第5列：备注
                            string Remark = string.Empty;
                            if (worksheet.GetValue(row, 7) != null)
                                Remark = worksheet.GetValue(row, 7).ToString();

                            int IsBase = 0;
                            if (!string.IsNullOrEmpty(Effective) && (Effective.Equals("生效") || Effective.Equals("1")))
                                IsBase = 1;

                            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name))
                                continue;
                            if (dic.ContainsKey(Code) || dic.ContainsValue(Name))
                                throw new Exception(string.Format("Sheet[{0}]编码或名称已重复，请检查！", worksheet.Name));
                            dic.Add(Code, Name);
                            UOM head = repository.GetFirst(q => q.Code == Code || q.Name == Name);
                            if (head != null)
                                throw new Exception(string.Format("编码为【{0}】的计量单位已存在！", Code));
                            head = UOM.Create();
                            head.Code = Code;
                            head.Name = Name;
                            head.Remark = Remark;
                            head.IsBase = IsBase;
                            head.RatioToBase = RatioToBase;
                            head.RoundWay = RoundWay;
                            head.UomPrecision = UomPrecision;
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

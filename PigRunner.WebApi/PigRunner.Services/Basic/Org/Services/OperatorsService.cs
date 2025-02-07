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

    public class OperatorsService : IOperatorsService
    {
        private OperatorsRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public OperatorsService(OperatorsRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 业务员增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionOperators(OperatorsView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request == null)
                    throw new Exception("参数不能为空！");

                if (request.OptType.Equals("AddOperators") || request.OptType.Equals("UpdateOperators"))
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    if (string.IsNullOrEmpty(request.Name))
                        throw new Exception("名称不能为空！");

                    Operators head = repository.GetFirst(q => q.Code == request.Code);

                    if (request.OptType.Equals("AddOperators"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("编码为【{0}】的业务员已存在，不能再新增！", request.Code));
                        else
                            head = Operators.Create();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(request.ID))
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID.ToString() == request.ID);
                        if (head == null)
                            throw new Exception(string.Format("ID为【{0}】的业务员不存在，请检查！", request.ID));

                        head.ModifiedTime = DateTime.Now;
                    }

                    Operators oldHead = repository.GetFirst(q => (q.Code == request.Code || q.Name == request.Name) && q.ID != head.ID);
                    if (oldHead != null)
                        throw new Exception(string.Format("编码为【{0}】或者名称为【{1}】的业务员已存在，请检查！", request.Code, request.Name));

                    head.Code = request.Code;
                    head.Name = request.Name;
                    response.id = head.ID;
                    head.Remark = request.Remark;
                    head.IsEffective =bool.TryParse( request.IsEffective,out bool IsEffective) ? 1 : 0;
                    head.IsInver = bool.TryParse(request.IsEffective, out bool IsInver) ? 1 : 0;
                    head.IsPlaner = bool.TryParse(request.IsEffective, out bool IsPlaner) ? 1 : 0;
                    head.IsPurer = bool.TryParse(request.IsEffective, out bool IsPurer) ? 1 : 0;
                    head.IsSaler = bool.TryParse(request.IsEffective, out bool IsSaler) ? 1 : 0;

                    long ParentNode = -1;

                    //根据部门编码查找实体
                    if (!string.IsNullOrEmpty(request.DeptCode))
                    {
                        var lg = repository.Context.Queryable<Department>().Where(q => q.Code == request.DeptCode)?.First();
                        if (lg != null)
                            ParentNode = lg.ID;
                    }
                    head.Dept = ParentNode;
                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("业务员新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelOperators"))
                {
                    if (string.IsNullOrEmpty(request.Code) && (request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("编码不能为空！");
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        Operators head = repository.GetFirst(q => q.Code == request.Code);
                        if (head == null)
                            throw new Exception(string.Format("编码为【{0}】的业务员不存在！", request.Code));

                        bool isSuccess = repository.Delete(head);
                        if (!isSuccess)
                            throw new Exception("删除失败！");
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            Operators head = repository.GetFirst(q => q.Code == item);
                            if (head == null)
                                throw new Exception(string.Format("编码为【{0}】的业务员不存在！", request.Code));

                            bool isSuccess = repository.Delete(head);
                            if (!isSuccess)
                                throw new Exception("删除失败！");
                        }
                    }
                }
                else if (request.OptType.Equals("QueryOperators"))
                {
                    int total = 0;
                    List<OperatorsView> list = new List<OperatorsView>();
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
                            OperatorsView dto = SetValue(item);
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

        private OperatorsView SetValue(Operators item)
        {
            OperatorsView dto = new OperatorsView();
            dto.Code = item.Code;
            dto.Name = item.Name;
            dto.Remark = item.Remark;
            dto.ID = item.ID.ToString();
            dto.IsEffective = false.ToString();
            if (item.IsEffective == 1)
            { dto.Effective = "生效"; dto.IsEffective = true.ToString(); }
            else
                dto.Effective = "停用";

            dto.IsPurer = false.ToString();
            if (item.IsPurer == 1)
            {  dto.IsPurerName = "是";dto.IsPurer = true.ToString(); }
            else
                dto.IsPurerName = "否";

            dto.IsInver = false.ToString();
            if (item.IsInver == 1)
            { dto.IsInverName = "是"; dto.IsInver = true.ToString(); }
            else
                dto.IsInverName = "否";

            dto.IsPlaner = false.ToString();
            if (item.IsPlaner == 1)
            { dto.IsPlanerName = "是"; dto.IsPlaner = true.ToString(); }
            else
                dto.IsPlanerName = "否";

            dto.IsSaler = false.ToString();
            if (item.IsSaler == 1)
            { dto.IsSalerName = "是"; dto.IsSaler = true.ToString(); }
            else
                dto.IsSalerName = "否";

            //根据部门编码查找实体
            var lg = repository.Context.Queryable<Department>().Where(q => q.ID == item.Dept).ToList()?.FirstOrDefault();
            if (lg != null)
            {
                dto.DeptCode = lg.Code;
                dto.DeptName = lg.Name;
            }
            return dto;
        }

        public PubResponse UploadOperators(MemoryStream stream)
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
                    List<Operators> lstCtry = new List<Operators>();
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

                            //第3列：是否采购员
                            string IsPurerName = string.Empty;
                            if (worksheet.GetValue(row, 3) != null)
                                IsPurerName = worksheet.GetValue(row, 3).ToString();
                            int IsPurer = 0;
                            if (!string.IsNullOrEmpty(IsPurerName) && (IsPurerName.Equals("是") || IsPurerName.Equals("1")))
                                IsPurer = 1;

                            //第4列：是否销售人员
                            string IsSalerName = string.Empty;
                            if (worksheet.GetValue(row, 4) != null)
                                IsSalerName = worksheet.GetValue(row, 4).ToString();
                            int IsSaler = 0;
                            if (!string.IsNullOrEmpty(IsSalerName) && (IsSalerName.Equals("是") || IsSalerName.Equals("1")))
                                IsSaler = 1;

                            //第5列：是否计划人员
                            string IsPlanerName = string.Empty;
                            if (worksheet.GetValue(row, 5) != null)
                                IsPlanerName = worksheet.GetValue(row, 5).ToString();
                            int IsPlaner = 0;
                            if (!string.IsNullOrEmpty(IsPlanerName) && (IsPlanerName.Equals("是") || IsPlanerName.Equals("1")))
                                IsPlaner = 1;

                            //第6列：是否仓库员
                            string IsInverName = string.Empty;
                            if (worksheet.GetValue(row, 6) != null)
                                IsInverName = worksheet.GetValue(row, 6).ToString();
                            int IsInver = 0;
                            if (!string.IsNullOrEmpty(IsInverName) && (IsInverName.Equals("是") || IsInverName.Equals("1")))
                                IsInver = 1;

                            long DeptID = 0;
                            //第7列：所属部门
                            string DeptName = string.Empty;
                            if (worksheet.GetValue(row, 7) != null)
                                DeptName = worksheet.GetValue(row, 7).ToString();

                            if (!string.IsNullOrEmpty(DeptName))
                            {
                                var dept = repository.Context.Queryable<Department>().Where(q => q.Name == DeptName).ToList()?.FirstOrDefault();
                                if (dept != null)
                                    DeptID = dept.ID;
                            }

                            //第8列：状态
                            string Effective = string.Empty;
                            if (worksheet.GetValue(row, 8) != null)
                                Effective = worksheet.GetValue(row, 8).ToString();

                            int IsEffective = 0;
                            if (!string.IsNullOrEmpty(Effective) && (Effective.Equals("生效") || Effective.Equals("1")))
                                IsEffective = 1;

                            //第5列：备注
                            string Remark = string.Empty;
                            if (worksheet.GetValue(row, 9) != null)
                                Remark = worksheet.GetValue(row, 9).ToString();



                            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name))
                                continue;
                            if (dic.ContainsKey(Code) || dic.ContainsValue(Name))
                                throw new Exception(string.Format("Sheet[{0}]编码或名称已重复，请检查！", worksheet.Name));
                            dic.Add(Code, Name);
                            Operators head = repository.GetFirst(q => q.Code == Code || q.Name == Name);
                            if (head != null)
                                throw new Exception(string.Format("编码为【{0}】的业务员已存在！", Code));
                            head = Operators.Create();
                            head.Code = Code;
                            head.Name = Name;
                            head.Dept = DeptID;
                            head.Remark = Remark;
                            head.IsEffective = IsEffective;
                            head.IsInver = IsInver;
                            head.IsPlaner = IsPlaner;
                            head.IsSaler = IsSaler;
                            head.IsPurer = IsPurer;
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


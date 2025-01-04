using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using PigRunner.DTO.Basic;
using PigRunner.Entitys.Basic;
using PigRunner.Entitys.Basic.Gop;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Basic.Gop;
using PigRunner.Services.Basic.Gop.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Basic.Gop.Services
{
    public class CustomerService : ICustomerService
    {
        private CustomerRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public CustomerService(CustomerRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 客户增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionCustomer(CustomerView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request.OptType.Equals("AddCustomer") || request.OptType.Equals("UpdateCustomer"))
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    if (string.IsNullOrEmpty(request.Name))
                        throw new Exception("名称不能为空！");

                    Customer head = repository.GetFirst(q => q.Code == request.Code);

                    if (request.OptType.Equals("AddCustomer"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("编码为【{0}】的客户已存在，不能再新增！", request.Code));
                        else
                            head = Customer.Create();
                    }
                    else
                    {
                        if (request.ID <= 0)
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID == request.ID);
                        if (head == null)
                            throw new Exception(string.Format("ID为【{0}】的客户不存在，请检查！", request.ID));

                        head.ModifiedTime = DateTime.Now;
                    }

                    Customer oldHead = repository.GetFirst(q => (q.Code == request.Code || q.Name == request.Name) && q.ID != head.ID);
                    if (oldHead != null)
                        throw new Exception(string.Format("编码为【{0}】或者名称为【{1}】的客户已存在，请检查！", request.Code, request.Name));

                    head.Code = request.Code;
                    head.Name = request.Name;
                    response.id = head.ID;
                    head.Remark = request.Remark;

                    head.ShortName = request.ShortName;
                    long ParentNode = -1;

                    //根据客户编码查找实体
                    if (!string.IsNullOrEmpty(request.ParentCustCode))
                    {
                        var lg = repository.GetFirst(q => q.Code == request.ParentCustCode);
                        if (lg != null)
                            ParentNode = lg.ID;
                    }
                    head.ParentCustomer = ParentNode;

                    long Category = -1;
                    if(!string.IsNullOrEmpty(request.CategoryCode))
                    {
                        var cate=repository.Context.Queryable<CustomerCategory>().Where(q=>q.Code==request.CategoryCode).ToList()?.FirstOrDefault();
                        if (cate != null)
                            Category = cate.ID;
                    }
                    head.Category = Category;

                    long Country = -1;
                    if (!string.IsNullOrEmpty(request.CountryCode))
                    {
                        var cate = repository.Context.Queryable<Country>().Where(q => q.Code == request.CountryCode).ToList()?.FirstOrDefault();
                        if (cate != null)
                            Country = cate.ID;
                    }
                    head.Country = Country;

                    long Supplier = -1;
                    if (!string.IsNullOrEmpty(request.SupplierCode))
                    {
                        var data = repository.Context.Queryable<Supplier>().Where(q => q.Code == request.SupplierCode).ToList()?.FirstOrDefault();
                        if (data != null)
                            Supplier = data.ID;
                    }
                    head.Supplier = Supplier;

                    head.RcvAddress=request.RcvAddress;
                    head.IsInerOrg = request.IsInerOrg ? 1 : 0;

                    long Dept = -1;
                    if (!string.IsNullOrEmpty(request.DeptCode))
                    {
                        var data = repository.Context.Queryable<Department>().Where(q => q.Code == request.DeptCode).ToList()?.FirstOrDefault();
                        if (data != null)
                            Dept = data.ID;
                    }
                    head.Dept = Dept;

                    long Operators = -1;
                    if (!string.IsNullOrEmpty(request.OperatorsCode))
                    {
                        var data = repository.Context.Queryable<Operators>().Where(q => q.Code == request.OperatorsCode).ToList()?.FirstOrDefault();
                        if (data != null)
                            Operators = data.ID;
                    }
                    head.Operators = Operators;

                    head.TaxRate = request.TaxRate;
                    head.TaxNum = request.TaxNum;
                    head.RcvManTell = request.RcvManTell;
                    head.RecTerm = request.RecTerm;
                    head.AccrueTerm = request.AccrueTerm;
                    head.ShipRule = request.ShipRule;
                    head.Status = request.Status ? 1 : 0;

                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("客户新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelCustomer"))
                {
                    if (string.IsNullOrEmpty(request.Code) && (request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("编码不能为空！");
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        Customer head = repository.GetFirst(q => q.Code == request.Code);
                        if (head == null)
                            throw new Exception(string.Format("编码为【{0}】的客户不存在！", request.Code));

                        bool isSuccess = repository.Delete(head);
                        if (!isSuccess)
                            throw new Exception("删除失败！");
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            Customer head = repository.GetFirst(q => q.Code == item);
                            if (head == null)
                                throw new Exception(string.Format("编码为【{0}】的客户不存在！", request.Code));

                            bool isSuccess = repository.Delete(head);
                            if (!isSuccess)
                                throw new Exception("删除失败！");
                        }
                    }
                }
                else if (request.OptType.Equals("QueryCustomer"))
                {
                    int total = 0;
                    List<CustomerView> list = new List<CustomerView>();
                    var lst = repository.AsQueryable().ToOffsetPage(request.Current, request.Size, ref total);

                    if (!string.IsNullOrEmpty(request.Code) && !string.IsNullOrEmpty(request.Name) && request.ID > 0)
                        lst = repository.AsQueryable().Where(q => q.Code.Contains(request.Code) && q.Name.Contains(request.Name) && q.ID != request.ID).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.Code) && !string.IsNullOrEmpty(request.Name))
                        lst = repository.AsQueryable().Where(q => q.Code.Contains(request.Code) && q.Name.Contains(request.Name)).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.Code))
                        lst = repository.AsQueryable().Where(q => q.Code.Contains(request.Code)).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.Name))
                        lst = repository.AsQueryable().Where(q => q.Name.Contains(request.Name)).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (request.ID > 0)
                        lst = repository.AsQueryable().Where(q => q.ID != request.ID).ToOffsetPage(request.Current, request.Size, ref total);
                    if (lst != null && lst.Count > 0)
                    {
                        int lineNum = 1;
                        foreach (var item in lst)
                        {
                            CustomerView dto = SetValue(item);
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

        private CustomerView SetValue(Customer item)
        {
            CustomerView dto = new CustomerView();
            dto.Code = item.Code;
            dto.Name = item.Name;
            dto.Remark = item.Remark;
            dto.ID = item.ID;
            dto.ShortName = item.ShortName;

            var lg = repository.GetFirst(q => q.ID == item.ParentCustomer);
            if (lg != null)
            {
                dto.ParentCustCode = lg.Code;
                dto.ParentCustName = lg.Name;
            }

            if (item.Category > 0)
            {
                var cate = repository.Context.Queryable<CustomerCategory>().Where(q => q.ID == item.Category).ToList()?.FirstOrDefault();
                if (cate != null)
                {
                    dto.CategoryName = cate.Name;
                    dto.CategoryCode = cate.Code;
                }
            }

            if (item.Country > 0)
            {
                var cate = repository.Context.Queryable<Country>().Where(q => q.ID == item.Country).ToList()?.FirstOrDefault();
                if (cate != null)
                {
                    dto.CountryCode = cate.Code;
                    dto.CountryName = cate.Name;
                }
            }

            if (item.Supplier > 0)
            {
                var data = repository.Context.Queryable<Supplier>().Where(q => q.ID == item.Supplier).ToList()?.FirstOrDefault();
                if (data != null)
                {
                    dto.SupplierCode = data.Code;
                    dto.SupplierName = data.Name;
                }
            }

            dto.RcvAddress = item.RcvAddress;
            dto.IsInerOrg = item.IsInerOrg == 1 ? true : false;
            if (dto.IsInerOrg)
                dto.InerOrgName = "是";
            else
                dto.InerOrgName = "否";
            if (item.Dept > 0)
            {
                var data = repository.Context.Queryable<Department>().Where(q => q.ID == item.Dept).ToList()?.FirstOrDefault();
                if (data != null)
                {
                    dto.DeptCode = data.Code;
                    dto.DeptName = data.Name;
                }
            }

            if (item.Operators > 0)
            {
                var data = repository.Context.Queryable<Operators>().Where(q => q.ID == item.Operators).ToList()?.FirstOrDefault();
                if (data != null)
                {
                    dto.OperatorsCode = data.Code;
                    dto.OperatorsName = data.Name;
                }
            }

            dto.TaxRate = item.TaxRate;
            dto.TaxNum = item.TaxNum;
            dto.RcvManTell = item.RcvManTell;
            dto.RecTerm = item.RecTerm;
            dto.AccrueTerm = item.AccrueTerm;
            dto.ShipRule = item.ShipRule;

            dto.Status = item.Status==1?true:false;
            if (item.Status == 1)
                dto.StatusName = "生效";
            else
                dto.StatusName = "失效";
            return dto;
        }

        public PubResponse UploadCustomer(MemoryStream stream)
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
                    List<Customer> lstCtry = new List<Customer>();
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

                            //第3列：简称
                            string ShortName = string.Empty;
                            if (worksheet.GetValue(row, 3) != null)
                                ShortName = worksheet.GetValue(row, 3).ToString();

                            //第4列：分类
                            long Category = 0;
                            string CategoryName = string.Empty;
                            if (worksheet.GetValue(row, 4) != null)
                                CategoryName = worksheet.GetValue(row, 4).ToString();

                            if(!string.IsNullOrEmpty(CategoryName))
                            {
                                var data = repository.Context.Queryable<CustomerCategory>().Where(q => q.Name == CategoryName)?.First();
                                if (data != null)
                                    Category = data.ID;
                            }

                          

                            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name))
                                continue;
                            if (dic.ContainsKey(Code) || dic.ContainsValue(Name))
                                throw new Exception(string.Format("Sheet[{0}]编码或名称已重复，请检查！", worksheet.Name));
                            dic.Add(Code, Name);
                            Customer head = repository.GetFirst(q => q.Code == Code || q.Name == Name);
                            if (head != null)
                                throw new Exception(string.Format("编码为【{0}】的客户已存在！", Code));
                            head = Customer.Create();
                            head.Code = Code;
                            head.Name = Name;

                            head.ShortName = ShortName;
                            head.Category = Category;

                            long ParentNode = -1;

                            //第5列：分类
                            string ParentCustCode = string.Empty;
                            if (worksheet.GetValue(row, 5) != null)
                                ParentCustCode = worksheet.GetValue(row, 5).ToString();

                            //根据客户编码查找实体
                            if (!string.IsNullOrEmpty(ParentCustCode))
                            {
                                var lg = repository.GetFirst(q => q.Code == ParentCustCode||q.Name==ParentCustCode);
                                if (lg != null)
                                    ParentNode = lg.ID;
                            }
                            head.ParentCustomer = ParentNode;

                            //第6列：地区
                            string CountryCode = string.Empty;
                            if (worksheet.GetValue(row, 6) != null)
                                CountryCode = worksheet.GetValue(row, 6).ToString();

                            long Country = -1;
                            if (!string.IsNullOrEmpty(CountryCode))
                            {
                                var cate = repository.Context.Queryable<Country>().Where(q => q.Code == CountryCode||q.Name==CountryCode).ToList()?.FirstOrDefault();
                                if (cate != null)
                                    Country = cate.ID;
                            }
                            head.Country = Country;


                            //第7列：地区
                            string SupplierCode = string.Empty;
                            if (worksheet.GetValue(row, 7) != null)
                                SupplierCode = worksheet.GetValue(row, 7).ToString();

                            long Supplier = -1;
                            if (!string.IsNullOrEmpty(SupplierCode))
                            {
                                var data = repository.Context.Queryable<Supplier>().Where(q => q.Code == SupplierCode || q.Name == SupplierCode).ToList()?.FirstOrDefault();
                                if (data != null)
                                    Supplier = data.ID;
                            }
                            head.Supplier = Supplier;

                            //第8列：收货地址
                            string RcvAddress = string.Empty;
                            if (worksheet.GetValue(row, 8) != null)
                                RcvAddress = worksheet.GetValue(row, 8).ToString();

                            head.RcvAddress = RcvAddress;

                            //第9列：是否内部组织
                            string IsInerOrgName = string.Empty;
                            int IsInerOrg = 0;
                            if (worksheet.GetValue(row, 9) != null)
                                IsInerOrgName = worksheet.GetValue(row, 9).ToString();
                            if (!string.IsNullOrEmpty(IsInerOrgName) && IsInerOrgName.Equals("是"))
                                IsInerOrg = 1;
                            head.IsInerOrg = IsInerOrg;

                            //第10列：部门
                            string DeptCode = string.Empty;
                            if (worksheet.GetValue(row, 10) != null)
                                DeptCode = worksheet.GetValue(row, 10).ToString();
                            long Dept = -1;
                            if (!string.IsNullOrEmpty(DeptCode))
                            {
                                var data = repository.Context.Queryable<Department>().Where(q => q.Code == DeptCode || q.Name == DeptCode).ToList()?.FirstOrDefault();
                                if (data != null)
                                    Dept = data.ID;
                            }
                            head.Dept = Dept;

                            //第11列：业务员
                            string OperatorsCode = string.Empty;
                            if (worksheet.GetValue(row, 11) != null)
                                OperatorsCode = worksheet.GetValue(row, 11).ToString();

                            long Operators = -1;
                            if (!string.IsNullOrEmpty(OperatorsCode))
                            {
                                var data = repository.Context.Queryable<Operators>().Where(q => q.Code == OperatorsCode).ToList()?.FirstOrDefault();
                                if (data != null)
                                    Operators = data.ID;
                            }
                            head.Operators = Operators;

                            //第12列：税率
                            string strTaxRate = string.Empty;
                            decimal TaxRate = 0;
                            if (worksheet.GetValue(row, 12) != null)
                                strTaxRate = worksheet.GetValue(row, 12).ToString();
                            decimal.TryParse(strTaxRate, out TaxRate);
                            head.TaxRate = TaxRate;

                            //第13列：税号
                            string TaxNum = string.Empty;
                            if (worksheet.GetValue(row, 13) != null)
                                TaxNum = worksheet.GetValue(row, 13).ToString();
                            head.TaxNum = TaxNum;

                            //第14列：收货人电话
                            string RcvManTell = string.Empty;
                            if (worksheet.GetValue(row, 14) != null)
                                RcvManTell = worksheet.GetValue(row, 14).ToString();
                            head.RcvManTell = RcvManTell;

                            //第15列：收款条件
                            string RecTerm = string.Empty;
                            if (worksheet.GetValue(row, 15) != null)
                                RecTerm = worksheet.GetValue(row, 15).ToString();
                            head.RecTerm = RecTerm;

                            //第16列：立账条件
                            string AccrueTerm = string.Empty;
                            if (worksheet.GetValue(row, 16) != null)
                                AccrueTerm = worksheet.GetValue(row, 16).ToString();
                            head.AccrueTerm = AccrueTerm;

                            //第17列：立账条件
                            string ShipRule = string.Empty;
                            if (worksheet.GetValue(row, 17) != null)
                                ShipRule = worksheet.GetValue(row, 17).ToString();
                            head.ShipRule = ShipRule;

                            //第18列：状态
                            string strStatus = string.Empty;
                            if (worksheet.GetValue(row, 18) != null)
                                strStatus = worksheet.GetValue(row, 18).ToString();
                            int Status = 0;
                            if (!string.IsNullOrEmpty(strStatus))
                            {
                                if (strStatus.Equals("生效"))
                                    Status = 1;
                            }
                            head.Status = Status;
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

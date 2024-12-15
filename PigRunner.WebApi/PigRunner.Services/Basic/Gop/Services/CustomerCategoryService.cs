using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using PigRunner.DTO.Basic.Gop;
using PigRunner.Entitys.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Basic.Gop;
using PigRunner.Services.Basic.Gop.IServices;

namespace PigRunner.Services.Basic.Gop.Services
{
   public class CustomerCategoryService : ICustomerCategoryService
    {
        private CustomerCategoryRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public CustomerCategoryService(CustomerCategoryRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 客户分类增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionCustomerCategory(CustomerCategoryView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request.OptType.Equals("AddCustomerCategory") || request.OptType.Equals("UpdateCustomerCategory"))
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    if (string.IsNullOrEmpty(request.Name))
                        throw new Exception("名称不能为空！");

                    CustomerCategory head = repository.GetFirst(q => q.Code == request.Code);

                    if (request.OptType.Equals("AddCustomerCategory"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("编码为【{0}】的客户分类已存在，不能再新增！", request.Code));
                        else
                            head = CustomerCategory.Create();
                    }
                    else
                    {
                        if (request.ID <= 0)
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID == request.ID);
                        if (head == null)
                            throw new Exception(string.Format("ID为【{0}】的客户分类不存在，请检查！", request.ID));

                        head.ModifiedTime = DateTime.Now;
                    }

                    CustomerCategory oldHead = repository.GetFirst(q => (q.Code == request.Code || q.Name == request.Name) && q.ID != head.ID);
                    if (oldHead != null)
                        throw new Exception(string.Format("编码为【{0}】或者名称为【{1}】的客户分类已存在，请检查！", request.Code, request.Name));

                    head.Code = request.Code;
                    head.Name = request.Name;
                    response.id = head.ID;
                    head.Remark = request.Remark;
                    long ParentNode = -1;

                    //根据客户分类编码查找实体
                    if (!string.IsNullOrEmpty(request.ParentCode))
                    {
                        var lg = repository.GetFirst(q => q.Code == request.ParentCode);
                        if (lg != null)
                            ParentNode = lg.ID;
                    }
                    head.ParentNode = ParentNode;
                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("客户分类新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelCustomerCategory"))
                {
                    if (string.IsNullOrEmpty(request.Code) && (request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("编码不能为空！");
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        CustomerCategory head = repository.GetFirst(q => q.Code == request.Code);
                        if (head == null)
                            throw new Exception(string.Format("编码为【{0}】的客户分类不存在！", request.Code));

                        bool isSuccess = repository.Delete(head);
                        if (!isSuccess)
                            throw new Exception("删除失败！");
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            CustomerCategory head = repository.GetFirst(q => q.Code == item);
                            if (head == null)
                                throw new Exception(string.Format("编码为【{0}】的客户分类不存在！", request.Code));

                            bool isSuccess = repository.Delete(head);
                            if (!isSuccess)
                                throw new Exception("删除失败！");
                        }
                    }
                }
                else if (request.OptType.Equals("QueryCustomerCategory"))
                {
                    int total = 0;
                    List<CustomerCategoryView> list = new List<CustomerCategoryView>();
                    var lst = repository.AsQueryable().ToOffsetPage(request.Current, request.Size, ref total);
                  
                     if (!string.IsNullOrEmpty(request.Code) && !string.IsNullOrEmpty(request.Name)&&request.ID>0)
                        lst = repository.AsQueryable().Where(q => q.Code.Contains(request.Code) && q.Name.Contains(request.Name)&&q.ID!=request.ID).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.Code) && !string.IsNullOrEmpty(request.Name))
                        lst = repository.AsQueryable().Where(q => q.Code.Contains(request.Code) && q.Name.Contains(request.Name)).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.Code))
                        lst = repository.AsQueryable().Where(q => q.Code.Contains(request.Code)).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.Name))
                        lst = repository.AsQueryable().Where(q => q.Name.Contains(request.Name)).ToOffsetPage(request.Current, request.Size, ref total);
                      else if (request.ID>0)
                            lst = repository.AsQueryable().Where(q => q.ID!=request.ID).ToOffsetPage(request.Current, request.Size, ref total);
                    if (lst != null && lst.Count > 0)
                    {
                        int lineNum = 1;
                        foreach (var item in lst)
                        {
                            CustomerCategoryView dto = SetValue(item);
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

        private CustomerCategoryView SetValue(CustomerCategory item)
        {
            CustomerCategoryView dto = new CustomerCategoryView();
            dto.Code = item.Code;
            dto.Name = item.Name;
            dto.Remark = item.Remark;
            dto.ID = item.ID;
            //根据客户分类编码查找实体
            var lg = repository.GetFirst(q => q.ID == item.ParentNode);
            if (lg != null)
            {
                dto.ParentCode = lg.Code;
                dto.ParentName = lg.Name;
            }
            return dto;
        }

        public PubResponse UploadCustomerCategory(MemoryStream stream)
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
                    List<CustomerCategory> lstCtry = new List<CustomerCategory>();
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    foreach (var worksheet in lst)
                    {
                        var rowCount = worksheet.Dimension.Rows;//行
                        var columnCount = worksheet.Dimension.Columns;//列
                        if (rowCount < 2)
                            throw new Exception(string.Format("Sheet[{0}]数据不能为空！", worksheet.Name));
                        if (columnCount < 3)
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

                            //第3列：客户分类
                            string CountryName = string.Empty;
                            if (worksheet.GetValue(row, 3) != null)
                                CountryName = worksheet.GetValue(row, 3).ToString();


                            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name))
                                continue;
                            if (dic.ContainsKey(Code) || dic.ContainsValue(Name))
                                throw new Exception(string.Format("Sheet[{0}]编码或名称已重复，请检查！", worksheet.Name));
                            dic.Add(Code, Name);
                            CustomerCategory head = repository.GetFirst(q => q.Code == Code || q.Name == Name);
                            if (head != null)
                                throw new Exception(string.Format("编码为【{0}】的客户分类已存在！", Code));
                            head = CustomerCategory.Create();
                            head.Code = Code;
                            head.Name = Name;
                            long CountryID = 0;
                            var lg = repository.Context.Queryable<CustomerCategory>().Where(q => q.Name == CountryName)?.First();
                            if (lg == null)
                                throw new Exception(string.Format("客户分类【{0}】不存在！", CountryName));
                            CountryID = lg.ID;
                            head.ParentNode = CountryID;
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

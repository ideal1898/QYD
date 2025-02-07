using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using PigRunner.DTO.Basic.Gop;
using PigRunner.Entitys.Basic;
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
     public class ItemCategoryService : IItemCategoryService
    {
        private ItemCategoryRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public ItemCategoryService(ItemCategoryRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        ///物料分类增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionItemCategory(ItemCategoryView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request == null)
                    throw new Exception("参数不能为空！");

                if (request.OptType.Equals("AddItemCategory") || request.OptType.Equals("UpdateItemCategory"))
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    if (string.IsNullOrEmpty(request.Name))
                        throw new Exception("名称不能为空！");

                    ItemCategory head = repository.GetFirst(q => q.Code == request.Code);

                    if (request.OptType.Equals("AddItemCategory"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("编码为【{0}】的物料分类已存在，不能再新增！", request.Code));
                        else
                            head = ItemCategory.Create();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(request.ID))
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID.ToString() == request.ID);
                        if (head == null)
                            throw new Exception(string.Format("ID为【{0}】的物料分类不存在，请检查！", request.ID));

                        head.ModifiedTime = DateTime.Now;
                    }

                    ItemCategory oldHead = repository.GetFirst(q => (q.Code == request.Code || q.Name == request.Name) && q.ID != head.ID);
                    if (oldHead != null)
                        throw new Exception(string.Format("编码为【{0}】或者名称为【{1}】的物料分类已存在，请检查！", request.Code, request.Name));

                    head.Code = request.Code;
                    head.Name = request.Name;
                    response.id = head.ID;
                    head.Remark = request.Remark;
                    head.IsEffective = bool.TryParse(request.IsEffective, out bool isE) ? 1 : 0;
                    long ParentNode = -1;

                    //根据物料分类编码查找实体
                    if (!string.IsNullOrEmpty(request.ParentCode))
                    {
                        var lg = repository.GetFirst(q => q.Code == request.ParentCode);
                        if (lg != null)
                            ParentNode = lg.ID;
                    }
                    head.ParentNode = ParentNode;
                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("物料分类新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelItemCategory"))
                {
                    if (string.IsNullOrEmpty(request.Code) && (request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("编码不能为空！");
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        ItemCategory head = repository.GetFirst(q => q.Code == request.Code);
                        if (head == null)
                            throw new Exception(string.Format("编码为【{0}】的物料分类不存在！", request.Code));

                        bool isSuccess = repository.Delete(head);
                        if (!isSuccess)
                            throw new Exception("删除失败！");
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            ItemCategory head = repository.GetFirst(q => q.Code == item);
                            if (head == null)
                                throw new Exception(string.Format("编码为【{0}】的物料分类不存在！", request.Code));

                            bool isSuccess = repository.Delete(head);
                            if (!isSuccess)
                                throw new Exception("删除失败！");
                        }
                    }
                }
                else if (request.OptType.Equals("QueryItemCategory"))
                {
                    int total = 0;
                    List<ItemCategoryView> list = new List<ItemCategoryView>();
                    string sql = "1=1";
                    if (!string.IsNullOrEmpty(request.Code))
                        sql += string.Format(" and Code like '%{0}%' ", request.Code);

                    if (!string.IsNullOrEmpty(request.Name))
                        sql += string.Format(" and Name like '%{0}%' ", request.Name);

                    int Current = 10;
                    int Size = 1;
                    if (!string.IsNullOrEmpty(request.Current))
                        int.TryParse(request.Current, out Current);

                    if (!string.IsNullOrEmpty(request.Size))
                        int.TryParse(request.Size, out Size);

                    var lst = repository.AsQueryable().Where(sql).ToOffsetPage(Current, Size, ref total);

                    if (lst != null && lst.Count > 0)
                    {
                        int lineNum = 1;
                        foreach (var item in lst)
                        {
                            ItemCategoryView dto = SetValue(item);
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

        private ItemCategoryView SetValue(ItemCategory item)
        {
            ItemCategoryView dto = new ItemCategoryView();
            dto.Code = item.Code;
            dto.Name = item.Name;
            dto.Remark = item.Remark;
            dto.ID = item.ID.ToString();
            dto.IsEffective =false.ToString();
            if (item.IsEffective == 1)
            {
                dto.Effective = "生效";
                dto.IsEffective = true.ToString();
            }
            else
                dto.Effective = "停用";

            //根据物料分类编码查找实体
            var lg = repository.GetFirst(q => q.ID == item.ParentNode);
            if (lg != null)
            {
                dto.ParentCode = lg.Code;
                dto.ParentName = lg.Name;
            }
            return dto;
        }

        public PubResponse UploadItemCategory(MemoryStream stream)
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
                    List<ItemCategory> lstCtry = new List<ItemCategory>();
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

                            //第3列：物料分类
                            string CountryName = string.Empty;
                            if (worksheet.GetValue(row, 3) != null)
                                CountryName = worksheet.GetValue(row, 3).ToString();

                            //第4列：状态
                            string Effective = string.Empty;
                            if (worksheet.GetValue(row, 4) != null)
                                Effective = worksheet.GetValue(row, 4).ToString();

                            //第5列：备注
                            string Remark = string.Empty;
                            if (worksheet.GetValue(row, 5) != null)
                                Remark = worksheet.GetValue(row, 5).ToString();

                            int IsEffective = 0;
                            if (!string.IsNullOrEmpty(Effective) && (Effective.Equals("生效") || Effective.Equals("1")))
                                IsEffective = 1;

                            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name))
                                continue;
                            if (dic.ContainsKey(Code) || dic.ContainsValue(Name))
                                throw new Exception(string.Format("Sheet[{0}]编码或名称已重复，请检查！", worksheet.Name));
                            dic.Add(Code, Name);
                            ItemCategory head = repository.GetFirst(q => q.Code == Code || q.Name == Name);
                            if (head != null)
                                throw new Exception(string.Format("编码为【{0}】的物料分类已存在！", Code));
                            head = ItemCategory.Create();
                            head.Code = Code;
                            head.Name = Name;
                            long CountryID = 0;
                            var lg = repository.Context.Queryable<ItemCategory>().Where(q => q.Name == CountryName)?.First();
                            if (lg == null)
                                throw new Exception(string.Format("物料分类【{0}】不存在！", CountryName));
                            CountryID = lg.ID;
                            head.ParentNode = CountryID;
                            head.Remark = Remark;
                            head.IsEffective = IsEffective;
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

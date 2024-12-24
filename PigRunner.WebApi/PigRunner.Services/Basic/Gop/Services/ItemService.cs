
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Services.Basic.Services
 * 唯一标识：a76ff77b-8b71-4774-913e-4aa5ae4c3b65
 * 文件名：ItemService
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/10/13 13:46:50
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>


using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using PigRunner.DTO.Basic;
using PigRunner.Entitys.Basic;
using PigRunner.Entitys.Basic.Gop;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Basic;
using PigRunner.Services.Basic.IServices;


namespace PigRunner.Services.Basic.Services
{
    public class ItemService : IItemService
    {
        private ItemRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public ItemService(ItemRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 物料增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionItem(ItemView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request.OptType.Equals("AddItem") || request.OptType.Equals("UpdateItem"))
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    if (string.IsNullOrEmpty(request.Name))
                        throw new Exception("名称不能为空！");

                    Item head = repository.GetFirst(q => q.Code == request.Code);

                    if (request.OptType.Equals("AddItem"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("编码为【{0}】的物料已存在，不能再新增！", request.Code));
                        else
                            head = Item.Create();
                    }
                    else
                    {
                        if (request.ID <= 0)
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID == request.ID);
                        if (head == null)
                            throw new Exception(string.Format("ID为【{0}】的物料不存在，请检查！", request.ID));

                        head.ModifiedTime = DateTime.Now;
                    }

                    Item oldHead = repository.GetFirst(q => (q.Code == request.Code || q.Name == request.Name) && q.ID != head.ID);
                    if (oldHead != null)
                        throw new Exception(string.Format("编码为【{0}】或者名称为【{1}】的物料已存在，请检查！", request.Code, request.Name));

                    head.Code = request.Code;
                    head.Name = request.Name;
                    response.id = head.ID;
                    head.Description = request.Description;
                    head.IsEffective = request.IsEffective ? 1 : 0;
                    head.SPECS = request.SPECS;
                    if (!string.IsNullOrEmpty(request.StockCategoryCode))
                    {
                        var data = repository.Context.Queryable<ItemCategory>().Where(q => q.Code == request.StockCategoryCode).ToList()?.FirstOrDefault();
                        if (data == null)
                            throw new Exception(string.Format("编码为【{0}】的料品分类不存在，请检查！", request.StockCategoryCode));
                        head.StockCategory = data.ID;
                    }
                    if (!string.IsNullOrEmpty(request.OrgCode))
                    {
                        var data = repository.Context.Queryable<Organization>().Where(q => q.Code == request.OrgCode).ToList()?.FirstOrDefault();
                        if (data == null)
                            throw new Exception(string.Format("编码为【{0}】的组织不存在，请检查！", request.OrgCode));
                        head.Org = data.ID;
                    }
                    if (!string.IsNullOrEmpty(request.UOMCode))
                    {
                        var data = repository.Context.Queryable<UOM>().Where(q => q.Code == request.UOMCode).ToList()?.FirstOrDefault();
                        if (data == null)
                            throw new Exception(string.Format("编码为【{0}】的计量单位不存在，请检查！", request.UOMCode));
                        head.UOM = data.ID;
                    }
                    if (!string.IsNullOrEmpty(request.BaseUOMCode))
                    {
                        var data = repository.Context.Queryable<UOM>().Where(q => q.Code == request.BaseUOMCode).ToList()?.FirstOrDefault();
                        if (data == null)
                            throw new Exception(string.Format("编码为【{0}】的计量单位不存在，请检查！", request.BaseUOMCode));
                        head.BaseUOM = data.ID;
                    }
                    head.RatioToBase = request.RatioToBase;

                    head.Code1 = request.Code1;
                    head.ItemFormAttribute = request.ItemFormAttribute;
                    head.IsSalesEnable = request.IsSalesEnable ? 1 : 0;
                    head.IsBuildEnable = request.IsBuildEnable ? 1 : 0;
                    head.IsPurchaseEnable = request.IsPurchaseEnable ? 1 : 0;
                    head.IsOutsideOperationEnable = request.IsOutsideOperationEnable ? 1 : 0;
                    head.Picture = request.Picture;
                    head.IsLot = request.IsLot ? 1 : 0;
                    head.IsQc = request.IsQc ? 1 : 0;
                    head.IsQgPeriod = request.IsQgPeriod ? 1 : 0;
                    head.QgDay = request.QgDay;
                    head.QgAlterDay = request.QgAlterDay;

                    if (!string.IsNullOrEmpty(request.QgAlterDayUomCode))
                    {
                        var data = repository.Context.Queryable<UOM>().Where(q => q.Code == request.QgAlterDayUomCode).ToList()?.FirstOrDefault();
                        if (data == null)
                            throw new Exception(string.Format("编码为【{0}】的计量单位不存在，请检查！", request.QgAlterDayUomCode));
                        head.QgAlterDayUom = data.ID;
                    }

                    if (!string.IsNullOrEmpty(request.WarehouseCode))
                    {
                        var data = repository.Context.Queryable<Wh>().Where(q => q.Code == request.WarehouseCode).ToList()?.FirstOrDefault();
                        if (data == null)
                            throw new Exception(string.Format("编码为【{0}】的计量单位不存在，请检查！", request.WarehouseCode));
                        head.Warehouse = data.ID;
                    }
                    head.PackagQty = request.PackagQty;
                    head.MinRcvQty = request.MinRcvQty;
                    head.PurPeriod = request.PurPeriod;


                    if (!string.IsNullOrEmpty(request.SupplierCode))
                    {
                        var data = repository.Context.Queryable<Supplier>().Where(q => q.Code == request.SupplierCode).ToList()?.FirstOrDefault();
                        if (data == null)
                            throw new Exception(string.Format("编码为【{0}】的计量单位不存在，请检查！", request.SupplierCode));
                        head.Supplier = data.ID;
                    }

                    if (!string.IsNullOrEmpty(request.PurPeriodUomCode))
                    {
                        var data = repository.Context.Queryable<UOM>().Where(q => q.Code == request.PurPeriodUomCode).ToList()?.FirstOrDefault();
                        if (data == null)
                            throw new Exception(string.Format("编码为【{0}】的计量单位不存在，请检查！", request.PurPeriodUomCode));
                        head.PurPeriodUom = data.ID;
                    }

                    head.MoBatch = request.MoBatch;
                    if (!string.IsNullOrEmpty(request.MoDeptCode))
                    {
                        var data = repository.Context.Queryable<Department>().Where(q => q.Code == request.MoDeptCode).ToList()?.FirstOrDefault();
                        if (data == null)
                            throw new Exception(string.Format("编码为【{0}】的计量单位不存在，请检查！", request.MoDeptCode));
                        head.MoDept = data.ID;
                    }


                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("物料新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelItem"))
                {
                    if (string.IsNullOrEmpty(request.Code) && (request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("编码不能为空！");
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        Item head = repository.GetFirst(q => q.Code == request.Code);
                        if (head == null)
                            throw new Exception(string.Format("编码为【{0}】的物料不存在！", request.Code));

                        bool isSuccess = repository.Delete(head);
                        if (!isSuccess)
                            throw new Exception("删除失败！");
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            Item head = repository.GetFirst(q => q.Code == item);
                            if (head == null)
                                throw new Exception(string.Format("编码为【{0}】的物料不存在！", request.Code));

                            bool isSuccess = repository.Delete(head);
                            if (!isSuccess)
                                throw new Exception("删除失败！");
                        }
                    }
                }
                else if (request.OptType.Equals("QueryItem"))
                {
                    int total = 0;
                    List<ItemView> list = new List<ItemView>();
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
                            ItemView dto = SetValue(item);
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

        private ItemView SetValue(Item item)
        {
            ItemView dto = new ItemView();
            dto.Code = item.Code;
            dto.Name = item.Name;
            dto.Description = item.Description;
            dto.ID = item.ID;
            dto.Description = item.Description;
            dto.IsEffective = item.IsEffective == 1 ? true : false;
            dto.SPECS = item.SPECS;
            if (item.StockCategory > 0)
            {
                var data = repository.Context.Queryable<ItemCategory>().Where(q => q.ID == item.StockCategory).ToList()?.FirstOrDefault();
                if (data != null)
                {
                    dto.StockCategoryCode = data.Code;
                    dto.StockCategoryName = data.Name;
                }
            }
            if (item.Org > 0)
            {
                var data = repository.Context.Queryable<Organization>().Where(q => q.ID == item.Org).ToList()?.FirstOrDefault();
                if (data != null)
                {
                    dto.OrgCode = data.Code;
                    dto.OrgName = data.Name;
                }
            }
            if (item.UOM > 0)
            {
                var data = repository.Context.Queryable<UOM>().Where(q => q.ID == item.UOM).ToList()?.FirstOrDefault();
                if (data != null)
                {
                    dto.UOMCode = data.Code;
                    dto.UOMName = data.Name;
                }
            }
            if (item.BaseUOM > 0)
            {
                var data = repository.Context.Queryable<UOM>().Where(q => q.ID == item.BaseUOM).ToList()?.FirstOrDefault();
                if (data != null)
                {
                    dto.BaseUOMCode = data.Code;
                    dto.BaseUOMName = data.Name;
                }
            }
            dto.RatioToBase = item.RatioToBase;

            dto.Code1 = item.Code1;
            dto.ItemFormAttribute = item.ItemFormAttribute;
            dto.IsSalesEnable = item.IsSalesEnable == 1 ? true : false;
            dto.IsBuildEnable = item.IsBuildEnable == 1 ? true : false;
            dto.IsPurchaseEnable = item.IsPurchaseEnable == 1 ? true : false;
            dto.IsOutsideOperationEnable = item.IsOutsideOperationEnable == 1 ? true : false;
            dto.Picture = item.Picture;
            dto.IsLot = item.IsLot == 1 ? true : false;
            dto.IsQc = item.IsQc == 1 ? true : false;
            dto.IsQgPeriod = item.IsQgPeriod == 1 ? true : false;
            dto.QgDay = item.QgDay;
            dto.QgAlterDay = item.QgAlterDay;

            if (item.QgAlterDayUom > 0)
            {
                var data = repository.Context.Queryable<UOM>().Where(q => q.ID == item.QgAlterDayUom).ToList()?.FirstOrDefault();
                if (data != null)
                {
                    dto.QgAlterDayUomCode = data.Code;
                    dto.QgAlterDayUomName = data.Name;
                }
            }

            if (item.Warehouse > 0)
            {
                var data = repository.Context.Queryable<Wh>().Where(q => q.ID == item.Warehouse).ToList()?.FirstOrDefault();
                if (data != null)
                {
                    dto.WarehouseCode = data.Code;
                    dto.WarehouseName = data.Name;
                }
            }
            dto.PackagQty = item.PackagQty;
            dto.MinRcvQty = item.MinRcvQty;
            dto.PurPeriod = item.PurPeriod;


            if (item.Supplier > 0)
            {
                var data = repository.Context.Queryable<Supplier>().Where(q => q.ID == item.Supplier).ToList()?.FirstOrDefault();
                if (data != null)
                {
                    dto.SupplierCode = data.Code;
                    dto.SupplierName = data.Name;
                }
            }

            if (item.PurPeriodUom > 0)
            {
                var data = repository.Context.Queryable<UOM>().Where(q => q.ID == item.PurPeriodUom).ToList()?.FirstOrDefault();
                if (data != null)
                {
                    dto.PurPeriodUomCode = data.Code;
                    dto.PurPeriodUomName = data.Name;
                }
            }

            dto.MoBatch = item.MoBatch;
            if (item.MoDept > 0)
            {
                var data = repository.Context.Queryable<Department>().Where(q => q.ID == item.MoDept).ToList()?.FirstOrDefault();
                if (data != null)
                {
                    dto.MoDeptCode = data.Code;
                    dto.MoDeptName = data.Name;
                }
            }
            return dto;
        }

        public PubResponse UploadItem(MemoryStream stream)
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
                    List<Item> lstCtry = new List<Item>();
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

                            //第3列：描述
                            string Remark = string.Empty;
                            if (worksheet.GetValue(row, 3) != null)
                                Remark = worksheet.GetValue(row, 3).ToString();

                            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name))
                                continue;
                            if (dic.ContainsKey(Code) || dic.ContainsValue(Name))
                                throw new Exception(string.Format("Sheet[{0}]编码或名称已重复，请检查！", worksheet.Name));
                            dic.Add(Code, Name);
                            Item head = repository.GetFirst(q => q.Code == Code || q.Name == Name);
                            if (head != null)
                                throw new Exception(string.Format("编码为【{0}】的物料已存在！", Code));
                            head = Item.Create();
                            head.Code = Code;
                            head.Name = Name;
                            head.Description = Remark;

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

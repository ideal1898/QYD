using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using PigRunner.DTO.Basic;
using PigRunner.Entitys.Basic;
using PigRunner.Entitys.Basic.Gop;
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

    public class WhService : IWhService
    {
        private WhRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public WhService(WhRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 仓库增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionWh(WhView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request.OptType.Equals("AddWh") || request.OptType.Equals("UpdateWh"))
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    if (string.IsNullOrEmpty(request.Name))
                        throw new Exception("名称不能为空！");

                    Wh head = repository.GetFirst(q => q.Code == request.Code);

                    if (request.OptType.Equals("AddWh"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("编码为【{0}】的仓库已存在，不能再新增！", request.Code));
                        else
                            head = Wh.Create();
                    }
                    else
                    {
                        if (request.ID <= 0)
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID == request.ID);
                        if (head == null)
                            throw new Exception(string.Format("ID为【{0}】的仓库不存在，请检查！", request.ID));

                        head.ModifiedTime = DateTime.Now;
                    }

                    Wh oldHead = repository.GetFirst(q => (q.Code == request.Code || q.Name == request.Name) && q.ID != head.ID);
                    if (oldHead != null)
                        throw new Exception(string.Format("编码为【{0}】或者名称为【{1}】的仓库已存在，请检查！", request.Code, request.Name));

                    head.Code = request.Code;
                    head.Name = request.Name;
                    response.id = head.ID;
                    head.Remark = request.Remark;
                    head.IsEffective = request.IsEffective ? 1 : 0;
                    head.IsStoreBin = request.IsStoreBin ? 1 : 0;
                  

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

                    long CustomerID = 0;
                    //根据编码查找实体
                    if (!string.IsNullOrEmpty(request.CustomerCode))
                    {
                        var lg = repository.Context.Queryable<Customer>().Where(q => q.Code == request.CustomerCode)?.First();
                        if (lg == null)
                            throw new Exception(string.Format("编码为【{0}】的客户不存在，请检查！", request.CustomerCode));
                        CustomerID = lg.ID;
                    }
                    head.Customer = CustomerID;

                    long SupplierID = 0;
                    //根据编码查找实体
                    if (!string.IsNullOrEmpty(request.SupplierCode))
                    {
                        var lg = repository.Context.Queryable<Supplier>().Where(q => q.Code == request.SupplierCode)?.First();
                        if (lg == null)
                            throw new Exception(string.Format("编码为【{0}】的客户不存在，请检查！", request.SupplierCode));
                        SupplierID = lg.ID;
                    }
                    head.Supplier = SupplierID;
                    head.Address = request.Address;
                    head.Area= request.Area;
                    head.Volume = request.Volume;

                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("仓库新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelWh"))
                {
                    if (string.IsNullOrEmpty(request.Code) && (request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("编码不能为空！");
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        Wh head = repository.GetFirst(q => q.Code == request.Code);
                        if (head == null)
                            throw new Exception(string.Format("编码为【{0}】的仓库不存在！", request.Code));

                        bool isSuccess = repository.Delete(head);
                        if (!isSuccess)
                            throw new Exception("删除失败！");
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            Wh head = repository.GetFirst(q => q.Code == item);
                            if (head == null)
                                throw new Exception(string.Format("编码为【{0}】的仓库不存在！", request.Code));

                            bool isSuccess = repository.Delete(head);
                            if (!isSuccess)
                                throw new Exception("删除失败！");
                        }
                    }
                }
                else if (request.OptType.Equals("QueryWh"))
                {
                    int total = 0;
                    List<WhView> list = new List<WhView>();

                    string sql = "1=1";
                    if (!string.IsNullOrEmpty(request.Code))
                        sql += string.Format(" and Code like '%{0}%' ", request.Code);
                    if (!string.IsNullOrEmpty(request.Name))
                        sql += string.Format(" and Name like '%{0}%' ", request.Name);
                    var lst = repository.AsQueryable().Where(sql).ToOffsetPage(request.Current, request.Size, ref total);

                    if (lst != null && lst.Count > 0)
                    {
                        int lineNum = 1;
                        foreach (var item in lst)
                        {
                            WhView dto = SetValue(item);
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

        private WhView SetValue(Wh item)
        {
            WhView dto = new WhView();
            dto.Code = item.Code;
            dto.Name = item.Name;
            dto.Remark = item.Remark;
            dto.ID = item.ID;
            dto.IsEffective = item.IsEffective == 1 ? true : false;
            if (dto.IsEffective)
                dto.Effective = "启用";
            else
                dto.Effective = "停用";

            dto.IsStoreBin = item.IsStoreBin == 1 ? true : false;
            if (dto.IsStoreBin)
                dto.StoreBinName = "是";
            else
                dto.StoreBinName = "否";
            if (item.Org > 0)
            {
                var lg = repository.Context.Queryable<Organization>().Where(q => q.ID == item.Org)?.First();
                if (lg != null)
                {
                    dto.OrgCode = lg.Code;
                    dto.OrgName = lg.Name;
                }
            }

            if (item.Customer > 0)
            {
                var lg = repository.Context.Queryable<Customer>().Where(q => q.ID == item.Customer)?.First();
                if (lg != null)
                {
                    dto.CustomerCode = lg.Code;
                    dto.CustomerName = lg.Name;
                }
            }

            //根据编码查找实体
            if (item.Supplier > 0)
            {
                var lg = repository.Context.Queryable<Supplier>().Where(q => q.ID == item.Supplier)?.First();
                if (lg != null)
                {
                    dto.SupplierCode = lg.Code;
                    dto.SupplierName = lg.Name;
                }
            }
            dto.Address = item.Address;
            dto.Area = item.Area;
            dto.Volume = item.Volume;
            return dto;
        }

        public PubResponse UploadWh(MemoryStream stream)
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
                    List<Wh> lstCtry = new List<Wh>();
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

                            //第3列：是否货位
                            string IsPurerName = string.Empty;
                            if (worksheet.GetValue(row, 3) != null)
                                IsPurerName = worksheet.GetValue(row, 3).ToString();
                            int IsStoreBin = 0;
                            if (!string.IsNullOrEmpty(IsPurerName) && (IsPurerName.Equals("是") || IsPurerName.Equals("1")))
                                IsStoreBin = 1;

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

                            long SupplierID = 0;
                            //第7列：供应商
                            string SupplierName = string.Empty;
                            if (worksheet.GetValue(row, 7) != null)
                                SupplierName = worksheet.GetValue(row, 7).ToString();

                            if (!string.IsNullOrEmpty(SupplierName))
                            {
                                var dept = repository.Context.Queryable<Supplier>().Where(q => q.Name == SupplierName || q.Code == SupplierName).ToList()?.FirstOrDefault();
                                if (dept == null)
                                    throw new Exception(string.Format("编码/名称为【{0}】的供应商不存在！", SupplierName));
                                SupplierID = dept.ID;
                            }
                            long CustomerID = 0;
                            //第8列：客户
                            string CustomerName = string.Empty;
                            if (worksheet.GetValue(row, 8) != null)
                                CustomerName = worksheet.GetValue(row, 8).ToString();

                            if (!string.IsNullOrEmpty(CustomerName))
                            {
                                var dept = repository.Context.Queryable<Customer>().Where(q => q.Name == CustomerName || q.Code == CustomerName).ToList()?.FirstOrDefault();
                                if (dept == null)
                                    throw new Exception(string.Format("编码/名称为【{0}】的供应商不存在！", CustomerName));
                                CustomerID = dept.ID;
                            }

                            //第9列：地址
                            string Address = string.Empty;
                            if (worksheet.GetValue(row, 9) != null)
                                Address = worksheet.GetValue(row, 9).ToString();

                            //第10列：状态
                            string Effective = string.Empty;
                            if (worksheet.GetValue(row, 10) != null)
                                Effective = worksheet.GetValue(row, 10).ToString();

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
                            Wh head = repository.GetFirst(q => q.Code == Code || q.Name == Name);
                            if (head != null)
                                throw new Exception(string.Format("编码为【{0}】的仓库已存在！", Code));
                            head = Wh.Create();
                            head.Code = Code;
                            head.Name = Name;
                            head.IsStoreBin = IsStoreBin;
                            head.Remark = Remark;
                            head.IsEffective = IsEffective;
                            head.Customer = CustomerID;
                            head.Supplier = SupplierID;
                            head.Address = Address;
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
    

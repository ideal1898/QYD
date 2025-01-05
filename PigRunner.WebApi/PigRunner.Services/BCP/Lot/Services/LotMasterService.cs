using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using PigRunner.DTO.BCP.Lot;
using PigRunner.Entitys.Basic;
using PigRunner.Entitys.BCP.Lot;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.BCP.Lot;
using PigRunner.Services.BCP.Lot.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.BCP.Lot.Services
{
    public class LotMasterService : ILotMasterService
    {
        private LotMasterRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public LotMasterService(LotMasterRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 批次主档增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionLotMaster(LotMasterView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request.OptType.Equals("AddLotMaster") || request.OptType.Equals("UpdateLotMaster"))
                {
                    if (string.IsNullOrEmpty(request.LotCode))
                        throw new Exception("批次号不能为空！");

                    LotMaster head = repository.GetFirst(q => q.LotCode == request.LotCode);

                    if (request.OptType.Equals("AddLotMaster"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("批次号为【{0}】的批次主档已存在，不能再新增！", request.LotCode));
                        else
                            head = LotMaster.Create();
                    }
                    else
                    {
                        if (request.ID <= 0)
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID == request.ID);
                        if (head == null)
                            throw new Exception(string.Format("ID为【{0}】的批次主档不存在，请检查！", request.ID));

                        head.ModifiedTime = DateTime.Now;
                    }

                    LotMaster oldHead = repository.GetFirst(q => (q.LotCode == request.LotCode) && q.ID != head.ID);
                    if (oldHead != null)
                        throw new Exception(string.Format("批次号为【{0}】的批次主档已存在，请检查！", request.LotCode));

                    head.LotCode = request.LotCode;
                    response.id = head.ID;
                    head.Remark = request.Remark;

                    if (string.IsNullOrEmpty(request.OrgCode))
                        throw new Exception("组织不能为空！");
                    var org = repository.Context.Queryable<Organization>().Where(q => q.Code == request.OrgCode).ToList()?.FirstOrDefault();
                    if (org == null)
                        throw new Exception(string.Format("编码为【{0}】的组织机构不存在，请检查！", request.OrgCode));
                    head.Org = org.ID;

                    long itemID = 0;
                    if(!string.IsNullOrEmpty(request.ItemCode))
                    {
                        var item = repository.Context.Queryable<Item>().Where(q => q.Code == request.ItemCode).ToList()?.FirstOrDefault();
                        if (item == null)
                            throw new Exception(string.Format("编码为【{0}】的物料不存在，请检查！", request.ItemCode));
                        itemID = item.ID;
                    }
                    head.ItemMaster = itemID;


                    DateTime EffectiveDate = DateTime.MinValue;
                    if (string.IsNullOrEmpty(request.EffectiveDate))
                        throw new Exception("生效日期不能为空！");
                    DateTime.TryParse(request.EffectiveDate, out EffectiveDate);

                   head.EffectiveDate = EffectiveDate;
                    head.InvalidDate = EffectiveDate.AddDays(request.ValidDate);

                    head.AutoCode = request.AutoCode;

                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("批次主档新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelLotMaster"))
                {
                    if (string.IsNullOrEmpty(request.LotCode) && (request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("批次号不能为空！");
                    if (!string.IsNullOrEmpty(request.LotCode))
                    {
                        LotMaster head = repository.GetFirst(q => q.LotCode == request.LotCode);
                        if (head == null)
                            throw new Exception(string.Format("批次号为【{0}】的批次主档不存在！", request.LotCode));

                        bool isSuccess = repository.Delete(head);
                        if (!isSuccess)
                            throw new Exception("删除失败！");
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            LotMaster head = repository.GetFirst(q => q.LotCode == item);
                            if (head == null)
                                throw new Exception(string.Format("批次号为【{0}】的批次主档不存在！", request.LotCode));

                            bool isSuccess = repository.Delete(head);
                            if (!isSuccess)
                                throw new Exception("删除失败！");
                        }
                    }
                }
                else if (request.OptType.Equals("QueryLotMaster"))
                {
                    int total = 0;
                    List<LotMasterView> list = new List<LotMasterView>();
                    var lst = repository.AsQueryable().ToOffsetPage(request.Current, request.Size, ref total);

                    long itemID = 0;
                    if (!string.IsNullOrEmpty(request.ItemCode))
                    {
                        var item = repository.Context.Queryable<Item>().Where(q => q.Code == request.ItemCode).ToList()?.FirstOrDefault();
                        if (item != null)
                            itemID = item.ID;
                    }
                    if (!string.IsNullOrEmpty(request.LotCode) && itemID > 0)
                        lst = repository.AsQueryable().Where(q => q.LotCode.Contains(request.LotCode) && q.ItemMaster == itemID).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.LotCode))
                        lst = repository.AsQueryable().Where(q => q.LotCode.Contains(request.LotCode)).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (itemID > 0)
                        lst = repository.AsQueryable().Where(q => q.ItemMaster == itemID).ToOffsetPage(request.Current, request.Size, ref total);

                    if (lst != null && lst.Count > 0)
                    {
                        int lineNum = 1;
                        foreach (var item in lst)
                        {
                            LotMasterView dto = SetValue(item);
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

        private LotMasterView SetValue(LotMaster item)
        {
            LotMasterView dto = new LotMasterView();
            dto.LotCode = item.LotCode;
            dto.Remark = item.Remark;
            dto.ID = item.ID;

            if (item.EffectiveDate != DateTime.MinValue)
                dto.EffectiveDate = item.EffectiveDate.ToString("yyyy-MM-dd");
            if (item.InvalidDate != DateTime.MinValue)
                dto.InvalidDate = item.InvalidDate.ToString("yyyy-MM-dd");
            dto.ValidDate = item.ValidDate;

            if (item.ItemMaster > 0)
            {
                var itemM = repository.Context.Queryable<Item>().Where(q => q.ID == item.ItemMaster).ToList()?.FirstOrDefault();
                if (itemM != null)
                {
                    dto.ItemName = itemM.Name;
                    dto.ItemCode = itemM.Code;
                }
            }
            return dto;
        }

        public PubResponse UploadLotMaster(MemoryStream stream)
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
                    List<LotMaster> lstCtry = new List<LotMaster>();
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

                            //第1列：批次号
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


                            //第4列：状态
                            int RoundWay = 0;
                            if (worksheet.GetValue(row, 4) != null)
                            {
                                string RtName = worksheet.GetValue(row, 4).ToString();
                                if (RtName.Equals("立项"))
                                    RoundWay = 1;
                                else if (RtName.Equals("进行中"))
                                    RoundWay = 2;
                                else if (RtName.Equals("暂停"))
                                    RoundWay = 3;
                                else if (RtName.Equals("验收"))
                                    RoundWay = 4;
                            }
                            //第5列：验收日期
                            DateTime AcceptDate = DateTime.MinValue;
                            if (worksheet.GetValue(row, 5) != null)
                                DateTime.TryParse(worksheet.GetValue(row, 5).ToString(), out AcceptDate);

                            //第6列：验收日期
                            DateTime QAExpireDate = DateTime.MinValue;
                            if (worksheet.GetValue(row, 6) != null)
                                DateTime.TryParse(worksheet.GetValue(row, 6).ToString(), out QAExpireDate);

                            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name))
                                continue;
                            if (dic.ContainsKey(Code) || dic.ContainsValue(Name))
                                throw new Exception(string.Format("Sheet[{0}]批次号或名称已重复，请检查！", worksheet.Name));
                            dic.Add(Code, Name);
                            LotMaster head = repository.GetFirst(q => q.LotCode == Code);
                            if (head != null)
                                throw new Exception(string.Format("批次号为【{0}】的批次主档已存在！", Code));
                            head = LotMaster.Create();
                           head.LotCode = Code;
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

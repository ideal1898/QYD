using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using PigRunner.DTO.Basic.Pub;
using PigRunner.Entitys.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Basic.Pub;
using PigRunner.Services.Basic.Pub.IServices;

namespace PigRunner.Services.Basic.Pub.Services
{
    public class ProvinceService : IProvinceService
    {
        private ProvinceRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public ProvinceService(ProvinceRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 国家地区增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionProvince(ProvinceView request)
        {
            PubResponse response = new PubResponse();
            try
            {
                if (request.OptType.Equals("AddProvince") || request.OptType.Equals("UpdateProvince"))
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    if (string.IsNullOrEmpty(request.Name))
                        throw new Exception("名称不能为空！");

                    if (string.IsNullOrEmpty(request.CountryCode))
                        throw new Exception("国家/地区编码不能为空！");

                    Province head = repository.GetFirst(q => q.Code == request.Code);

                    if (request.OptType.Equals("AddProvince"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("编码为【{0}】的省/自治区已存在，不能再新增！", request.Code));
                        else
                            head = Province.Create();
                    }
                    else
                    {
                        if (request.ID <= 0)
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID == request.ID);
                        if (head == null)
                            throw new Exception(string.Format("ID为【{0}】的省/自治区不存在，请检查！", request.ID));
                    }

                    Province oldHead = repository.GetFirst(q => (q.Code == request.Code || q.Name == request.Name) && q.ID != head.ID);
                    if (oldHead != null)
                        throw new Exception(string.Format("编码为【{0}】或者名称为【{1}】的省/自治区已存在，请检查！", request.Code, request.Name));

                    head.Code = request.Code;
                    head.Name = request.Name;
                    response.id = head.ID;

                    //根据国家/地区编码查找实体
                    var lg = repository.Context.Queryable<Country>().Where(q => q.Code == request.CountryCode)?.First();
                    if (lg != null)
                        head.Country = lg.ID;

                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("省/自治区新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelProvince"))
                {
                    if (string.IsNullOrEmpty(request.Code) && (request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("编码不能为空！");
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        Province head = repository.GetFirst(q => q.Code == request.Code);
                        if (head == null)
                            throw new Exception(string.Format("编码为【{0}】的省/自治区不存在！", request.Code));

                        bool isSuccess = repository.Delete(head);
                        if (!isSuccess)
                            throw new Exception("删除失败！");
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            Province head = repository.GetFirst(q => q.Code == item);
                            if (head == null)
                                throw new Exception(string.Format("编码为【{0}】的省/自治区不存在！", request.Code));

                            bool isSuccess = repository.Delete(head);
                            if (!isSuccess)
                                throw new Exception("删除失败！");
                        }
                    }
                }
                else if (request.OptType.Equals("QueryProvince"))
                {
                    int total = 0;
                    List<ProvinceView> list = new List<ProvinceView>();
                    var lst = repository.AsQueryable().ToOffsetPage(request.Current, request.Size, ref total);

                    long Cid = -1;
                    if(!string.IsNullOrEmpty(request.CountryCode))
                    {
                        //根据国家/地区编码查找实体
                        var lg = repository.Context.Queryable<Country>().Where(q => q.Code == request.CountryCode)?.First();
                        if (lg != null)
                            Cid = lg.ID;
                        else
                            Cid = 0;
                    }

                    if (!string.IsNullOrEmpty(request.Code) && !string.IsNullOrEmpty(request.Name)&&Cid>-1)
                        lst = repository.AsQueryable().Where(q => q.Code.Contains(request.Code) && q.Name.Contains(request.Name)&&q.Country==Cid).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.Code) && !string.IsNullOrEmpty(request.Name))
                        lst = repository.AsQueryable().Where(q => q.Code.Contains(request.Code) && q.Name.Contains(request.Name)).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.Code))
                        lst = repository.AsQueryable().Where(q => q.Code.Contains(request.Code)).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.Name))
                        lst = repository.AsQueryable().Where(q => q.Name.Contains(request.Name)).ToOffsetPage(request.Current, request.Size, ref total);
                      else if (Cid>-1)
                        lst = repository.AsQueryable().Where(q => q.Country==Cid).ToOffsetPage(request.Current, request.Size, ref total);

                    if (lst != null && lst.Count > 0)
                    {
                        int lineNum = 1;
                        foreach (var item in lst)
                        {
                            ProvinceView dto = SetValue(item);
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

        private ProvinceView SetValue(Province item)
        {
            ProvinceView dto = new ProvinceView();
            dto.OptType = "UpdateProvince";
            dto.Code = item.Code;
            dto.Name = item.Name;
            dto.ID = item.ID;
            //根据国家/地区编码查找实体
            var lg = repository.Context.Queryable<Country>().Where(q => q.ID == item.Country)?.First();
            if (lg != null)
            {
                dto.CountryCode = lg.Code;
                dto.CountryName = lg.Name;
            }
            return dto;
        }

        public PubResponse UploadProvince(MemoryStream stream)
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
                    List<Province> lstCtry = new List<Province>();
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    foreach (var worksheet in lst)
                    {
                        var rowCount = worksheet.Dimension.Rows;//行
                        var columnCount = worksheet.Dimension.Columns;//列
                        if (rowCount < 2)
                            throw new Exception(string.Format("Sheet[{0}]数据不能为空！", worksheet.Name));
                        for (int row = 2; row <= rowCount; row++)
                        {
                            //第一列：国家/地区
                            string CountryName = string.Empty;
                            //第二列：编码
                            string Code = string.Empty;
                            //第三列：名称
                            string Name = string.Empty;


                            for (int col = 1; col <= columnCount; col++)
                            {
                                var cellValue = worksheet.GetValue(row, col) != null ? worksheet.GetValue(row, col).ToString() : "";
                                if (cellValue == null)
                                    continue;
                                if (col == 1)
                                    CountryName = cellValue.ToString();
                                else if (col == 2)
                                    Code = cellValue.ToString();
                                else if (col == 3)
                                    Name = cellValue.ToString();

                            }

                            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name))
                                continue;
                            if (dic.ContainsKey(Code) || dic.ContainsValue(Name))
                                throw new Exception(string.Format("Sheet[{0}]编码或名称已重复，请检查！", worksheet.Name));
                            dic.Add(Code, Name);
                            Province head = repository.GetFirst(q => q.Code == Code || q.Name == Name);
                            if (head != null)
                                throw new Exception(string.Format("编码为【{0}】的省/自治区已存在！", Code));
                            head = Province.Create();
                            head.Code = Code;
                            head.Name = Name;
                            long CountryID = 0;
                            var lg = repository.Context.Queryable<Country>().Where(q => q.Name == CountryName)?.First();
                            if (lg == null)
                                throw new Exception(string.Format("国家/地区【{0}】不存在！",CountryName));
                                CountryID = lg.ID;
                            head.Country = CountryID;
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

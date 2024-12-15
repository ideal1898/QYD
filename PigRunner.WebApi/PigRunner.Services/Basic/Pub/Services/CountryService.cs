using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using PigRunner.DTO.Basic;
using PigRunner.Entitys.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Basic;
using PigRunner.Services.Basic.IServices;
using System.IO;

namespace PigRunner.Services.Basic.Services
{
    /// <summary>
    /// 国家
    /// </summary>
    public class CountryService : ICountryService
    {
        private CountryRepository repository;
        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="_lotMasterRepository"></param>
        public CountryService(CountryRepository _repository)
        {
            this.repository = _repository;
        }

        /// <summary>
        /// 国家地区增删改查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionCountry(CountryView request)
        {
            PubResponse response = new PubResponse();

            try
            {
                if (request.OptType.Equals("AddCountry") || request.OptType.Equals("UpdateCountry"))
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    if (string.IsNullOrEmpty(request.Name))
                        throw new Exception("名称不能为空！");
                    Country head = repository.GetFirst(q => q.Code == request.Code);

                    if (request.OptType.Equals("AddCountry"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("编码为【{0}】的国家/地区已存在，不能再新增！", request.Code));
                        else
                            head = Country.Create();
                    }
                    else
                    {
                        if (request.ID <= 0)
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID == request.ID);
                        if (head == null)
                            throw new Exception(string.Format("ID为【{0}】的国家/地区不存在，请检查！", request.ID));

                    }

                    Country oldHead = repository.GetFirst(q => (q.Code == request.Code||q.Name==request.Name)&& q.ID!=head.ID);
                    if(oldHead != null)
                        throw new Exception(string.Format("编码为【{0}】或者名称为【{1}】的国家/地区已存在，请检查！", request.Code,request.Name));

                    head.Code = request.Code;
                    head.Name = request.Name;
                    head.CountryFormat = request.CountryFormat;
                    head.Currency = request.Currency;
                    head.Language = request.Language;
                    head.NameFormat = request.NameFormat;
                    head.TimeZone = request.TimeZone;
                    response.id = head.ID;

                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("国家/地区新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelCountry"))
                {
                    if (string.IsNullOrEmpty(request.Code) &&( request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("编码不能为空！");
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        deleteCountry(request.Code);
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            deleteCountry(item);
                        }
                    }
                }
                else if (request.OptType.Equals("QueryCountry"))
                {
                    int total = 0;
                    List<CountryView> list = new List<CountryView>();
                    var lst = repository.AsQueryable().ToOffsetPage(request.Current,request.Size,ref total);

                    if(!string.IsNullOrEmpty(request.Code)&& !string.IsNullOrEmpty(request.Name))
                        lst = repository.AsQueryable().Where(q=>q.Code.Contains(request.Code)&&q.Name.Contains(request.Name)).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.Code))
                        lst = repository.AsQueryable().Where(q => q.Code.Contains(request.Code)).ToOffsetPage(request.Current, request.Size, ref total);
                    else if (!string.IsNullOrEmpty(request.Name))
                        lst = repository.AsQueryable().Where(q =>  q.Name.Contains(request.Name)).ToOffsetPage(request.Current, request.Size, ref total);

                    if (lst != null && lst.Count > 0)
                    {
                        int lineNum = 1;
                        foreach (var item in lst)
                        {
                            CountryView dto = SetValue(item);
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
        private void deleteCountry(string Code)
        {
            Country head = repository.GetFirst(q => q.Code == Code);
            if (head == null)
                throw new Exception(string.Format("编码为【{0}】的国家/地区不存在！", Code));

            //检查是否被省份引用
            var oldData = repository.Context.Queryable<Province>().Where(q => q.Country == head.ID)?.First();
            if (oldData != null)
                throw new Exception(string.Format("国家/地区【{0}】已被省份及自治区所引用，不能删除！", head.Name));

            bool isSuccess = repository.Delete(head);
            if (!isSuccess)
                throw new Exception("删除失败！");
        }

        private CountryView SetValue(Country item)
        {
            CountryView dto = new CountryView();
            dto.OptType = "UpdateCountry";
            dto.Code = item.Code;
            dto.Name = item.Name;
            dto.ID = item.ID;
            dto.Language = item.Language;
            var lg = repository.Context.Queryable<Language>().Where(q => q.ID == item.Language)?.First();
            if (lg != null)
                dto.LanguageName = lg.Name;

            dto.CountryFormat = item.CountryFormat;
            var cf = repository.Context.Queryable<CountryFormat>().Where(q => q.ID == item.CountryFormat)?.First();
            if (cf != null)
                dto.CountryFormatName = cf.Name;

            dto.Currency = item.Currency;
            var cy = repository.Context.Queryable<Currency>().Where(q => q.ID == item.Currency)?.First();
            if (cy != null)
                dto.CurrencyName = cy.Name;

            dto.NameFormat = item.NameFormat;
            var nf = repository.Context.Queryable<NameFormat>().Where(q => q.ID == item.NameFormat)?.First();
            if (nf != null)
                dto.NameFormatName = nf.Name;

            dto.TimeZone = item.TimeZone;
            var tz = repository.Context.Queryable<Entitys.Basic.TimeZone>().Where(q => q.ID == item.TimeZone)?.First();
            if (tz != null)
                dto.TimeZoneName = tz.Name;

            return dto;
        }

        public PubResponse UploadCountry(MemoryStream stream)
        {
            PubResponse response = new PubResponse();
            try
            {
                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    if (package.Workbook == null || package.Workbook.Worksheets == null || package.Workbook.Worksheets.Count <= 0)
                        throw new Exception("Excel内容不能为空！");
                    var lst=package.Workbook.Worksheets.Cast<ExcelWorksheet>().Where(q=>q.Dimension!=null).ToList();
                    if (lst == null || lst.Count <= 0)
                        throw new Exception("Excel的sheet内容不能为空！");
                    List<Country> lstCtry = new List<Country>();
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    foreach (var worksheet in lst)
                    {
                        var rowCount = worksheet.Dimension.Rows;//行
                        var columnCount = worksheet.Dimension.Columns;//列
                        if (rowCount < 2)
                            throw new Exception(string.Format("Sheet[{0}]数据不能为空！",worksheet.Name));
                        for (int row = 2; row <= rowCount; row++)
                        {
                            //第一列：编码
                            string Code = string.Empty;
                            //第二列：名称
                            string Name = string.Empty;
                            //第三列：时区
                            string TimeZoneName = string.Empty;
                            //第四列：地址格式
                            string CountryFormatName = string.Empty;
                            //第5列：币种
                            string CurrencyName = string.Empty;
                            //第6列：语言
                            string LanguageName = string.Empty;

                            for (int col = 1; col <= columnCount; col++)
                            {
                                var cellValue = worksheet.GetValue(row, col) != null ? worksheet.GetValue(row, col).ToString() : "";
                                if (cellValue == null)
                                    continue;
                                if (col == 1)
                                    Code = cellValue.ToString();
                                else if (col == 2)
                                    Name = cellValue.ToString();
                                else if (col == 3)
                                    TimeZoneName = cellValue.ToString();
                                else if (col == 4)
                                    CountryFormatName = cellValue.ToString();
                                else if (col == 5)
                                    CurrencyName = cellValue.ToString();
                                else if (col == 6)
                                    LanguageName = cellValue.ToString();
                            }

                            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name))
                                continue;
                            if (dic.ContainsKey(Code) || dic.ContainsValue(Name))
                                throw new Exception(string.Format("Sheet[{0}]编码或名称已重复，请检查！", worksheet.Name));
                            dic.Add(Code, Name);
                            Country head = repository.GetFirst(q => q.Code == Code|| q.Name == Name);
                            if (head != null)
                                throw new Exception(string.Format("编码为【{0}】的国家/地区已存在！", Code));
                            head = Country.Create();
                            head.Code = Code;
                            head.Name = Name;
                            long CountryFormatV = 0;
                            if (!string.IsNullOrEmpty(CountryFormatName))
                            {
                                var cf = repository.Context.Queryable<CountryFormat>().Where(q => q.Name == CountryFormatName)?.First();
                                if (cf == null)
                                    throw new Exception(string.Format("Sheet[{0}]地址格式【{1}】不存在，请检查！", worksheet.Name, CountryFormatName));
                                CountryFormatV = cf.ID;
                            }
                            head.CountryFormat = (int)CountryFormatV;
                            long CurrencyV = 0;
                            if (!string.IsNullOrEmpty(CurrencyName))
                            {
                                var cf = repository.Context.Queryable<Currency>().Where(q => q.Name == CurrencyName)?.First();
                                if (cf == null)
                                    throw new Exception(string.Format("Sheet[{0}]币种【{1}】不存在，请检查！", worksheet.Name, CurrencyName));
                                CurrencyV = cf.ID;
                            }
                            head.Currency = (int)CurrencyV;
                            long LanguageV = 0;
                            if (!string.IsNullOrEmpty(LanguageName))
                            {
                                var cf = repository.Context.Queryable<Language>().Where(q => q.Name == LanguageName)?.First();
                                if (cf == null)
                                    throw new Exception(string.Format("Sheet[{0}]语言【{1}】不存在，请检查！", worksheet.Name, LanguageName));
                                LanguageV = cf.ID;
                            }
                            head.Language = (int)LanguageV;

                            long TimeZoneV = 0;
                            if (!string.IsNullOrEmpty(TimeZoneName))
                            {
                                var cf = repository.Context.Queryable<Entitys.Basic.TimeZone>().Where(q => q.Name == TimeZoneName)?.First();
                                if (cf == null)
                                    throw new Exception(string.Format("Sheet[{0}]时区【{1}】不存在，请检查！", worksheet.Name, TimeZoneName));
                                TimeZoneV = cf.ID;
                            }
                            head.TimeZone = (int)TimeZoneV;

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

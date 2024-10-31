using Newtonsoft.Json.Linq;
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
        public PubResponse ActionCountry(CountryVo request)
        {
            PubResponse response = new PubResponse();

            try
            {


                if (request.OptType == 0 || request.OptType == 1)
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    Country head = repository.GetFirst(q => q.Code == request.Code);

                    if(request.OptType == 0)
                    {
                        if(head != null)
                        throw new Exception(string.Format("编码为【{0}】的国家地区已存在，不能再新增！",request.Code));
                        else
                            head = Country.Create();
                    }
                    else
                    {
                        if (request.ID <= 0)
                            throw new Exception("修改ID要大于零！");
                        head = repository.GetFirst(q => q.ID == request.ID);
                            if (head == null)
                                throw new Exception(string.Format("ID为【{0}】的国家地区不存在，请检查！", request.ID));
                    }
                    
                    head.Code = request.Code;
                    head.Name = request.Name;
                    head.CountryFormat = request.CountryFormatV;
                    head.Currency = request.CurrencyV;
                    head.Language = request.LanguageV;
                    head.NameFormat = request.NameFormatV;
                    head.TimeZone = request.TimeZoneV;
                    response.id = head.ID;

                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("国家地区新增/修改操作失败！");
                }
                else if (request.OptType == 2)
                {
                    if (string.IsNullOrEmpty(request.Code))
                        throw new Exception("编码不能为空！");
                    Country head = repository.GetFirst(q => q.Code == request.Code);
                    if (head == null)
                        throw new Exception(string.Format("编码为【{0}】的国家地区不存在！", request.Code));

                    bool isSuccess = repository.Delete(head);
                    if (!isSuccess)
                        throw new Exception("删除失败！");
                }
                else if (request.OptType == 3)
                {
                    List<CountryVo> list = new List<CountryVo>();

                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        Country item = repository.GetFirst(q => q.Code == request.Code);
                        if (item == null)
                            throw new Exception(string.Format("编码为【{0}】的国家地区不存在！", request.Code));
                        CountryVo dto = SetValue(item);
                        dto.LineNum = 10;
                        list.Add(dto);
                    }
                    else
                    {

                        var lst = repository.Context.Queryable<Country>().ToList();
                        int lineNum = 10;
                        foreach (var item in lst)
                        {
                            CountryVo dto = SetValue(item);
                            dto.LineNum = lineNum;
                            list.Add(dto);
                            lineNum += 10;
                        }
                    }
                    response.data = JArray.FromObject(list);
                }
                else if (request.OptType == 4)
                {
                    List<EnumVo> lst= new List<EnumVo>();
                    for (int i = 0; i < 3; i++)
                    {
                        EnumVo dto = new EnumVo();
                        dto.value = i.ToString();
                        dto.label = "币种" + i.ToString();
                        lst.Add(dto);
                    }
                    response.data= JArray.FromObject(lst);
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

        private CountryVo SetValue(Country item)
        {
            CountryVo dto = new CountryVo();
            dto.OptType = 1;
            dto.Code = item.Code;
            dto.Name = item.Name;
            dto.ID = item.ID;
            dto.LanguageV = item.Language;
            if (dto.LanguageV == 0)
                dto.Language = "中文";
            else if (dto.LanguageV == 1)
                dto.Language = "外语";

            dto.CountryFormatV = item.CountryFormat;
            if (dto.CountryFormatV == 0)
                dto.CountryFormat = "中国大陆";
            else if (dto.CountryFormatV == 1)
                dto.CountryFormat = "境外地址";

            dto.CurrencyV = item.Currency;
            if (dto.CurrencyV == 0)
                dto.Currency = "人民币";
            else if (dto.CurrencyV == 1)
                dto.Currency = "外币";

            dto.NameFormatV = item.NameFormat;
            if (dto.NameFormatV == 0)
                dto.NameFormat = "先姓后名";
            else if (dto.NameFormatV == 1)
                dto.NameFormat = "先名后姓";

            dto.TimeZoneV = item.TimeZone;
            if (dto.TimeZoneV == 0)
                dto.TimeZone = "东八区";
            else if (dto.TimeZoneV == 1)
                dto.TimeZone = "UTC+8:00（北京、上海、重庆、乌鲁木齐）";
            return dto;
        }

    }
}

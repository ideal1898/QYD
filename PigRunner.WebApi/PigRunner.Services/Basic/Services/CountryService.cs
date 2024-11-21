using Newtonsoft.Json.Linq;
using PigRunner.DTO.Basic;
using PigRunner.Entitys.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Basic;
using PigRunner.Services.Basic.IServices;


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
                    Country head = repository.GetFirst(q => q.Code == request.Code);

                    if (request.OptType.Equals("AddCountry"))
                    {
                        if (head != null)
                            throw new Exception(string.Format("编码为【{0}】的国家地区已存在，不能再新增！", request.Code));
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
                    head.CountryFormat = request.CountryFormat;
                    head.Currency = request.Currency;
                    head.Language = request.Language;
                    head.NameFormat = request.NameFormat;
                    head.TimeZone = request.TimeZone;
                    response.id = head.ID;

                    bool isSuccess = repository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("国家地区新增/修改操作失败！");
                }
                else if (request.OptType.Equals("DelCountry"))
                {
                    if (string.IsNullOrEmpty(request.Code) &&( request.Codes == null || request.Codes.Count <= 0))
                        throw new Exception("编码不能为空！");
                    if (!string.IsNullOrEmpty(request.Code))
                    {
                        Country head = repository.GetFirst(q => q.Code == request.Code);
                        if (head == null)
                            throw new Exception(string.Format("编码为【{0}】的国家地区不存在！", request.Code));

                        bool isSuccess = repository.Delete(head);
                        if (!isSuccess)
                            throw new Exception("删除失败！");
                    }
                    else
                    {
                        foreach (var item in request.Codes)
                        {
                            Country head = repository.GetFirst(q => q.Code == item);
                            if (head == null)
                                throw new Exception(string.Format("编码为【{0}】的国家地区不存在！", request.Code));

                            bool isSuccess = repository.Delete(head);
                            if (!isSuccess)
                                throw new Exception("删除失败！");
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
                        int lineNum = 10;
                        foreach (var item in lst)
                        {
                            CountryView dto = SetValue(item);
                            dto.LineNum = lineNum;
                            list.Add(dto);
                            lineNum += 10;
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

    }
}

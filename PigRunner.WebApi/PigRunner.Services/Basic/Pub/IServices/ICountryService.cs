using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;

namespace PigRunner.Services.Basic.IServices
{
    public interface ICountryService : IScopedService
    {
        /// <summary>
        /// 国家地区
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PubResponse ActionCountry(CountryView request);


        PubResponse UploadCountry(MemoryStream file);
    }
}

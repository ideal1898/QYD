using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Basic.IServices;
using PigRunner.Services.System.IServices;

namespace PigRunner.WebApi.Controllers.Basic
{
    /// <summary>
    /// 国家/地区
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public CountryController(ICountryService _services)
        {
            this.services = _services;
        }
        /// <summary>
        /// 国家地区
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse ActionCountry(CountryVo request)
        {
            return services.ActionCountry(request);
        }
    }
}

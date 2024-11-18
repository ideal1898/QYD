using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Basic.IServices;

namespace PigRunner.WebApi.Controllers.Basic
{
    /// <summary>
    /// 币种
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private ICurrencyService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public CurrencyController(ICurrencyService _services)
        {
            this.services = _services;
        }
        /// <summary>
        /// 币种
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]//设置不需要token值即可调用
        [HttpPost]
        public PubResponse ActionCurrency(EnumView request)
        {
            return services.ActionCurrency(request);
        }
    }
}

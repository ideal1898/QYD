using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Basic.IServices;

namespace PigRunner.WebApi.Controllers.Basic
{
     /// <summary>
     /// 语言
     /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private ILanguageService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public LanguageController(ILanguageService _services)
        {
            this.services = _services;
        }
        /// <summary>
        /// 语言
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]//设置不需要token值即可调用
        [HttpPost]
        public PubResponse ActionLanguage(EnumView request)
        {
            return services.ActionLanguage(request);
        }
    }
}

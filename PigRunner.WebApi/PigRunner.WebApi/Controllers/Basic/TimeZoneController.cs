using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Basic.IServices;

namespace PigRunner.WebApi.Controllers.Basic
{
   /// <summary>
   /// 时区
   /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TimeZoneController : ControllerBase
    {
        private ITimeZoneService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public TimeZoneController(ITimeZoneService _services)
        {
            this.services = _services;
        }
        /// <summary>
        /// 时区
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]//设置不需要token值即可调用
        [HttpPost]
        public PubResponse ActionTimeZone(EnumView request)
        {
            return services.ActionTimeZone(request);
        }
    }
}

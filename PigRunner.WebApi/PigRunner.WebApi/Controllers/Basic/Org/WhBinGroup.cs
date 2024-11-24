using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Basic.IServices;
using PigRunner.Services.Sys.IServices;

namespace PigRunner.WebApi.Controllers.Basic
{
    /// <summary>
    /// Model.ClassName
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WhBinGroupController : ControllerBase
    {
        
        private IWhBinGroupService services;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public WhBinGroupController(IWhBinGroupService _services)
        {
            this.services = _services;
        }

        /// <summary>
        /// 库区
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        
        public PubResponse ActionWhBinGroup(WhBinGroupVo request)
        {
            return services.ActionWhBinGroup(request);
        }
    }


    
    
}
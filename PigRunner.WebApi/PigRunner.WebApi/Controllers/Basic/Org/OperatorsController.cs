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
    public class OperatorsController : ControllerBase
    {
        
        private IOperatorsService services;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public OperatorsController(IOperatorsService _services)
        {
            this.services = _services;
        }

        /// <summary>
        /// 业务员
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        
        public PubResponse ActionOperators(OperatorsVo request)
        {
            return services.ActionOperators(request);
        }
    }


    
    
}
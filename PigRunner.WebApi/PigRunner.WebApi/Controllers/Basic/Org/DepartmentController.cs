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
    public class DepartmentController : ControllerBase
    {
        
        private IDepartmentService services;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public DepartmentController(IDepartmentService _services)
        {
            this.services = _services;
        }

        /// <summary>
        /// 部门
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        
        public PubResponse ActionDepartment(DepartmentVo request)
        {
            return services.ActionDepartment(request);
        }
    }


    
    
}
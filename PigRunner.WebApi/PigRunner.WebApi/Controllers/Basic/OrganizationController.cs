
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Basic.IServices;
namespace PigRunner.WebApi.Controllers.Basic
{
    /// <summary>
    /// 组织
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private IOrganizationService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public OrganizationController(IOrganizationService _services)
        {
            this.services = _services;
        }
        /// <summary>
        /// 组织
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse ActionOrganization(OrganizationView request)
        {
            return services.ActionOrganization(request);
        }
    }
}

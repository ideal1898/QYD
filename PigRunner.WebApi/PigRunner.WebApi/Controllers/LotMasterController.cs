using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Sys.IServices;

namespace PigRunner.WebApi.Controllers
{
    /// <summary>
    /// 批号
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LotMasterController : ControllerBase
    {
        private ILotMasterService loginServices;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_loginServices"></param>
        public LotMasterController(ILotMasterService _loginServices)
        {
            this.loginServices = _loginServices;
        }
        /// <summary>
        /// 批号
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse ActionLotMaster(LotMasterRequest request)
        {
            return loginServices.ActionLotMaster(request);
        }
    }
}

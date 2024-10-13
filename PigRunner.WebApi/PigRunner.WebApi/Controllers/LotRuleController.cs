using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.Public.Common.Views;
using PigRunner.Services.System.IServices;

namespace PigRunner.WebApi.Controllers
{
   /// <summary>
   /// 批次规则
   /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LotRuleController : ControllerBase
    {
        private ILotRuleService loginServices;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_loginServices"></param>
        public LotRuleController(ILotRuleService _loginServices)
        {
            this.loginServices = _loginServices;
        }
        /// <summary>
        /// 批号规则
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse ActionLotMaster(LotRlueRequest request)
        {
            return loginServices.ActionLotRule(request.RuleCode, request.RuleName, request.Org, request.RuleDes, request.Memo, request.BCLotRuleLines, request.OptType);
        }
    }
}

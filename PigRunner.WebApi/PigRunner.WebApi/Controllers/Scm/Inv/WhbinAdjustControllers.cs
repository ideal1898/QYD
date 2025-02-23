using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Scm.Inv;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Scm.Inv.IServices;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers.Basic
{
    /// <summary>
    /// 货位调整单头
    /// </summary>
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WhbinAdjustController: ControllerBase
    {
        private IWhbinAdjustService iWhbinAdjustService;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param _WhbinAdjustService></param>
        public WhbinAdjustController(IWhbinAdjustService _iWhbinAdjustService)
        {
            this.iWhbinAdjustService = _iWhbinAdjustService;
        }

        /// <summary>
        /// 新增货位调整单头
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] WhbinAdjustView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = iWhbinAdjustService.InsertWhbinAdjust(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有货位调整单头
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult queryWhbinAdjust(int current=1,int size=20 )
        {
            return Ok(iWhbinAdjustService.QueryWhbinAdjust(current, size));
        }

    }
}
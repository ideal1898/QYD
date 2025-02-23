using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Scm.Inv;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Scm.Inv.IServices;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers.Basic
{
    /// <summary>
    /// 货位调整单行
    /// </summary>

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WhbinAdjustLineController: ControllerBase
    {
        private IWhbinAdjustLineService iWhbinAdjustLineService;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param _WhbinAdjustLineService></param>
        public WhbinAdjustLineController(IWhbinAdjustLineService _iWhbinAdjustLineService)
        {
            this.iWhbinAdjustLineService = _iWhbinAdjustLineService;
        }

        /// <summary>
        /// 新增货位调整单行
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] WhbinAdjustLineView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = iWhbinAdjustLineService.InsertWhbinAdjustLine(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有货位调整单行
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult queryWhbinAdjustLine(int current=1,int size=20 )
        {
            return Ok(iWhbinAdjustLineService.QueryWhbinAdjustLine(current, size));
        }

    }
}
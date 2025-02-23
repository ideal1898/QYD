using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Scm.Inv;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Scm.Inv.IServices;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers.Basic
{
    /// <summary>
    /// 杂收单行
    /// </summary>

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MiscRcvTransLineController: ControllerBase
    {
        private IMiscRcvTransLineService iMiscRcvTransLineService;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param _MiscRcvTransLineService></param>
        public MiscRcvTransLineController(IMiscRcvTransLineService _iMiscRcvTransLineService)
        {
            this.iMiscRcvTransLineService = _iMiscRcvTransLineService;
        }

        /// <summary>
        /// 新增杂收单行
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] MiscRcvTransLineView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = iMiscRcvTransLineService.InsertMiscRcvTransLine(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有杂收单行
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult queryMiscRcvTransLine(int current=1,int size=20 )
        {
            return Ok(iMiscRcvTransLineService.QueryMiscRcvTransLine(current, size));
        }

    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Scm.Inv;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Scm.Inv.IServices;
using PigRunner.Services.Sys.IServices;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers.Basic
{
    /// <summary>
    /// 杂发单行
    /// </summary>
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MiscShipLineController: ControllerBase
    {
        private IMiscShipLineService iMiscShipLineService;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param _MiscShipLineService></param>
        public MiscShipLineController(IMiscShipLineService _iMiscShipLineService)
        {
            this.iMiscShipLineService = _iMiscShipLineService;
        }

        /// <summary>
        /// 新增杂发单行
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] MiscShipLineView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = iMiscShipLineService.InsertMiscShipLine(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有杂发单行
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult queryMiscShipLine(int current=1,int size=20 )
        {
            return Ok(iMiscShipLineService.QueryMiscShipLine(current, size));
        }

    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Scm.Inv;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Scm.Inv.IServices;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers.Basic
{
    /// <summary>
    /// 杂发单头
    /// </summary>
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MiscShipController: ControllerBase
    {
        private IMiscShipService iMiscShipService;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param _MiscShipService></param>
        public MiscShipController(IMiscShipService _iMiscShipService)
        {
            this.iMiscShipService = _iMiscShipService;
        }

        /// <summary>
        /// 新增杂发单头
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] MiscShipView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = iMiscShipService.InsertMiscShip(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有杂发单头
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult queryMiscShip(int current=1,int size=20 )
        {
            return Ok(iMiscShipService.QueryMiscShip(current, size));
        }

    }
}
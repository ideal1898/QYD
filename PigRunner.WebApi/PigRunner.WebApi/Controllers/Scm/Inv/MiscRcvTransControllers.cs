using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Scm.Inv;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Scm.Inv.IServices;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers.Basic
{
    /// <summary>
    /// 杂收单头
    /// </summary>

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MiscRcvTransController: ControllerBase
    {
        private IMiscRcvTransService iMiscRcvTransService;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param _MiscRcvTransService></param>
        public MiscRcvTransController(IMiscRcvTransService _iMiscRcvTransService)
        {
            this.iMiscRcvTransService = _iMiscRcvTransService;
        }

        /// <summary>
        /// 新增杂收单头
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] MiscRcvTransView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = iMiscRcvTransService.InsertMiscRcvTrans(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有杂收单头
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult queryMiscRcvTrans(int current=1,int size=20 )
        {
            return Ok(iMiscRcvTransService.QueryMiscRcvTrans(current, size));
        }

    }
}
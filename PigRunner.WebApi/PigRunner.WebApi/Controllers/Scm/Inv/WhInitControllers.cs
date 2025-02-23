using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Scm.Inv;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Scm.Inv.IServices;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers.Basic
{
    /// <summary>
    /// 期初入库单头
    /// </summary>
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WhInitController: ControllerBase
    {
        private IWhInitService iWhInitService;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param _WhInitService></param>
        public WhInitController(IWhInitService _iWhInitService)
        {
            this.iWhInitService = _iWhInitService;
        }

        /// <summary>
        /// 新增期初入库单头
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] WhInitView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = iWhInitService.InsertWhInit(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有期初入库单头
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult queryWhInit(int current=1,int size=20 )
        {
            return Ok(iWhInitService.QueryWhInit(current, size));
        }

    }
}
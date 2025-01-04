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
    /// 期初入库单行
    /// </summary>

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WhInitLineController: ControllerBase
    {
        private IWhInitLineService iWhInitLineService;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param _WhInitLineService></param>
        public WhInitLineController(IWhInitLineService _iWhInitLineService)
        {
            this.iWhInitLineService = _iWhInitLineService;
        }

        /// <summary>
        /// 新增期初入库单行
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] WhInitLineView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = iWhInitLineService.InsertWhInitLine(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有期初入库单行
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult queryWhInitLine(int current=1,int size=20 )
        {
            return Ok(iWhInitLineService.QueryWhInitLine(current, size));
        }

    }
}
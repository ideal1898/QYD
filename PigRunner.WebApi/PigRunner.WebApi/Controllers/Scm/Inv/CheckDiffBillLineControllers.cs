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
    /// 店铺
    /// </summary>
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CheckDiffBillLineController: ControllerBase
    {
        private ICheckDiffBillLineService iCheckDiffBillLineService;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param _CheckDiffBillLineService></param>
        public CheckDiffBillLineController(ICheckDiffBillLineService _iCheckDiffBillLineService)
        {
            this.iCheckDiffBillLineService = _iCheckDiffBillLineService;
        }
        
        /// <summary>
        /// 新增盘点单行
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] CheckDiffBillLineView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = iCheckDiffBillLineService.InsertCheckDiffBillLine(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有盘点单行
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult queryCheckDiffBillLine(int current=1,int size=20 )
        {
            return Ok(iCheckDiffBillLineService.QueryCheckDiffBillLine(current, size));
        }

    }
}
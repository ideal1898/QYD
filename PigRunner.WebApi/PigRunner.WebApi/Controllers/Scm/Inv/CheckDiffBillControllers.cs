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
    /// 
    /// </summary>
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CheckDiffBillController: ControllerBase
    {
        private ICheckDiffBillService iCheckDiffBillService;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param _CheckDiffBillService></param>
        public CheckDiffBillController(ICheckDiffBillService _iCheckDiffBillService)
        {
            this.iCheckDiffBillService = _iCheckDiffBillService;
        }
        
        /// <summary>
        /// 新增盘点单头
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] CheckDiffBillView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = iCheckDiffBillService.InsertCheckDiffBill(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有盘点单头
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult queryCheckDiffBill(int current=1,int size=20 )
        {
            return Ok(iCheckDiffBillService.QueryCheckDiffBill(current, size));
        }

    }
}
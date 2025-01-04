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
    /// 调拨单行
    /// </summary>

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransferLineController: ControllerBase
    {
        private ITransferLineService iTransferLineService;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param _TransferLineService></param>
        public TransferLineController(ITransferLineService _iTransferLineService)
        {
            this.iTransferLineService = _iTransferLineService;
        }

        /// <summary>
        /// 新增调拨单行
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] TransferLineView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = iTransferLineService.InsertTransferLine(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有调拨单行
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult queryTransferLine(int current=1,int size=20 )
        {
            return Ok(iTransferLineService.QueryTransferLine(current, size));
        }

    }
}
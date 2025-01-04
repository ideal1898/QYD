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
    /// 调拨单头
    /// </summary>
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransferController: ControllerBase
    {
        private ITransferService iTransferService;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param _TransferService></param>
        public TransferController(ITransferService _iTransferService)
        {
            this.iTransferService = _iTransferService;
        }

        /// <summary>
        /// 新增调拨单头
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] TransferView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = iTransferService.InsertTransfer(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有调拨单头
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult queryTransfer(int current=1,int size=20 )
        {
            return Ok(iTransferService.QueryTransfer(current, size));
        }

    }
}
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
    /// 形态转换单行
    /// </summary>

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransferFormLineController: ControllerBase
    {
        private ITransferFormLineService iTransferFormLineService;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param _TransferFormLineService></param>
        public TransferFormLineController(ITransferFormLineService _iTransferFormLineService)
        {
            this.iTransferFormLineService = _iTransferFormLineService;
        }

        /// <summary>
        /// 新增形态转换单行
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] TransferFormLineView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = iTransferFormLineService.InsertTransferFormLine(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有形态转换单行
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult queryTransferFormLine(int current=1,int size=20 )
        {
            return Ok(iTransferFormLineService.QueryTransferFormLine(current, size));
        }

    }
}
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
    /// 形态转换单头
    /// </summary>
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransferFormController: ControllerBase
    {
        private ITransferFormService iTransferFormService;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param _TransferFormService></param>
        public TransferFormController(ITransferFormService _iTransferFormService)
        {
            this.iTransferFormService = _iTransferFormService;
        }

        /// <summary>
        /// 新增形态转换单头
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] TransferFormView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = iTransferFormService.InsertTransferForm(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有形态转换单头
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult queryTransferForm(int current=1,int size=20 )
        {
            return Ok(iTransferFormService.QueryTransferForm(current, size));
        }

    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigRunner.Public.Common.Views;
using PigRunner.Services.System;
using PigRunner.Services.System.IServices;

namespace PigRunner.WebApi.Controllers
{
    /// <summary>
    /// 批号
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LotMasterController : ControllerBase
    {
        private ILotMasterService loginServices;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_loginServices"></param>
        public LotMasterController(ILotMasterService _loginServices)
        {
            this.loginServices = _loginServices;
        }
        /// <summary>
        /// 批号
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse InsertLotMaster(LotMasterRequest request)
        {
            return loginServices.InsertLotMaster(request.LotCode, request.ItemMaster, request.Org, request.EffectiveDate, request.ValidDate, request.InvalidDate, request.SrcDocNo, request.AutoCode, request.Memo);
        }
    }
}

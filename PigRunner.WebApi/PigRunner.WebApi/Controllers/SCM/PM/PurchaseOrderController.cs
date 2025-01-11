using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PigRunner.DTO.SCM.PM;
using PigRunner.Public.Common.Views;
using PigRunner.Services.SCM.PM.IServices;

namespace PigRunner.WebApi.Controllers.SCM.PM
{
    /// <summary>
    /// 采购订单接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PurchaseOrderController:ControllerBase
    {
        /// <summary>
        /// 采购订单服务
        /// </summary>
        private IPurchaseOrderService purchaseOrderService;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_service"></param>
        public PurchaseOrderController(IPurchaseOrderService _service) { 
        this.purchaseOrderService = _service;
        }
        #region 业务处理
        /// <summary>
        /// 创建采购订单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody save([FromBody] PurchaseOrderView vo) { 
            return purchaseOrderService.Save(vo);
        }
        
        /// <summary>
        /// 删除采购订单
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody delete([FromBody] List<long> ids) {
            return purchaseOrderService.Delete(ids);
        }

        #endregion

        #region 查询
        /// <summary>
        /// 查询采购订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseBusBody queryItemById([FromQuery] long id)
        {
            return purchaseOrderService.QueryItemById(id);
        }

        #endregion
    }
}

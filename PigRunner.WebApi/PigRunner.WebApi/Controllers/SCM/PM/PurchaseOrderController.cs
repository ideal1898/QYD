using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PigRunner.DTO.CommonView;
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
    public class PurchaseOrderController : ControllerBase
    {
        /// <summary>
        /// 采购订单服务
        /// </summary>
        private IPurchaseOrderService purchaseOrderService;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_service"></param>
        public PurchaseOrderController(IPurchaseOrderService _service)
        {
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
        public ResponseBusBody save([FromBody] PurchaseOrderView vo)
        {
            return purchaseOrderService.Save(vo);
        }

        /// <summary>
        /// 删除采购订单
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody delete([FromBody] List<long> ids)
        {
            return purchaseOrderService.Delete(ids);
        }
        /// <summary>
        /// 提交采购订单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody submit([FromBody] PurchaseOrderView vo)
        {
            return purchaseOrderService.Submit(vo);
        }

        /// <summary>
        /// 审核采购订单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody approve([FromBody] PurchaseOrderView vo)
        {
            return purchaseOrderService.Approve(vo);
        }
        /// <summary>
        /// 弃审采购订单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody unapprove([FromBody] PurchaseOrderView vo)
        {
            return purchaseOrderService.UnApprove(vo);
        }

        /// <summary>
        /// 批量提交采购订单
        /// </summary>
        /// <param name="vos"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody batchSubmit([FromBody] List<DoActionView> vos)
        {
            return purchaseOrderService.BatchSubmit(vos);
        }
        /// <summary>
        /// 批量审核采购订单
        /// </summary>
        /// <param name="vos"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody batchApprove([FromBody] List<DoActionView> vos)
        {
            return purchaseOrderService.BatchApprove(vos);
        }
        /// <summary>
        /// 批量审核采购订单
        /// </summary>
        /// <param name="vos"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody batchUnApprove([FromBody] List<DoActionView> vos)
        {
            return purchaseOrderService.BatchUnApprove(vos);
        }


        #endregion

        #region 查询
        /// <summary>
        /// 通过主键查询采购订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseBusBody queryPurchseOrderById([FromQuery] long id)
        {
            return purchaseOrderService.QueryDocById(id);
        }

        /// <summary>
        /// 通过单据编号查询采购订单
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseBusBody queryPurchseOrderByDocNo([FromQuery] string DocNo)
        {
            return purchaseOrderService.QueryDocByDocNo(DocNo);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        public ResponseBody queryAllByPage([FromBody] PageView view)
        {
            return purchaseOrderService.QueryAllByPage(view);
        }

        #endregion
    }
}

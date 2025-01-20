using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.CommonView;
using PigRunner.DTO.SCM.PM;
using PigRunner.Public.Common.Views;
using PigRunner.Services.SCM.PM.IServices;
using PigRunner.Services.SCM.PM.Services;

namespace PigRunner.WebApi.Controllers.SCM.PM
{
    /// <summary>
    /// 采购送货单接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeliveryOrderController : ControllerBase
    {
        /// <summary>
        /// 采购到货服务
        /// </summary>
        private IDeliveryOrderService orderService;
        /// <summary>
        /// 服务注册
        /// </summary>
        public DeliveryOrderController(IDeliveryOrderService _orderService)
        {
            orderService = _orderService;
        }
        #region 业务处理
        /// <summary>
        /// 创建采购到货单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        public ResponseBusBody save([FromBody] DeliveryOrderView vo)
        {
            return orderService.Save(vo);
        }

        /// <summary>
        /// 删除采购到货单
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        public ResponseBusBody delete([FromBody] List<long> ids)
        {
            return orderService.Delete(ids);
        }
        /// <summary>
        /// 提交采购到货单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        public ResponseBusBody submit([FromBody] DeliveryOrderView vo)
        {
            return orderService.Submit(vo);
        }

        /// <summary>
        /// 审核采购到货单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        public ResponseBusBody approve([FromBody] DeliveryOrderView vo)
        {
            return orderService.Approve(vo);
        }
        /// <summary>
        /// 弃审采购到货单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody unapprove([FromBody] DeliveryOrderView vo)
        {
            return orderService.UnApprove(vo);
        }

        /// <summary>
        /// 批量提交采购到货单
        /// </summary>
        /// <param name="vos"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        public ResponseBody batchSubmit([FromBody] List<DoActionView> vos)
        {
            return orderService.BatchSubmit(vos);
        }
        /// <summary>
        /// 批量审核采购到货单
        /// </summary>
        /// <param name="vos"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        public ResponseBody batchApprove([FromBody] List<DoActionView> vos)
        {
            return orderService.BatchApprove(vos);
        }
        /// <summary>
        /// 批量审核采购到货单
        /// </summary>
        /// <param name="vos"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        public ResponseBody batchUnApprove([FromBody] List<DoActionView> vos)
        {
            return orderService.BatchUnApprove(vos);
        }


        #endregion

        #region 查询
        /// <summary>
        /// 通过主键查询采购到货单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpGet]
        public ResponseBusBody queryDocById([FromQuery] long id)
        {
            return orderService.QueryDocById(id);
        }

        /// <summary>
        /// 通过单据编号查询采购到货单
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseBusBody queryDocByDocNo([FromQuery] string DocNo)
        {
            return orderService.QueryDocByDocNo(DocNo);
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
            return orderService.QueryAllByPage(view);
        }

        #endregion
    }
}

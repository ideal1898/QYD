using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.CommonView;
using PigRunner.DTO.SCM.PM;
using PigRunner.Public.Common.Views;
using PigRunner.Services.SCM.PM.IServices;

namespace PigRunner.WebApi.Controllers.SCM.PM
{
    /// <summary>
    /// 采购退货申请单接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReturnRequisitionController : ControllerBase
    {
        /// <summary>
        /// 采购退货单服务
        /// </summary>
        private IRtnRequestService orderService;
        /// <summary>
        /// 服务注册
        /// </summary>
        public ReturnRequisitionController(IRtnRequestService _orderService)
        {
            orderService = _orderService;
        }
        #region 业务处理
        /// <summary>
        /// 创建采购退货单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        public ResponseBusBody save([FromBody] ReturnRequisitionView vo)
        {
            return orderService.Save(vo);
        }

        /// <summary>
        /// 删除采购退货单
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
        /// 提交采购退货单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        public ResponseBusBody submit([FromBody] ReturnRequisitionView vo)
        {
            return orderService.Submit(vo);
        }

        /// <summary>
        /// 审核采购退货单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        public ResponseBusBody approve([FromBody] ReturnRequisitionView vo)
        {
            return orderService.Approve(vo);
        }
        /// <summary>
        /// 弃审采购退货单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody unapprove([FromBody] ReturnRequisitionView vo)
        {
            return orderService.UnApprove(vo);
        }

        /// <summary>
        /// 批量提交采购退货单
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
        /// 批量审核采购退货单
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
        /// 批量审核采购退货单
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
        /// 通过主键查询采购退货单
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
        /// 通过单据编号查询采购退货单
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        //[AllowAnonymous]
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
        /// <summary>
        /// 采购申请单明细
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBody queryLineByPage([FromBody] PageView view)
        {
            return orderService.queryLineByPage(view);
        }

        #endregion
    }
}

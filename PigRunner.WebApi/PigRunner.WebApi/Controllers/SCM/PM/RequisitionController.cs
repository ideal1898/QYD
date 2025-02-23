using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.CommonView;
using PigRunner.DTO.SCM.PM;
using PigRunner.Public.Common.Views;
using PigRunner.Services.SCM.PM.IServices;

namespace PigRunner.WebApi.Controllers.SCM.PM
{
    /// <summary>
    /// 请购单接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RequisitionController : ControllerBase
    {
        /// <summary>
        /// 请购单服务
        /// </summary>
        private IRequisitionService orderService;
        /// <summary>
        /// 服务注册
        /// </summary>
        public RequisitionController(IRequisitionService _orderService)
        {
            orderService = _orderService;
        }
        #region 业务处理
        /// <summary>
        /// 创建请购单单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        public ResponseBusBody save([FromBody] RequisitionView vo)
        {
            return orderService.Save(vo);
        }

        /// <summary>
        /// 删除请购单单
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
        /// 提交请购单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        public ResponseBusBody submit([FromBody] RequisitionView vo)
        {
            return orderService.Submit(vo);
        }

        /// <summary>
        /// 审核请购单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpPost]
        public ResponseBusBody approve([FromBody] RequisitionView vo)
        {
            return orderService.Approve(vo);
        }
        /// <summary>
        /// 弃审请购单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody unapprove([FromBody] RequisitionView vo)
        {
            return orderService.UnApprove(vo);
        }

        /// <summary>
        /// 批量提交请购单
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
        /// 批量审核请购单
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
        /// 批量审核请购单
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
        /// 通过主键查询请购单
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
        /// 通过单据编号查询请购单
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
        /// 请购明细数据:未全部转单
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

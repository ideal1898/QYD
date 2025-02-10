using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.BCP.Lot;
using PigRunner.DTO.CommonView;
using PigRunner.DTO.MM.PM;
using PigRunner.Public.Common.Views;
using PigRunner.Services.MM.PM.IServices;

namespace PigRunner.WebApi.Controllers.MM.PM
{
      /// <summary>
      /// 完工入库单
      /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RcvRptController : ControllerBase
    {
        private IRcvRptService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public RcvRptController(IRcvRptService _services)
        {
            this.services = _services;
        }

        #region 业务处理
        /// <summary>
        /// 创建完工入库单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody save([FromBody] RcvRptView vo)
        {
            return services.Save(vo);
        }

        /// <summary>
        /// 删除完工入库单
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody delete([FromBody] List<long> ids)
        {
            return services.Delete(ids);
        }
        /// <summary>
        /// 提交完工入库单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody submit([FromBody] RcvRptView vo)
        {
            return services.Submit(vo);
        }

        /// <summary>
        /// 审核完工入库单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody approve([FromBody] RcvRptView vo)
        {
            return services.Approve(vo);
        }
        /// <summary>
        /// 弃审完工入库单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody unapprove([FromBody] RcvRptView vo)
        {
            return services.UnApprove(vo);
        }

        /// <summary>
        /// 批量提交完工入库单
        /// </summary>
        /// <param name="vos"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody batchSubmit([FromBody] List<DoActionView> vos)
        {
            return services.BatchSubmit(vos);
        }
        /// <summary>
        /// 批量审核完工入库单
        /// </summary>
        /// <param name="vos"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody batchApprove([FromBody] List<DoActionView> vos)
        {
            return services.BatchApprove(vos);
        }
        /// <summary>
        /// 批量审核完工入库单
        /// </summary>
        /// <param name="vos"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody batchUnApprove([FromBody] List<DoActionView> vos)
        {
            return services.BatchUnApprove(vos);
        }


        #endregion

        #region 查询
        /// <summary>
        /// 通过主键查询完工入库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseBusBody queryRcvRptById([FromQuery] long id)
        {
            return services.QueryDocById(id);
        }

        /// <summary>
        /// 通过单据编号查询完工入库单
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseBusBody queryRcvRptByDocNo([FromQuery] string DocNo)
        {
            return services.QueryDocByDocNo(DocNo);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody queryAllByPage([FromBody] PageView view)
        {
            return services.QueryAllByPage(view);
        }

        #endregion
    }
}

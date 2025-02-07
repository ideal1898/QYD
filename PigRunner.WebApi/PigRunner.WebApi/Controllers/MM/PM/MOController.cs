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
      /// 生产订单
      /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MOController : ControllerBase
    {
        private IMOService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public MOController(IMOService _services)
        {
            this.services = _services;
        }

        #region 业务处理
        /// <summary>
        /// 创建生产订单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody save([FromBody] MOView vo)
        {
            return services.Save(vo);
        }

        /// <summary>
        /// 删除生产订单
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
        /// 提交生产订单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody submit([FromBody] MOView vo)
        {
            return services.Submit(vo);
        }

        /// <summary>
        /// 审核生产订单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody approve([FromBody] MOView vo)
        {
            return services.Approve(vo);
        }
        /// <summary>
        /// 弃审生产订单
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody unapprove([FromBody] MOView vo)
        {
            return services.UnApprove(vo);
        }

        /// <summary>
        /// 批量提交生产订单
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
        /// 批量审核生产订单
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
        /// 批量审核生产订单
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
        /// 通过主键查询生产订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseBusBody queryMOById([FromQuery] long id)
        {
            return services.QueryDocById(id);
        }

        /// <summary>
        /// 通过单据编号查询生产订单
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseBusBody queryMOByDocNo([FromQuery] string DocNo)
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.BCP.Lot;
using PigRunner.DTO.SCM.MM;
using PigRunner.Public.Common.Views;
using PigRunner.Services.SCM.MM.IServices;

namespace PigRunner.WebApi.Controllers.SCM.MM
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
        /// <summary>
        /// 生产订单保存
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse MOSave([FromBody]MOView request)
        {
            return services.MOSave(request);
        }

        /// <summary>
        /// 生产订单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse MOQuery([FromBody] MOQueryView request)
        {
            return services.MOQuery(request);
        }

        /// <summary>
        /// 根据生产订单行ID查询生产订单信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse MOQueryByID([FromBody] MOLineQueryView request)
        {
            return services.MOQueryByID(request);
        }

        /// <summary>
        /// 生产订单删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse MODelete([FromBody] MODelView request)
        {
            return services.MODelete(request);
        }

        /// <summary>
        /// 生产订单提交
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse MOSubmit([FromBody] MODelView request)
        {
            return services.MOSubmit(request);
        }

        /// <summary>
        /// 生产订单删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse MOApprove([FromBody] MODelView request)
        {
            return services.MOApprove(request);
        }

        /// <summary>
        /// 生产订单弃审
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse MOUnApprove([FromBody] MODelView request)
        {
            return services.MOUnApprove(request);
        }
    }
}

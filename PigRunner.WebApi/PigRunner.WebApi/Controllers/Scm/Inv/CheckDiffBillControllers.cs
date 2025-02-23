using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.SCM.INV;
using PigRunner.Public.Common.Views;
using PigRunner.DTO.CommonView;
using PigRunner.Services.SCM.INV.IServices;

namespace PigRunner.WebApi.Controllers.SCM.INV
{
    /// <summary>
    /// 盘点单头接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CheckDiffBillController : ControllerBase
    {
        /// <summary>
        /// 盘点单头服务
        /// </summary>
        private ICheckDiffBillService checkDiffBillService;

        /// <summary>
        /// 服务注册
        /// </summary>
        public CheckDiffBillController(ICheckDiffBillService _checkDiffBillService)
        {
            checkDiffBillService = _checkDiffBillService;
        }

        #region 业务处理
        /// <summary>
        /// 创建盘点单头
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody save([FromBody] CheckDiffBillView vo)
        {
            return checkDiffBillService.Save(vo);
        }

        /// <summary>
        /// 删除盘点单头
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody delete([FromBody] List<long> ids)
        {
            return checkDiffBillService.Delete(ids);
        }

        /// <summary>
        /// 提交盘点单头
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody submit([FromBody] CheckDiffBillView vo)
        {
            return checkDiffBillService.Submit(vo);
        }

        /// <summary>
        /// 审核盘点单头
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody approve([FromBody] CheckDiffBillView vo)
        {
            return checkDiffBillService.Approve(vo);
        }

        /// <summary>
        /// 弃审盘点单头
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBusBody unapprove([FromBody] CheckDiffBillView vo)
        {
            return checkDiffBillService.UnApprove(vo);
        }

        /// <summary>
        /// 批量提交盘点单头
        /// </summary>
        /// <param name="vos"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody batchSubmit([FromBody] List<DoActionView> vos)
        {
            return checkDiffBillService.BatchSubmit(vos);
        }

        /// <summary>
        /// 批量审核盘点单头
        /// </summary>
        /// <param name="vos"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody batchApprove([FromBody] List<DoActionView> vos)
        {
            return checkDiffBillService.BatchApprove(vos);
        }

        /// <summary>
        /// 批量弃审盘点单头
        /// </summary>
        /// <param name="vos"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody batchUnApprove([FromBody] List<DoActionView> vos)
        {
            return checkDiffBillService.BatchUnApprove(vos);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 通过主键查询盘点单头
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseBusBody queryDocById([FromQuery] long id)
        {
            return checkDiffBillService.QueryDocById(id);
        }

        /// <summary>
        /// 通过单据编号查询盘点单头
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseBusBody queryDocByDocNo([FromQuery] string DocNo)
        {
            return checkDiffBillService.QueryDocByDocNo(DocNo);
        }

        /// <summary>
        /// 分页查询盘点单头
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody queryAllByPage([FromBody] PageView view)
        {
            return checkDiffBillService.QueryAllByPage(view);
        }

        /// <summary>
        /// 盘点单头明细
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody queryLineByPage([FromBody] PageView view)
        {
            return checkDiffBillService.queryLineByPage(view);
        }
        #endregion
    }
}
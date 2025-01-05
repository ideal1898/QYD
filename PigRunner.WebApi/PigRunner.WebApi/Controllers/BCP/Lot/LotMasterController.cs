using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.BCP.Lot;
using PigRunner.Public.Common.Views;
using PigRunner.Services.BCP.Lot.IServices;

namespace PigRunner.WebApi.Controllers.BCP.Lot
{
    /// <summary>
    /// 批号
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LotMasterController : ControllerBase
    {
        private ILotMasterService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public LotMasterController(ILotMasterService _services)
        {
            this.services = _services;
        }
        /// <summary>
        /// 批次主档
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse ActionLotMaster(LotMasterView request)
        {
            return services.ActionLotMaster(request);
        }

        /// <summary>
        /// 上传批次主档
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse UploadLotMaster(IFormFile file)
        {
            PubResponse response = new PubResponse();
            try
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    response = services.UploadLotMaster(stream);
                }
            }
            catch (Exception ex)
            {
                response.code = 400;
                response.msg = ex.Message;
            }
            return response;
        }
    }
}

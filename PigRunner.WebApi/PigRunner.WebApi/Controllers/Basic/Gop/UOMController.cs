using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Basic.Gop;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Basic.Gop.IServices;

namespace PigRunner.WebApi.Controllers.Basic.Gop
{
     /// <summary>
     /// 计量单位
     /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UOMController : ControllerBase
    {
        private IUOMService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public UOMController(IUOMService _services)
        {
            this.services = _services;
        }
        /// <summary>
        /// 计量单位
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse ActionUOM([FromBody] UOMView request)
        {
            return services.ActionUOM(request);
        }

        /// <summary>
        /// 上传计量单位
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse UploadUOM([FromBody] IFormFile file)
        {
            PubResponse response = new PubResponse();
            try
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    response = services.UploadUOM(stream);
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

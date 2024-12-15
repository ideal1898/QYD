using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Basic.Pub;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Basic.Pub.IServices;

namespace PigRunner.WebApi.Controllers.Basic.Pub
{
     /// <summary>
     /// 省/自治区
     /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private IProvinceService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public ProvinceController(IProvinceService _services)
        {
            this.services = _services;
        }
        /// <summary>
        /// 省/自治区
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse ActionProvince(ProvinceView request)
        {
            return services.ActionProvince(request);
        }

        /// <summary>
        /// 上传省/自治区
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse UploadProvince(IFormFile file)
        {
            PubResponse response = new PubResponse();
            try
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    response = services.UploadProvince(stream);
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

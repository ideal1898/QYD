using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Basic.IServices;
using PigRunner.Services.Sys.IServices;

namespace PigRunner.WebApi.Controllers.Basic
{
    /// <summary>
    /// 库区
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WhBinGroupController : ControllerBase
    {
        
        private IWhBinGroupService services;
        
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public WhBinGroupController(IWhBinGroupService _services)
        {
            this.services = _services;
        }

        /// <summary>
        /// 库区
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        
        public PubResponse ActionWhBinGroup(WhBinGroupView request)
        {
            return services.ActionWhBinGroup(request);
        }

        /// <summary>
        /// 上传库区
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse UploadWhBinGroup(IFormFile file)
        {
            PubResponse response = new PubResponse();
            try
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    response = services.UploadWhBinGroup(stream);
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
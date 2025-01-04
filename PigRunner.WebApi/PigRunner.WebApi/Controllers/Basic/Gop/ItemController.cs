using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Basic.IServices;


namespace PigRunner.WebApi.Controllers.Basic
{
    /// <summary>
    /// 料品服务
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public ItemController(IItemService _services)
        {
            this.services = _services;
        }
        /// <summary>
        /// 物料
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse ActionItem(ItemView request)
        {
            return services.ActionItem(request);
        }

        /// <summary>
        /// 上传物料
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse UploadItem(IFormFile file)
        {
            PubResponse response = new PubResponse();
            try
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    response = services.UploadItem(stream);
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

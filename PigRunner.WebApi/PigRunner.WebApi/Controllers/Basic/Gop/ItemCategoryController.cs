using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Basic.Gop;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Basic.Gop.IServices;

namespace PigRunner.WebApi.Controllers.Basic.Gop
{
    /// <summary>
    /// 物料分类
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemCategoryController : ControllerBase
    {
        private IItemCategoryService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public ItemCategoryController(IItemCategoryService _services)
        {
            this.services = _services;
        }
        /// <summary>
        /// 物料分类
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse ActionItemCategory(ItemCategoryView request)
        {
            return services.ActionItemCategory(request);
        }

        /// <summary>
        /// 上传物料分类
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse UploadItemCategory(IFormFile file)
        {
            PubResponse response = new PubResponse();
            try
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    response = services.UploadItemCategory(stream);
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

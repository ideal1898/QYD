using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Basic.Gop;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Basic.Gop.IServices;

namespace PigRunner.WebApi.Controllers.Basic.Gop
{
    /// <summary>
    /// 客户分类
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerCategoryController : ControllerBase
    {
        private ICustomerCategoryService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public CustomerCategoryController(ICustomerCategoryService _services)
        {
            this.services = _services;
        }
        /// <summary>
        /// 客户分类
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse ActionCustomerCategory(CustomerCategoryView request)
        {
            return services.ActionCustomerCategory(request);
        }

        /// <summary>
        /// 上传客户分类
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse UploadCustomerCategory(IFormFile file)
        {
            PubResponse response = new PubResponse();
            try
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    response = services.UploadCustomerCategory(stream);
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

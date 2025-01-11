using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Basic.IServices;

namespace PigRunner.WebApi.Controllers.Basic
{
    /// <summary>
    /// 供应商分类
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierCategoryController : ControllerBase
    {
        private ISupplierCategoryService services;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_services"></param>
        public SupplierCategoryController(ISupplierCategoryService _services)
        {
            this.services = _services;
        }
        /// <summary>
        /// 供应商分类
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse ActionSupplierCategory([FromBody] SupplierCategoryView request)
        {
            return services.ActionSupplierCategory(request);
        }

        /// <summary>
        /// 上传供应商分类
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public PubResponse UploadSupplierCategory([FromBody] IFormFile file)
        {
            PubResponse response = new PubResponse();
            try
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    response = services.UploadSupplierCategory(stream);
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

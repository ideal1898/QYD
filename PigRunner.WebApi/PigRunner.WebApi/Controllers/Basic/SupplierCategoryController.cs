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
    public class SupplierCategoryController: ControllerBase
    {
        private ISupplierCategoryService supplierCategoryService;

        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_supplierCategoryService"></param>
        public SupplierCategoryController(ISupplierCategoryService _supplierCategoryService)
        {
            this.supplierCategoryService = _supplierCategoryService;
        }
        /// <summary>
        /// 新增供应商分类
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody insert([FromBody] SupplierCategoryView view)
        {
            ResponseBody body = new ResponseBody();
            bool success = supplierCategoryService.InsertSupplierCategory(view);
            body.code = success?200:400;
            body.total = 1;
            body.data = new JArray();
            return body;
        }


        /// <summary>
        /// 查询所有供应商分类
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public OkObjectResult querySupplierCategory(int current=1,int size=20 )
        {
            return Ok(supplierCategoryService.GetAllSupplierCategories(current, size));
        }
    }
}

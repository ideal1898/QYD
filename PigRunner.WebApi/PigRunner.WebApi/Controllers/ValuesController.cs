using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PigRunner.WebApi.Controllers
{
    /// <summary>
    /// Values 接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public JsonResult get()
        {
            var json = new
            {
                id = 10,
                name = "测试",
                date = DateTime.Now.ToString("yyyy-MM-dd")
            };
            return new JsonResult(json);
        }
    }
}

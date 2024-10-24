using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigRunner.Entitys.Sys;
using PigRunner.Services.Sys;

namespace PigRunner.WebApi.Controllers
{
    /// <summary>
    /// Values 接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IUserService userService;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_userService"></param>
        public ValuesController(IUserService _userService) { 
           this.userService = _userService;
        }


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult get()
        {
            SysUser user = new SysUser();
            userService.Save(user);

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

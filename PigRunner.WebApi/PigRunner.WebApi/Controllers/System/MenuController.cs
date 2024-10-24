using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PigRunner.Entitys.Sys;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Sys;

namespace PigRunner.WebApi.Controllers.Sys
{
    /// <summary>
    /// 菜单
    /// </summary>
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IMenuService menuService;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_menuService"></param>
        public MenuController(IMenuService _menuService)
        {
            menuService = _menuService;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public bool Save([FromBody] MenuView view)
        {
            return menuService.Save(view);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public PubResponse GetMenu()
        {
            return menuService.GetMenu();
        }
        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseBody list()
        {
            return menuService.list();
        }
    }
}

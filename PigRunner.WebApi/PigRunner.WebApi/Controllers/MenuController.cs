using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigRunner.Entitys.System;
using PigRunner.Services.System;

namespace PigRunner.WebApi.Controllers
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
        public bool Save()
        {
            SysMenu sysMenu = SysMenu.Create();
            sysMenu.Path = "System/User";// 
            sysMenu.Name = "用户管理";// 组建名称
            sysMenu.Component = "System/User";//--组件
            sysMenu.Redirect = "System/User";//定向 
            sysMenu.IsActive = 1;//--生效
            sysMenu.Icon = "Menu";//--图标
            sysMenu.Title = "用户管理";// --标题
            sysMenu.IsLink = "";// 外部连接
            sysMenu.IsHide = 0;//显示
            sysMenu.IsFull = 0;//全屏
            sysMenu.IsAffix = 0;//固钉
            sysMenu.IsKeepAlive = "1";//--缓存
            sysMenu.Parent = 0;
            return menuService.Save(sysMenu);
        }
    }
}

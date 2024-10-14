﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.System;
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
        public bool Save([FromBody] MenuVo vo)
        {
            return menuService.Save(vo);
        }
    }
}

﻿using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PigRunner.Entitys.Sys;
using PigRunner.Public.Common.Views;
using PigRunner.Services.Sys;
using System.Diagnostics;

namespace PigRunner.WebApi.Controllers.Sys
{

    /// <summary>
    /// 菜单
    /// </summary>
    [Route("api/[controller]/[action]")]
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
            return menuService.InsertMenu(view);
        }
        /// <summary>
        /// 上传Json文件
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody UploadJsonFile()
        {
            ResponseBody response = new ResponseBody();
            var FileContent = HttpContext.Request.Form.Files.First();
            string json = string.Empty;
            using (var stream = FileContent.OpenReadStream())
            {
                StreamReader reader = new StreamReader(stream);
                json = reader.ReadToEnd();
            }

            var menuViews = System.Text.Json.JsonSerializer.Deserialize<List<MenuView>>(json);
            if (menuService.InsertMenusByJson(menuViews))
                response.msg = "上传保存完成";
            else
                response.msg = "上传失败";

            response.code = 200;
            response.data = new JArray();
            return response;
        }

        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        //public ResponseBody QueryAllMenus()
        public ResponseBody list()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            ResponseBody response = new ResponseBody();
            List<MenuView> results = new List<MenuView>();
            try
            {
                results = menuService.QueryAllMenus();
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
            }

            stopwatch.Stop();
            response.code = 200;
            response.total = results.Count();
            response.msg = $"查询完成,耗时：{stopwatch.ElapsedMilliseconds} 毫秒";
            response.data = JArray.FromObject(results);
            return response;
        }
        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseBody samelist()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            ResponseBody response = new ResponseBody();
            try
            {
                List<SysMenu> sysMenus = menuService.QueryAllMenusBySameLevel();
               var results= sysMenus.Select(item => new
                {
                    id = item.ID,
                    path = item.Path,
                    name = item.Name,
                    component = item.Component,
                    icon = item.Icon,
                    title = item.Title,
                    isLink = !string.IsNullOrEmpty(item.IsLink) ? true : false,
                    isHide = item.IsHide > 0 ? true : false,
                    isFull = item.IsFull>0?true:false,
                    isAffix = item.IsAffix > 0 ? true : false,
                    isKeepAlive = item.IsKeepAlive > 0 ? true : false,
                    isActive = item.IsActive > 0 ? true : false,
                    parent = item.Parent
                });
                response.total = results.Count();
                response.data = JArray.FromObject(results);
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
            }
            stopwatch.Stop();
            response.code = 200;    
            response.msg = $"查询完成,耗时：{stopwatch.ElapsedMilliseconds} 毫秒";   
            return response;
        }


    }
}

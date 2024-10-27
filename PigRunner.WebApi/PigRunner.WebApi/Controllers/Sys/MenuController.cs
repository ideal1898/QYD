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
                json=reader.ReadToEnd();
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
            List<MenuView> results=new List<MenuView>();
            try {
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


    }
}

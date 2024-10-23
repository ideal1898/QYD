
using PigRunner.DTO.Basic;
using PigRunner.Entitys.System;
using Newtonsoft.Json.Linq;
using PigRunner.Public.Common.Views;

using PigRunner.Repository.System;
using PigRunner.Services.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using PigRunner.Services.Common;

namespace PigRunner.Services.System
{
    public class MenuService : IMenuService
    {
        private MenuRepository menuRepository;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_menuRepository"></param>
        public MenuService(MenuRepository _menuRepository)
        {
            menuRepository = _menuRepository;
        }
        public bool Save(MenuView view)
        {
            SysMenu sysMenu = null;
            if (view.id == 0)
                sysMenu = SysMenu.Create();
            else
                sysMenu = menuRepository.GetById(view.id);

            sysMenu.Path = view.path;// 
            sysMenu.Name = view.name;// 组建名称
            sysMenu.Component = view.component;//--组件
            sysMenu.Redirect = view.redirect;//定向 
            sysMenu.IsActive = view.meta.isActive ? 1 : 0;//--生效
            sysMenu.Icon = view.meta.icon;//--图标
            sysMenu.Title = view.meta.title;// --标题
            //sysMenu.IsLink = view.meta.isLink?1:0;// 外部连接
            sysMenu.IsHide = view.meta.isHide ? 1 : 0;//显示
            sysMenu.IsFull = view.meta.isFull ? 1 : 0;//全屏
            sysMenu.IsAffix = view.meta.isAffix ? 1 : 0;//固钉
            sysMenu.IsKeepAlive = view.meta.isKeepAlive ? 1 : 0;//--缓存
            sysMenu.Parent = view.parent;
            return menuRepository.InsertOrUpdate(sysMenu);
        }




        public PubResponse GetMenu()
        {
            PubResponse rtn = new PubResponse();
            try
            {
                string jsonFilePath = "E:/DevTools/WebServer/menudata.json";
                // jsonFilePath = "D:/Wordfolder/Personal/PlatForm/WebServer/menudata.json";
                var json = File.ReadAllText(jsonFilePath);
                rtn.success = true;
                rtn.code = 200;
                JArray array = JArray.Parse(json);
                rtn.data = array;
            }
            catch (Exception ex)
            {
                rtn.msg = ex.Message;
            }
            return rtn;
        }

        public bool Save(SysMenu sysMenu)
        {
            throw new NotImplementedException();
        }

        public ResponseBody list()
        {
            ResponseBody response = new ResponseBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            var sysMenus = menuRepository.AsQueryable().ToTree(it => it.Children, it => it.Parent, 0);
            List<MenuView> list = MenuTree.Convert(sysMenus);

            var menuPath = "menudata.json";
            var json = File.ReadAllTextAsync(menuPath).Result;

            stopwatch.Stop();
            response.total = 1;
            response.code = 200;
            response.msg = $"查询完成,耗时：{stopwatch.ElapsedMilliseconds} 毫秒";
            //response.data = JArray.Parse(json);
            response.data = JArray.FromObject(list);

            return response;
        }

        private ResponseBody listByFile()
        {
            ResponseBody response = new ResponseBody();
            Stopwatch stopwatch = Stopwatch.StartNew();

            var menuPath = "menudata.json";
            var json = File.ReadAllTextAsync(menuPath).Result;

            stopwatch.Stop();
            response.total = 1;
            response.code = 200;
            response.msg = $"查询完成,耗时：{stopwatch.ElapsedMilliseconds} 毫秒";
            response.data = JArray.Parse(json);
          
            return response;
        }
        private ResponseBody listByDB() { 
            ResponseBody response = new ResponseBody();
            Stopwatch stopwatch = Stopwatch.StartNew();
            var sysMenus = menuRepository.AsQueryable().ToTree(it => it.Children, it => it.Parent, 0);
            List<MenuView> list = MenuTree.Convert(sysMenus);
            response.total = 1;
            response.code = 200;
            response.msg = $"查询完成,耗时：{stopwatch.ElapsedMilliseconds} 毫秒";
            response.data = JArray.FromObject(list);
            return response;
        }

        public ResponseBody GetMenuByEntity()
        {
            ResponseBody response = new ResponseBody();

            var results = menuRepository.AsQueryable();



            return response;
        }

    }
}

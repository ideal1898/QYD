
using PigRunner.DTO.Basic;
using PigRunner.Entitys.Sys;
using Newtonsoft.Json.Linq;
using PigRunner.Public.Common.Views;

using PigRunner.Repository.Sys;
using PigRunner.Services.Sys;
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
using Newtonsoft.Json;
using System.Collections;

namespace PigRunner.Services.Sys
{
    public class MenuService : IMenuService
    {
        private MenuRepository menuRepository;
        private WebSession session;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_menuRepository"></param>
        public MenuService(MenuRepository _menuRepository, WebSession _session)
        {
            menuRepository = _menuRepository;
            this.session = _session;
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public bool DeleteMenu(MenuView view)
        {
            return menuRepository.Context.Deleteable<SysMenu>(view.id).ExecuteCommand() > 0;
        }
        /// <summary>
        /// 批量删除菜单
        /// </summary>
        /// <param name="views"></param>
        /// <returns></returns> 
        public bool DeleteMenus(List<MenuView> views)
        {
            var list = new List<dynamic>() { views.Select(s => s.id) };
            return menuRepository.DeleteByIds(list.ToArray());
        }

        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public bool InsertMenu(MenuView view)
        {
            return menuRepository.InsertOrUpdate(MenuTree.GetSysMenuByView(view, session));
        }
        /// <summary>
        /// 批量新增菜单
        /// </summary>
        /// <param name="views"></param>
        /// <returns></returns>
        public bool InsertMenus(List<MenuView> views)
        {
            List<SysMenu> list = new List<SysMenu>();
            foreach (var view in views)
            {
                list.Add(MenuTree.GetSysMenuByView(view, session));
            }
            return menuRepository.Context.Insertable<SysMenu>(list).ExecuteCommand() > 0;

        }

        public bool InsertMenusByJson(List<MenuView>? menuViews)
        {
            List<SysMenu> sysMenus = MenuTree.ConverEntity(menuViews, session);
            return menuRepository.Context.Insertable<SysMenu>(sysMenus).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 查询所有菜单
        /// </summary>
        /// <returns></returns>
        public List<MenuView> QueryAllMenus()
        {
            var sysMenus = menuRepository.AsQueryable().ToTree(it => it.Children, it => it.Parent, 0);
            return MenuTree.Convert(sysMenus);
        }

        public  List<SysMenu> QueryAllMenusBySameLevel() {
           return menuRepository.AsQueryable().ToList();
        }
        

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="PageSize">每页大小</param>
        /// <param name="Current">当前页</param>
        /// <param name="Total">总数</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<MenuView> QueryMenusByPage(int PageSize, int Current, ref int Total)
        {
            var sysMenus = menuRepository.Context.Queryable<SysMenu>().ToPageList(PageSize, Current, ref Total);
            List<MenuView> views = new List<MenuView>();
            foreach (var sysMenu in sysMenus)
            {
                views.Add(MenuTree.GetMenuView(sysMenu));
            }

            return views;
        }
        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdateMenu(MenuView view)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 批量更新菜单
        /// </summary>
        /// <param name="views"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdateMenus(List<MenuView> views)
        {
            throw new NotImplementedException();
        }


        private ResponseBody BatchInsertByJson()
        {
            ResponseBody response = new ResponseBody();
            Stopwatch startwatch = Stopwatch.StartNew();
            var menuPath = "menudata.json";
            var json = File.ReadAllTextAsync(menuPath).Result;
            var menuViews = System.Text.Json.JsonSerializer.Deserialize<List<MenuView>>(json);

            List<SysMenu> sysMenus = MenuTree.ConverEntity(menuViews, session);
            //插入数据
            menuRepository.Context.Insertable(sysMenus).ExecuteCommand();

            startwatch.Stop();

            response.total = sysMenus.Count;
            response.code = 200;
            response.msg = $"查询完成,耗时：{startwatch.ElapsedMilliseconds} 毫秒";
            response.data = JArray.FromObject(sysMenus);

            return response;
        }
    }
}

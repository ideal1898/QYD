
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Services.Common
 * 唯一标识：8c147d5a-b1a0-4d82-9fd3-26d3990c813e
 * 文件名：MenuTree
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/10/24 0:44:24
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>


using Newtonsoft.Json.Linq;
using PigRunner.Entitys.System;
using PigRunner.Public.Common.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Common
{
    public class MenuTree
    {
        #region 不分层级转化成树
        public static List<MenuView> GetMenuViews(List<SysMenu> sysMenus)
        {
            var menuViews = new List<MenuView>();
            //第一层菜单
            var Parents = sysMenus.Where(w => w.Parent == 0);
            foreach (var item in Parents)
            {
                var menuView = GetMenuView(item);
                //当前层级菜单子菜单
                var Children = sysMenus.Where((w) => w.Parent == item.ID);
                if (!Children.Any())
                    menuView.children = new List<MenuView>();
                else
                    menuView.children = GetChildren(Children.ToList(), sysMenus);
                menuViews.Add(menuView);
            }
            return menuViews;
        }

        private static List<MenuView> GetChildren(List<SysMenu> Menus, List<SysMenu> sysMenus)
        {
            var children = new List<MenuView>();
            foreach (var item in Menus)
            {
                var menuView = GetMenuView(item);
                //当前层级菜单子菜单
                var Children = sysMenus.Where((w) => w.Parent == item.ID);
                if (!Children.Any())
                    menuView.children = new List<MenuView>();
                else
                    menuView.children = GetChildren(Children.ToList(), sysMenus);

                children.Add(menuView);
            }
            return children;
        }

        
        #endregion

        #region 通过SqlSugar转化成树再转化成返回视图
        public static List<MenuView> Convert(List<SysMenu> sysMenus)
        {
            List<MenuView> list = new List<MenuView>();
            foreach (var item in sysMenus)
            {
               var menuView = GetMenuView(item);
                if (item.Children.Count > 0)
                    menuView.children = GetChildMenu(item.Children);
                else
                    menuView.children = new List<MenuView>();
                list.Add(menuView);
            }
            return list;
        }

        private static List<MenuView> GetChildMenu(List<SysMenu> sysMenus) {
            List<MenuView> list = new List<MenuView>();
            foreach (var item in sysMenus)
            {
                var menuView = GetMenuView(item);
                if (item.Children.Count > 0)
                    menuView.children = GetChildMenu(item.Children);
                else
                    menuView.children = new List<MenuView>();
                list.Add(menuView);
            }
            return list;
        }

        #endregion

        private static MenuView GetMenuView(SysMenu item)
        {
            var menuView = new MenuView();
            menuView.parent = item.Parent;
            menuView.path = item.Path;
            menuView.redirect = item.Redirect;
            menuView.component = item.Component;
            menuView.id = item.ID;
            menuView.name = item.Name;
            menuView.meta = new MenuMetaView();
            menuView.meta.isFull = item.IsFull == 1 ? true : false;
            menuView.meta.title = item.Title;
            //menuView.meta.isLink = item.IsLink == 1 ? true : false;
            menuView.meta.icon = item.Icon;
            menuView.meta.isActive = item.IsActive == 1 ? true : false;
            menuView.meta.isAffix = item.IsAffix == 1 ? true : false;
            menuView.meta.isHide = item.IsHide == 1 ? true : false;
            menuView.meta.isKeepAlive = item.IsKeepAlive == 1 ? true : false;
            return menuView;
        }
    }
}

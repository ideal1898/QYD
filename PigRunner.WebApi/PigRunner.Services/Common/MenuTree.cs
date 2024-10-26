
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
using PigRunner.Entitys.Sys;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Helpers;
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

        private static List<MenuView> GetChildMenu(List<SysMenu> sysMenus)
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

        #endregion

        public static MenuView GetMenuView(SysMenu item)
        {
            var menuView = new MenuView();
            menuView.parent = item.ID;
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

        #region 转化View为Entity
        public static List<SysMenu> ConverEntity(List<MenuView> menuViews, WebSession session)
        {
            List<SysMenu> list = new List<SysMenu>();
            foreach (var view in menuViews)
            {
                var sysMenu = GetSysMenu(view, 0, session);
                list.Add(sysMenu);
                if (view.children.Any())
                    GetChildEntitys(view.children, sysMenu.ID, list, session);
            }
            return list;
        }

        private static void GetChildEntitys(List<MenuView> menuViews, long Parent, List<SysMenu> list, WebSession session)
        {
            foreach (var view in menuViews)
            {
                var sysMenu = GetSysMenu(view, Parent, session);
                list.Add(sysMenu);
                if (view.children.Any())
                    GetChildEntitys(view.children, sysMenu.ID, list, session);
            }
        }

        private static SysMenu GetSysMenu(MenuView view, long parent, WebSession session)
        {
            var sysMenu = new SysMenu();
            sysMenu.ID = IdGeneratorHelper.GetNextId();
            sysMenu.CreatedTime = DateTime.Now;
            sysMenu.CreatedBy = session.UserName;
            sysMenu.Path = view.path;// 
            sysMenu.Name = view.name;// 组建名称
            sysMenu.Component = view.component;//--组件
            sysMenu.Redirect = view.redirect;//定向 
            sysMenu.IsActive = view.meta.isActive ? 1 : 0;//--生效
            sysMenu.Icon = view.meta.icon;//--图标
            sysMenu.Title = view.meta.title;// --标题                
            sysMenu.IsHide = view.meta.isHide ? 1 : 0;//显示
            sysMenu.IsFull = view.meta.isFull ? 1 : 0;//全屏
            sysMenu.IsAffix = view.meta.isAffix ? 1 : 0;//固钉
            sysMenu.IsKeepAlive = view.meta.isKeepAlive ? 1 : 0;//--缓存
            sysMenu.Parent = parent;

            return sysMenu;
        }
        #endregion

        public static SysMenu GetSysMenuByView(MenuView view, WebSession session)
        {
            var sysMenu = new SysMenu();
            sysMenu.ID = IdGeneratorHelper.GetNextId();
            sysMenu.CreatedTime = DateTime.Now;
            sysMenu.CreatedBy = session.UserName;
            sysMenu.Path = view.path;// 
            sysMenu.Name = view.name;// 组建名称
            sysMenu.Component = view.component;//--组件
            sysMenu.Redirect = view.redirect;//定向 
            sysMenu.IsActive = view.meta.isActive ? 1 : 0;//--生效
            sysMenu.Icon = view.meta.icon;//--图标
            sysMenu.Title = view.meta.title;// --标题                
            sysMenu.IsHide = view.meta.isHide ? 1 : 0;//显示
            sysMenu.IsFull = view.meta.isFull ? 1 : 0;//全屏
            sysMenu.IsAffix = view.meta.isAffix ? 1 : 0;//固钉
            sysMenu.IsKeepAlive = view.meta.isKeepAlive ? 1 : 0;//--缓存
            sysMenu.Parent = view.parent;

            return sysMenu;

        }


    }
}

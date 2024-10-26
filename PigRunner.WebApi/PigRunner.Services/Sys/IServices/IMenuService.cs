
﻿using PigRunner.DTO.Basic;
using PigRunner.Entitys.Sys;
using PigRunner.Public.Common.Views;

using PigRunner.Public.Interface;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Sys
{
    public interface IMenuService : IScopedService
    {
        //命名规范：插入：InsertXX  修改：UpdateXX 查询：QueryXX
        #region 新增，修改，删除单个实体
        bool InsertMenu(MenuView view);
        bool UpdateMenu(MenuView view);
        bool DeleteMenu(MenuView view);
        #endregion

        #region 批量新增，修改，删除实体
        bool InsertMenus(List<MenuView> views);
        bool UpdateMenus(List<MenuView> views);
        bool DeleteMenus(List<MenuView> views);
        bool InsertMenusByJson(List<MenuView>? views);
        #endregion

        #region 查询菜单
        List<MenuView> QueryAllMenus();
        List<MenuView> QueryMenusByPage(int PageSize,int Current, ref int Total);//同步分页查询
       
        #endregion

    }
}

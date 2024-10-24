
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

       bool Save(MenuView view);

        bool Save(SysMenu sysMenu);

        ResponseBody list();
        PubResponse GetMenu();
    }
}

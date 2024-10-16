
﻿using PigRunner.DTO.Basic;
using PigRunner.DTO.System;
using PigRunner.Entitys.System;
using PigRunner.Public.Common.Views;

using PigRunner.Public.Interface;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.System
{
    public interface IMenuService : IScopedService
    {

       bool Save(MenuVo vo);

        bool Save(SysMenu sysMenu);

        ResponseBody list();
        PubResponse GetMenu();
    }
}

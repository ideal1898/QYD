<<<<<<< HEAD
﻿using PigRunner.DTO.Basic;
using PigRunner.DTO.System;
using PigRunner.Entitys.System;
=======
﻿using PigRunner.Entitys.System;
using PigRunner.Public.Common.Views;
>>>>>>> a149554f9ed18021995679a41f34d6e12be7a8fa
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
<<<<<<< HEAD
       bool Save(MenuVo vo);
=======
        bool Save(SysMenu sysMenu);

        PubResponse GetMenu();

>>>>>>> a149554f9ed18021995679a41f34d6e12be7a8fa
    }
}

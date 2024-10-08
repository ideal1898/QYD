using PigRunner.Entitys.System;
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
       bool Save(SysMenu sysMenu);
    }
}

using PigRunner.Entitys.System;
using PigRunner.Public.Interface;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Repository.System
{
    /// <summary>
    /// 菜单存储库
    /// </summary>
    public class MenuRepository : BaseRepository<SysMenu>, IScopedService
    {
        public bool Save(SysMenu sysMenu) {           
            return Insert(sysMenu);
        }
    }
}

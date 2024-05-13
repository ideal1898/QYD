using PigRunner.Entitys.System;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Repository.System
{
    /// <summary>
    /// 用户存储库
    /// </summary>
    public class UserRepository:BaseRepository<SysUser>, IScopedService
    {
        public string Save(SysUser sysUser) {

            return "保存成功";
        }
    }
}

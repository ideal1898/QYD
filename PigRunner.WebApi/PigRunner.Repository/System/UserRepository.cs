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

        public SysUser GetSysUser(string username,string pwd) {
            return GetFirst(user => user.UserName == username && user.Password == pwd&&user.IsActive == 1);      
        }

        public string Save(SysUser sysUser) {

            return "保存成功";
        }
    }
}

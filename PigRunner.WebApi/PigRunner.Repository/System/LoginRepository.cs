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
    /// 登录存储库
    /// </summary>
    public class LoginRepository:BaseRepository<SysLogin>, IScopedService
    {
    }
}

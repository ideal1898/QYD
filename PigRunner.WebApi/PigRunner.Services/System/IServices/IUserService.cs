using PigRunner.Entitys.System;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.System
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface IUserService: IScopedService
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pwd">MD5加过密的密码</param>
        /// <returns></returns>
        SysUser GetSysUser(string username,string pwd);
        void Save(SysUser sysUser);
    }
}

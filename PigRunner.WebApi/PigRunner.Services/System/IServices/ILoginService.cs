
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Services.System
 * 唯一标识：10435c1e-bad3-44db-9c10-740d8483f640
 * 文件名：ILoginServices
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/5/14 9:10:29
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>



using PigRunner.Entitys.System;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.System
{
    public interface ILoginService: IScopedService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        LoginResponse Login(string username, string password);
        /// <summary>
        /// 查询登录信息
        /// </summary>
        /// <param name="id">登录信息表ID</param>
        /// <returns></returns>
        SysLogin GetSysLogingByUser(long id);
        /// <summary>
        /// 更新登录信息
        /// </summary>
        /// <param name="sysLogin"></param>
        /// <returns></returns>
        bool UpdateSysLogin(SysLogin sysLogin);
        /// <summary>
        /// 登出系统
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        bool LoginOut(string username);
        /// <summary>
        /// 更新令牌过期时间
        /// </summary>
        /// <returns></returns>
        bool UpdateExpireTime(long id, DateTime ExpireTime);
    }
}

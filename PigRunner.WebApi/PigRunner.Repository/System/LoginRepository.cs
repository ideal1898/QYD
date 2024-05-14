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
        /// <summary>
        /// 根据ID获取登录信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysLogin GetSysLogingById(long id) {

            return GetFirst(sysLogin=>sysLogin.id==id);
        }
        /// <summary>
        /// 更新登录信息
        /// </summary>
        /// <param name="sysLogin"></param>
        /// <returns></returns>
        public bool UpdateSysLogin(SysLogin sysLogin)
        {
            return AsUpdateable(sysLogin).UpdateColumns(p => new { p.Token, p.Expiretime
            }).Where(p => p.id == sysLogin.id).ExecuteCommand() > 0;
        }
        /// <summary>
        /// 按用户名注销
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public bool LoginOut(string username) {
            return AsUpdateable().SetColumns(p => p.Token == "").Where(w => w.Username == username).ExecuteCommand()>0;
        }
        /// <summary>
        /// 更新令牌过期时间
        /// </summary>
        /// <returns></returns>
        public bool UpdateExpireTime(long id,DateTime ExpireTime) {
            return AsUpdateable().SetColumns(p => p.Expiretime == ExpireTime).Where(p => p.id == id).ExecuteCommand()>0;
        }
    }
}


#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Services.System.Services
 * 唯一标识：9c315c42-d8d2-4788-82e8-35d3b6a90dc4
 * 文件名：LoginService
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/5/14 9:32:02
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
using PigRunner.Public.Helpers;
using PigRunner.Repository.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.System.Services
{
    /// <summary>
    /// 登录服务
    /// </summary>
    public class LoginService : ILoginServices
    {
        private LoginRepository loginRepository;
        private UserRepository userRepository;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_loginRepository">登录仓库</param>
        /// <param name="_userRepository">用户仓库</param>
        public LoginService(LoginRepository _loginRepository, UserRepository _userRepository)
        {
            this.loginRepository = _loginRepository;
            this.userRepository = _userRepository;
        }

        /// <summary>
        /// 登录服务
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public LoginResponse Login(string username, string password)
        {
            var loginResponse = new LoginResponse();
            if (string.IsNullOrEmpty(username))
                return LoginResponse.Error("用户名不能为空");
            if (string.IsNullOrEmpty(password))
                return LoginResponse.Error("密码不能为空");

            var pwd = CommonHelper.GetMD5Password(username, password);
            var userInfo = userRepository.GetSysUser(username, pwd);
            if (userInfo == null)
            {
                return LoginResponse.Error("用户名或密码不正确");
            }


            return loginResponse;
        }

     
    }
}

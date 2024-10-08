
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


using Dm.filter.log;
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
    public class LoginService : ILoginService
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
            var sysUser = userRepository.GetSysUser(username, pwd);
            if (sysUser == null)
                return LoginResponse.Error("用户名或密码不正确"+pwd);

            //创建Token
            var loginUser = new LoginUserVo()
            {
                Id = sysUser.ID,
                UserName = sysUser.UserName,
                IsAdmin = sysUser.IsAdmin.ToString(),
                Nickname = sysUser.NickName
            };
            var sysLogin = loginRepository.GetSysLogingByUser(sysUser.ID);
            var token = IsValidToken(sysLogin) ? sysLogin.Token : JWTHelper.CreateJWTToken(loginUser);

            if (string.IsNullOrEmpty(token))
                return LoginResponse.Error("登陆失败");
            

            if (!SaveOrUpdateSysLogin(sysLogin, token, sysUser))
                return LoginResponse.Error("登陆失败");

            loginResponse.LoginUser = loginUser;
            loginResponse.Success = true;
            loginResponse.Token = token;
            loginResponse.Message = "登录成功";
            return loginResponse;
        }
        /// <summary>
        /// 校验token有效性
        /// </summary>
        /// <param name="sysLogin"></param>
        /// <returns></returns>
        private bool IsValidToken(SysLogin sysLogin)
        {
            //判断Token是否过期
            if (sysLogin == null || string.IsNullOrEmpty(sysLogin.Token) || sysLogin.Expiretime < DateTime.Now || JWTHelper.IsExpired(sysLogin.Token))
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// 新增或者更新登录信息
        /// </summary>
        /// <returns></returns>
        private bool SaveOrUpdateSysLogin(SysLogin sysLogin, string token, SysUser sysUser)
        {
            if (sysLogin == null)
            {
                sysLogin = SysLogin.Create();
                sysLogin.CreatedBy = sysUser.NickName;
                sysLogin.Account = sysUser.ID;
                sysLogin.CreatedTime = DateTime.Now;
                sysLogin.Username = sysUser.UserName;
                sysLogin.NickName = sysUser.NickName;
                sysLogin.SysVersion = 0;
                sysLogin.Expiretime = DateTime.Now.AddMinutes(45); //新增，则token有效期为45分钟
                sysLogin.Token = token;
                sysLogin.IsActive = sysUser.IsActive;
                sysLogin.IsAdmin = sysUser.IsAdmin;

                return loginRepository.Insert(sysLogin);
            }
            else
            {
                sysLogin.Expiretime = DateTime.Now.AddMinutes(45);
                sysLogin.Token = token;
                sysLogin.Account = sysUser.ID;
                return loginRepository.Update(sysLogin);
            }
        }



        /// <summary>
        /// 根据ID获取登录信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysLogin GetSysLogingByUser(long id)
        {
            return loginRepository.GetSysLogingByUser(id);
        }
        /// <summary>
        /// 登出系统
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool LoginOut(string username)
        {
            return loginRepository.LoginOut(username);
        }

        public bool UpdateExpireTime(long id, DateTime ExpireTime)
        {
            return loginRepository.UpdateExpireTime(id, ExpireTime);
        }

        public bool UpdateSysLogin(SysLogin sysLogin)
        {
            return loginRepository.UpdateSysLogin(sysLogin);
        }
    }
}

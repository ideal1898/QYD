using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using PigRunner.Public.Helpers;
using PigRunner.Repository.Sys;
using PigRunner.Public.Common.Views;
using DocumentFormat.OpenXml.Spreadsheet;

namespace PigRunner.WebApi.Commons.Attributes
{
    /// <summary>
    /// 权限管理
    /// </summary>
    public class AuthorizationFilter : IAuthorizationFilter
    {
        #region 构造函数

        private LoginRepository loginRepository;
        private readonly WebSession _session;

        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_loginRepository"></param>
        /// <param name="session"></param>
        public AuthorizationFilter(LoginRepository _loginRepository,WebSession session)
        {
          this.loginRepository = _loginRepository;
            this._session = session;
        }

        #endregion


        /// <summary>
        /// 权限认证
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //忽略权限验证
            if (HasAllowAnonymous(context))
            {
                return;
            }

           

            var token = context.HttpContext.Request.Headers["authorization"];
            var accountData = JWTHelper.JWTDecode(token);
            if (accountData == null)
            {
                context.Result = new ContentResult() { StatusCode = StatusCodes.Status401Unauthorized, Content = "账号无效或已过期" };
                return;
            }

            //判断是否过期
            var sysLogin = loginRepository.GetSysLogingByUser(accountData.Id);
            if (sysLogin == null || string.IsNullOrEmpty(sysLogin.Token) || sysLogin.Expiretime < DateTime.Now || sysLogin.Token != token.ToString().Split(" ")[1])
            {
                context.Result = new ContentResult() { StatusCode = StatusCodes.Status401Unauthorized, Content = "账号无效或已过期" };
                return;
            }

            //过期前15分钟内操作，延迟45分钟过期
            if ((sysLogin.Expiretime - DateTime.Now).TotalMinutes < 30)
            {
                loginRepository.UpdateExpireTime(sysLogin.ID, DateTime.Now.AddMinutes(45));
            }
      
            _session.UserID = sysLogin.ID;
            _session.UserName =sysLogin.Username;
        }

        private bool HasAllowAnonymous(AuthorizationFilterContext context)
        {
            var endpoint = context.HttpContext.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return true;
            }
            return false;
        }
    }
}

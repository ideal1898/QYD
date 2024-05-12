using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace PigRunner.WebApi.Commons.Attributes
{
    /// <summary>
    /// 权限管理
    /// </summary>
    public class AuthorizationFilter : IAuthorizationFilter
    {
        #region 构造函数

        

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name=""></param>
        public AuthorizationFilter()
        {
          
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

            //var token = context.HttpContext.Request.Headers["authorization"];
            //var accountData = JWTHelper.JWTDecode(token);
            //if (accountData == null)
            //{
            //    context.Result = new ContentResult() { StatusCode = StatusCodes.Status401Unauthorized, Content = "账号无效或已过期" };
            //    return;
            //}

            //判断是否过期
            //var sysLogin = loginRepository.GetLogin(accountData.Account);
            //if (sysLogin == null || string.IsNullOrEmpty(sysLogin.Token) || sysLogin.ExpireTime < DateTime.Now || sysLogin.Token != token.ToString().Split(" ")[1])
            //{
            //    context.Result = new ContentResult() { StatusCode = StatusCodes.Status401Unauthorized, Content = "账号无效或已过期" };
            //    return;
            //}

            ////过期前15分钟内操作，延迟45分钟过期
            //if ((sysLogin.ExpireTime - DateTime.Now).TotalMinutes < 30)
            //{
            //    loginRepository.UpdateExpireTime(sysLogin.Id, DateTime.Now.AddMinutes(45));
            //}
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

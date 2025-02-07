using Microsoft.AspNetCore.Http;
using PigRunner.Public.Common.Views;
using SqlSugar.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public.Context
{
    /// <summary>
    /// 上下文:实现
    /// </summary>
    public class LoginAppContext : ILoginAppContext
    {
        private readonly HttpContext httpContext;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public LoginAppContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContext = httpContextAccessor.HttpContext;
        }
        /// <summary>
        /// 登录上下文信息:用户+组织
        /// </summary>
        public LoginUserVo LoginToken
        {
            get
            {
                var data = new LoginUserVo();
                var UserId = httpContext.User.Claims.FirstOrDefault(s => s.Type == "UserId")?.Value.ObjToString() ?? "-1";
                data.Id = Convert.ToInt64(UserId);
                data.UserId = Convert.ToInt64(UserId);
                data.UserName = httpContext.User.Claims.FirstOrDefault(s => s.Type == "UserName")?.Value.ObjToString() ?? "";
                data.DisplayName = httpContext.User.Claims.FirstOrDefault(s => s.Type == "DisplayName")?.Value.ObjToString() ?? "";
                data.IsAdmin = httpContext.User.Claims.FirstOrDefault(s => s.Type == "IsAdmin")?.Value.ObjToString() ?? "0";
                var OrgStr= httpContext.User.Claims.FirstOrDefault(s => s.Type == "Org")?.Value.ObjToString() ?? "-1";
                data.Org = Convert.ToInt64(OrgStr);
                data.OrgCode = httpContext.User.Claims.FirstOrDefault(s => s.Type == "OrgCode")?.Value.ObjToString() ?? "";
                data.OrgName = httpContext.User.Claims.FirstOrDefault(s => s.Type == "OrgName")?.Value.ObjToString() ?? "";
                return data;
            }
        }
        /// <summary>
        /// 当前Token
        /// </summary>
        public string CurrentToken
        {
            get
            {
                if (httpContext.Request.Headers.ContainsKey("authorization"))
                    return httpContext.Request.Headers["authorization"].ToString()
                       .Replace("Bearer ", "").Trim();
                return string.Empty;
            }
        }
        /// <summary>
        /// 是否已认证
        /// </summary>
        public bool IsAuthenticated => true;
    }
}

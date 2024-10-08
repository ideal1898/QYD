using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigRunner.Public.Common.Views;
using PigRunner.Services.System;

namespace PigRunner.WebApi.Controllers
{
    /// <summary>
    /// 登录
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService loginServices;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_loginServices"></param>
        public LoginController(ILoginService _loginServices) { 
            this.loginServices = _loginServices;       
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public LoginResponse Login(LoginRequest request)
        {         
            return loginServices.Login(request.UserName,request.Password);
        }
    }
}

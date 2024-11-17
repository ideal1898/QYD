using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigRunner.DTO.Views.Sys;
using PigRunner.Entitys.Sys;
using PigRunner.Public.Common.Views;

namespace PigRunner.WebApi.Controllers.Sys
{
    /// <summary>
    /// 用户
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;

        /// <summary>
        /// 
        /// </summary>
        public UserController(IMapper _mapper) { 
        this.mapper = _mapper;
        }
        [AllowAnonymous]
        [HttpPost]
        public ResponseBody QueryUsers([FromBody] UserView view) { 
            ResponseBody response = new ResponseBody();
            var sysUser= mapper.Map<SysUser>(view);
        
            return response;
        }
    }
}

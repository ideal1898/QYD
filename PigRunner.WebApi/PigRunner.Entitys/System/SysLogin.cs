using PigRunner.Public.Abstract;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Entitys.System
{
    /// <summary>
    /// 登录实体
    /// </summary>
    [SugarTable("Base_Sys_Login")]
    public class SysLogin:BaseEntity<SysLogin>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string? Username { get; set; }
        /// <summary>
        /// 令牌
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// 令牌失效时间
        /// </summary>
        public DateTime Expiretime { get; set; }

    }
}

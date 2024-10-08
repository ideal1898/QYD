using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Entitys.System
{
    [SqlSugar.SugarTable("Base_Sys_User")]
    public class SysUser:BaseEntity<SysUser>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = string.Empty;
        /// <summary>
        /// 简称
        /// </summary>
        public string NickName { get; set; } = string.Empty;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = string.Empty;
       /// <summary>
       /// 是否启用
       /// </summary>
        public int IsActive { get; set; }
        /// <summary>
        /// 管理员
        /// </summary>
        public int IsAdmin { get; set; }
        /// <summary>
        /// 邮件
        /// </summary>
        public string? Email { get; set; } = string.Empty;
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set;} = string.Empty;
        /// <summary>
        /// 主页
        /// </summary>
        public string MainUrl { get; set; } = string.Empty;
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; } = string.Empty;

    }
}

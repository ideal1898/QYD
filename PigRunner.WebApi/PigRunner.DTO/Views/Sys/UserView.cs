
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.DTO.Views.Sys
 * 唯一标识：ca3fbd07-85cb-4132-8e69-2a4d207dfd9c
 * 文件名：UserView
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/10/26 16:06:43
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.Views.Sys
{
    public class UserView:BaseView
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
        public string Phone { get; set; } = string.Empty;
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

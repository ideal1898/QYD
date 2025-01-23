using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public.Common.Views
{
    /// <summary>
    /// 登录信息
    /// </summary>
    public class LoginUesrVo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID{get;set;}
        /// <summary>
        /// 用户名:登录账号
        /// </summary>
        public string UserName { get; set; }=string.Empty;
        /// <summary>
        /// 用户显示名称
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;
        /// <summary>
        /// 管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 组织ID
        /// </summary>
        public long Org { get; set; }
        /// <summary>
        /// 组织编码
        /// </summary>
        public string OrgCode { get; set; } = string.Empty;
        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrgName { get; set; } = string.Empty;
        /// <summary>
        /// 登录时间
        /// </summary>
        public string LoginTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        /// <summary>
        /// token失效时间
        /// </summary>
        public DateTime? ExpireTime { get; set; }
    }
}

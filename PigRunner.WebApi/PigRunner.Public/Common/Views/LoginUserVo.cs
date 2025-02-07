
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Public.Common.Views
 * 唯一标识：0af7019f-f252-473a-bade-4d7aa91e34c6
 * 文件名：LoginUserVo
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/5/14 9:19:15
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

namespace PigRunner.Public.Common.Views
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class LoginUserVo
    {
        /// <summary>
        /// 标识
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set;}=string.Empty;
        /// <summary>
        /// 管理员
        /// </summary>
        public string IsAdmin { get; set; }=string.Empty;
        /// <summary>
        /// 角色
        /// </summary>
        public string DisplayName { get; set; }=string.Empty; 
        /// <summary>
        /// 组织ID
        /// </summary>
        public long Org { get; set; }
        /// <summary>
        /// 组织编码
        /// </summary>
        public string OrgCode { get; set; }=string.Empty ;
        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrgName { get; set; } = string.Empty;
    }
}

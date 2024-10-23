
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Public.Common.Views
 * 唯一标识：f418a193-57e7-4911-bc6c-061823e7e52e
 * 文件名：MenuMetaView
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/10/24 0:40:45
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
    public class MenuMetaView
    {
        /// <summary>
        /// 图标
        /// </summary>
        public string? icon { get; set; } = string.Empty;
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string? title { get; set; } = string.Empty;
        /// <summary>
        /// 外部链接
        /// </summary>
        public bool isLink { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool isHide { get; set; }
        /// <summary>
        /// 是否全屏
        /// </summary>
        public bool isFull { get; set; }
        /// <summary>
        /// 固钉
        /// </summary>
        public bool isAffix { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool isActive { get; set; }
        /// <summary>
        /// 是否缓存
        /// </summary>
        public bool isKeepAlive { get; set; }
    }
}

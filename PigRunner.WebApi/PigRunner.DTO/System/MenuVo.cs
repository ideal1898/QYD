
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.DTO.System
 * 唯一标识：4cdb5423-2484-4716-a5ba-13995d9b2c65
 * 文件名：MenuVo
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/10/13 17:57:33
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

namespace PigRunner.DTO.System
{
    public class MenuVo
    {
        public long parent { get; set; } = 0;
        public long id { get; set; } = 0;
        /// <summary>
        /// 路径
        /// </summary>
        public string path { get; set; } = string.Empty;
        /// <summary>
        /// 组件名称
        /// </summary>
        public string name { get; set; } = string.Empty;
        /// <summary>
        /// 组件
        /// </summary>
        public string component { get; set; } = string.Empty;
        /// <summary>
        /// 重定向
        /// </summary>
        public string redirect { get; set; }=string.Empty;
        /// <summary>
        /// 图标
        /// </summary>
        public string icon { get; set; } = string.Empty;
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string title { get; set; } = string.Empty;
        /// <summary>
        /// 外部链接
        /// </summary>
        public string isLink { get; set; }=string.Empty;
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


#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Public.Common.Views
 * 唯一标识：957fcde0-452f-4efc-a53a-c965253a2027
 * 文件名：MenuView
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/10/24 0:40:27
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
    public class MenuView
    {
        public long parent { get; set; }
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
        public string? redirect { get; set; } = string.Empty;
        /// <summary>
        /// 元数据
        /// </summary>
        public MenuMetaView meta { get; set; } = new MenuMetaView();
        /// <summary>
        /// 菜单
        /// </summary>
        public List<MenuView> children { get; set; } = new List<MenuView>();
    }
}

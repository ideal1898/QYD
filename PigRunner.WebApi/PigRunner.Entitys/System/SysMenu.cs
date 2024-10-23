using Newtonsoft.Json;
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
    /// 菜单
    /// </summary>
    [SugarTable("QYD_Sys_Menu")]
    public class SysMenu : BaseEntity<SysMenu>
    {
        /// <summary>
        /// 用户组建
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }=string.Empty;// 
        /// <summary>
        /// 组建名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;// 组建名称
        /// <summary>
        /// 组件
        /// </summary>
        [JsonProperty("component")] 
        public string Component { get; set; } = string.Empty;//--组件
        /// <summary>
        /// 定向
        /// </summary>
        [JsonProperty("redirect")] 
        public string? Redirect { get; set; } = string.Empty;//定向 
        /// <summary>
        /// 生效
        /// </summary>
        [JsonProperty("isActive")]
        public int IsActive { get; set; }//--生效
        /// <summary>
        /// 图标
        /// </summary>
        public string? Icon { get; set; } = string.Empty;//--图标
        /// <summary>
        /// 标题
        /// </summary>
        public string? Title { get; set; } = string.Empty;// --标题
        /// <summary>
        /// 外部连接
        /// </summary>
        public string? IsLink { get; set; }// 外部连接
        /// <summary>
        /// 显示
        /// </summary>
        public int IsHide { get; set; }//显示
        /// <summary>
        /// 全屏
        /// </summary>
        public int IsFull { get; set; }//全屏
        /// <summary>
        /// 固钉
        /// </summary>
        public int IsAffix { get; set; }//固钉
        /// <summary>
        /// 缓存
        /// </summary>
        public int IsKeepAlive { get; set; }//--缓存
        /// <summary>
        /// 父类关联ID
        /// </summary>
        public long Parent { get; set; }
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public List<SysMenu> Children { get; set; }=new List<SysMenu>();
    }
}

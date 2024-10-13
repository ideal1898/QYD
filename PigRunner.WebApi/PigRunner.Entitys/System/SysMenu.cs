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
        public string? Path { get; set; }=string.Empty;// 
        /// <summary>
        /// 组建名称
        /// </summary>
        public string Name { get; set; } = string.Empty;// 组建名称
        /// <summary>
        /// 组件
        /// </summary>
        public string Component { get; set; } = string.Empty;//--组件
        /// <summary>
        /// 定向
        /// </summary>
        public string? Redirect { get; set; } = string.Empty;//定向 
        /// <summary>
        /// 生效
        /// </summary>
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
        public string? IsLink { get; set; } = string.Empty;// 外部连接
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
        public string? IsKeepAlive { get; set; } = string.Empty;//--缓存
        /// <summary>
        /// 父类关联ID
        /// </summary>
        public long? Parent { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public List<SysMenu> Children { get; set; }=new List<SysMenu>();

        /// <summary>
        /// 关联：一对一
        /// </summary>
        //标准配置 推荐
        [Navigate(NavigateType.OneToOne, nameof(SysMenu.Parent))]//一对一 Parent是SysMenu类里面的
        public SysMenu? menu { get; set; }
    }
}

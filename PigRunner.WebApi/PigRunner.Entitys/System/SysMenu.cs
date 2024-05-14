using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Entitys.System
{
    public class SysMenu : BaseEntity<SysMenu>
    {
        /// <summary>
        /// 用户组建
        /// </summary>
        public string? Path;// 
        /// <summary>
        /// 组建名称
        /// </summary>
        public string ?Name;// 组建名称
        /// <summary>
        /// 组件
        /// </summary>
        public string? Component;//--组件
        /// <summary>
        /// 定向
        /// </summary>
        public string? Redirect;//定向 
        /// <summary>
        /// 生效
        /// </summary>
        public int IsActive;//--生效
        /// <summary>
        /// 图标
        /// </summary>
        public string? Icon;//--图标
        /// <summary>
        /// 标题
        /// </summary>
        public string? Title;// --标题
        /// <summary>
        /// 外部连接
        /// </summary>
        public string? IsLink;// 外部连接
        /// <summary>
        /// 显示
        /// </summary>
        public int IsHide;//显示
        //全屏
        public int IsFull;//全屏
        public int IsAffix;//,--
        /// <summary>
        /// 缓存
        /// </summary>
        public string? IsKeepAlive;//--缓存
    }
}

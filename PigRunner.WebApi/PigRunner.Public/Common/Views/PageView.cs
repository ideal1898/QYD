using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public.Common.Views
{
    /// <summary>
    /// 分页
    /// </summary>
    public class PageView
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageNumber { get; set; } = 1;
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; } = 20;
        /// <summary>
        /// 过滤条件
        /// </summary>
        public List<dynamic> Where { get; set; }=new List<dynamic>();
    }
}

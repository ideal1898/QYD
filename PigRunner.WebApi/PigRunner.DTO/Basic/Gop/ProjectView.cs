using PigRunner.DTO.Basic.Pub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.Basic.Gop
{
    /// <summary>
    /// 项目视图
    /// </summary>
    public class ProjectView : PubView
    {

        /// <summary>
        /// 状态：1-四舍五入，2-舍位，3-入位
        /// 默认值:
        ///</summary>
        public int Status { get; set; } = 0;

        /// <summary>
        /// 状态名称
        /// </summary>
        public string StatusName { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        public string Description { get; set; } = string.Empty;


        /// <summary>
        /// 验收日期
        /// </summary>
        public string AcceptDate { get; set; } = string.Empty;

        /// <summary>
        /// 质保到期日
        /// </summary>
        public string QAExpireDate { get; set; } = string.Empty;
    }
}

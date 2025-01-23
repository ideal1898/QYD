using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO
{

    /// <summary>
    /// 单据基类视图
    /// </summary>
    public class OrderBaseView
    {
        /// <summary>
        /// 表标识
        /// </summary>
        public long id
        {
            get;
            set;
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public string CreatedTime { get; set; } = string.Empty;

        /// <summary>
        /// 创建人
        /// </summary>
        public string? CreatedBy { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public long SysVersion { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public string ModifiedTime { get; set; } = string.Empty;

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifiedBy { get; set; } = string.Empty;

        /// <summary>
        /// 组织
        /// </summary>
        public string Org { get; set; } = string.Empty;

        /// <summary>
        /// 组织编码
        /// </summary>
        public string OrgCode { get; set; } = string.Empty;

        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrgName { get; set; } = string.Empty;

        /// <summary>
        /// 单据类型
        /// </summary>
        public string DocType { get; set; } = string.Empty;

        /// <summary>
        /// 单号
        /// </summary>
        public string BusinessDate { get; set; } = string.Empty;

        /// <summary>
        /// 单号
        /// </summary>
        public string DocNo { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; } = string.Empty;

        /// <summary>
        /// 单据状态
        /// </summary>
        public int Status { get; set; } = 0;
    }
}

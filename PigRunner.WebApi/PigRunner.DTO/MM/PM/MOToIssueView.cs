using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.MM.PM
{
    /// <summary>
    /// 生产转领料
    /// </summary>
    public class MOToIssueView
    {
        /// <summary>
        /// 单据日期
        /// </summary>
        public string BusinessDate { get; set; } = string.Empty;

      
        /// <summary>
        /// 预留单据类型
        /// </summary>
        public string DocTypeCode { get; set; } = string.Empty;
        /// <summary>
        /// 明细数据
        /// </summary>
        public List<MOToIssueLineView> Lines { get; set; }=new List<MOToIssueLineView>();
    }
    /// <summary>
    /// 生产订单明细
    /// </summary>
    public class MOToIssueLineView
    {
        /// <summary>
        /// 生产订单ID
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 本次发料数量
        /// </summary>
        public decimal Qty { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public string LotCode { get; set; } = string.Empty;
    }
}

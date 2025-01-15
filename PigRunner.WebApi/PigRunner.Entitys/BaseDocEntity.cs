using PigRunner.Entitys.Basic;
using PigRunner.Entitys.Basic.Gop;
using PigRunner.Public.Abstract;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Entitys
{
    /// <summary>
    /// 单据类型基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDocEntity<T>
    {
        /// <summary>
        /// 业务标识
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnName = "ID")]
        public long ID { get; set; } = 0;
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;
        /// <summary>
        /// 版本
        /// </summary>
        public long SysVersion { get; set; } = 0;
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifiedTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifiedBy { get; set; } = string.Empty;

        /// <summary>
        /// 单据编号
        /// </summary>
        public string DocNo { get; set; }=string.Empty;
        /// <summary>
        /// 业务日期
        /// </summary>
        public DateTime BusinessDate { get; set; } = DateTime.Now;
        /// <summary>
        /// 组织ID
        /// </summary>
        public long Org { get; set; }
        /// <summary>
        /// 组织关联实体
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(Org))]//一对一Org是PurchaseOrder类里面的
        public Organization? Organization { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }=string.Empty;
        /// <summary>
        /// 状态:0 开立，1：核准中，2：已核准，3：已关闭，4：草稿
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime SubmitDate { get; set; }
        /// <summary>
        /// 提交人
        /// </summary>
        public string SubmitBy { get; set; }=string.Empty;
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime ApprovedOn { get; set;}
        /// <summary>
        /// 审核人
        /// </summary>
        public string ApprovedBy { get; set; } = string.Empty;
    }
}

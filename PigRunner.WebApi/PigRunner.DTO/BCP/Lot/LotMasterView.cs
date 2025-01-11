using PigRunner.DTO.Basic.Pub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.BCP.Lot
{
    /// <summary>
    ///批次视图
    /// </summary>
    public class LotMasterView : PubView
    {

        /// <summary>
        /// 批号
        /// </summary>
        public string LotCode { get; set; } = string.Empty;

        /// <summary>
        /// 料号
        /// </summary>
        public string ItemCode { get; set; } = string.Empty;

        /// <summary>
        /// 料品名称
        /// </summary>
        public string ItemName { get; set; } = string.Empty;

        /// <summary>
        /// 组织
        /// </summary>
        public string OrgCode { get; set; } = string.Empty;

        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrgName { get; set; } = string.Empty;

        /// <summary>
        /// 生效日期
        /// </summary>
        public string EffectiveDate { get; set; } = string.Empty;

        /// <summary>
        /// 生效天数
        /// </summary>
        public string ValidDate { get; set; } = string.Empty;

        /// <summary>
        /// 失效日期
        /// </summary>
        public string InvalidDate { get; set; } = string.Empty;

        /// <summary>
        /// 来源单号
        /// </summary>
        public string SrcDocNo { get; set; } = string.Empty;

        /// <summary>
        /// 自动编码
        /// </summary>
        public string AutoCode { get; set; } = string.Empty;


        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = string.Empty;
    }
}

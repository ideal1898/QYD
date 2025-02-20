using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.SCM.PM
{
    /// <summary>
    /// 请购单
    /// </summary>
    public class RequisitionView : DocBaseView
    {
        /// <summary>
        /// 需求部门
        /// </summary>
        public long RequriedDept { get; set; }
        /// <summary>
        /// 需求部门编码
        /// </summary>
        public string RequriedDeptCode { get; set; } = string.Empty;
        /// <summary>
        /// 需求部门名称
        /// </summary>
        public string RequriedDeptName { get; set; } = string.Empty;
        /// <summary>
        /// --需求人员
        /// </summary>
        public long RequiredMan { get; set; }
        /// <summary>
        /// 需求人员编码
        /// </summary>
        public string RequiredManCode { get; set; } = string.Empty;
        /// <summary>
        /// 需求人员名称
        /// </summary>
        public string RequiredManName { get; set; } = string.Empty;
        /// <summary>
        /// --币种
        /// </summary>
        public long Currency { get; set; }
        /// <summary>
        /// 币种编码
        /// </summary>
        public string CurrencyCode { get; set; } = string.Empty;
        /// <summary>
        /// 币种名称
        /// </summary>
        public string CurrencyName { get; set; } = string.Empty;
        /// <summary>
        /// --税率
        /// </summary>
        public decimal TaxRate { get; set; }
        /// <summary>
        /// --来源单据号
        /// </summary>
        public string SrcDocNo { get; set; } = string.Empty;
        /// <summary>
        /// --允许超额采购
        /// </summary>
        public bool IsOverPurchase { get; set; }
        /// <summary>
        /// 明细数据
        /// </summary>
        public List<RequisitionLineView> Lines { get; set; }= new List<RequisitionLineView>();
    }

    /// <summary>
    /// 请购单行
    /// </summary>
    public class RequisitionLineView : BaseView
    {
        /// <summary>
        /// --请购单
        /// </summary>
        public long Requisition { get; set; }
        /// <summary>
        /// --物料
        /// </summary>
        public long Material { get; set; }
        /// <summary>
        /// --物料编码
        /// </summary>
        public string ItemCode { get; set; } = string.Empty;
        /// <summary>
        /// 物料名称
        /// </summary>
        public string ItemName { get; set; } = string.Empty;
        /// <summary>
        /// 物料规格
        /// </summary>
        public string ItemSpec { get; set; } = string.Empty;
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UomName { get; set; } = string.Empty;
        /// <summary>
        /// 项目
        /// </summary>
        public long Project { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string ProjectCode { get; set; } = string.Empty;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; } = string.Empty;

        /// <summary>
        /// 到货数量
        /// </summary>
        public string Qty { get; set; } = string.Empty;
        /// <summary>
        /// 单价
        /// </summary>
        public string Price { get; set; } = string.Empty;
        /// <summary>
        /// 税率
        /// </summary>
        public string TaxRate { get; set; } = string.Empty;
        /// <summary>
        /// 价税合计
        /// </summary>
        public string TotalMoney { get; set; } = string.Empty;
        /// <summary>
        /// 未税金额
        /// </summary>
        public string NoTaxMoney { get; set; } = string.Empty;
        /// <summary>
        /// 税额
        /// </summary>
        public string TaxMoney { get; set; } = string.Empty;
        /// <summary>
        /// 要货日期
        /// </summary>
        public string RequireDate { get; set; } = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; } = string.Empty;
    }
}

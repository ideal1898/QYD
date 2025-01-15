using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.SCM.PM
{
    public class PurchaseOrderView:DocBaseView
    {     
        /// <summary>
        /// 币种
        /// </summary>
        public long Currency { get; set; }
        /// <summary>
        /// 币种名称
        /// </summary>
        public string CurrencyName { get; set; } = string.Empty;
        /// <summary>
        /// 来源单据类别
        /// </summary>
        public string SrcDocType { get; set; } = string.Empty;
        /// <summary>
        /// 供应商ID
        /// </summary>
        public long Supplier { get; set; }    
        /// <summary>
        /// 供应商编码
        /// </summary>
        public string SupplierCode { get; set; } = string.Empty;
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; } = string.Empty;
        /// <summary>
        /// 价税合计
        /// </summary>
        public string TotalMoney { get; set; } = string.Empty;
        /// <summary>
        /// 税额
        /// </summary>
        public string TaxMoney { get; set; } = string.Empty;
        /// <summary>
        /// 未税金额
        /// </summary>
        public string NoTaxMoney { get; set; } = string.Empty;
        /// <summary>
        /// 税率
        /// </summary>
        public string TaxRate { get; set; } = string.Empty;
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        public List<POLineView> Lines { get; set; }=new List<POLineView>();
    }

    public class POLineView:BaseView
    {       
        /// <summary>
        /// 料品ID
        /// </summary>
        public long ItemId { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string ItemCode { get; set; } = string.Empty;
        /// <summary>
        /// 品名
        /// </summary>
        public string ItemName { get; set; } = string.Empty;
        /// <summary>
        /// 规格
        /// </summary>
        public string ItemSpec { get; set; } = string.Empty;
        /// <summary>
        /// 单位
        /// </summary>
        public string UomName { get; set; } = string.Empty;
        /// <summary>
        /// 税率
        /// </summary>
        public string TaxRate { get; set; } = string.Empty;
        /// <summary>
        /// 采购数量
        /// </summary>
        public string Qty { get; set; } = string.Empty;
        /// <summary>
        /// 交期
        /// </summary>
        public string RequireDate { get; set; } = string.Empty;
        /// <summary>
        /// 单价
        /// </summary>
        public string Price { get; set; } = string.Empty;
        /// <summary>
        /// 税额
        /// </summary>
        public string TaxMoney { get; set; } = string.Empty;
        /// <summary>
        /// 未税金额
        /// </summary>
        public string NoTaxMoney { get; set; } = string.Empty;
        /// <summary>
        /// 价税合计
        /// </summary>
        public string TotalMoney { get; set; } = string.Empty;

    }
}

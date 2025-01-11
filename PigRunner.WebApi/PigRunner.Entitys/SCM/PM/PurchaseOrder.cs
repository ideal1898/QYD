using PigRunner.Entitys.Basic;
using PigRunner.Entitys.Basic.Gop;
using PigRunner.Public.Abstract;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Entitys.SCM.PM
{
    /// <summary>
    /// 采购订单
    /// </summary>
    [SqlSugar.SugarTable("QYD_PM_PurchaseOrder")]
    public class PurchaseOrder : BaseEntity<PurchaseOrder>
    {
        /// <summary>
        /// 单据编号
        /// </summary>
        public string DocNo { get; set; } = string.Empty;
        /// <summary>
        /// 单据日期
        /// </summary>
        public DateTime BusinessDate { get; set; }
        /// <summary>
        /// 币种ID
        /// </summary>
        public long CurrencyId { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(CurrencyId))]//一对一 CurrencyId是PurchaseOrder类里面的
        public Currency? Currency { get; set; }
        /// <summary>
        /// 来源类型
        /// </summary>
        public string SrcDocType { get; set; } = string.Empty;

        /// <summary>
        /// 供应商ID
        /// </summary>
        public long SupplierId { get; set; }
        /// <summary>
        /// 供应商导航关联
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(SupplierId))]//一对一 SupplierId是PurchaseOrder类里面的
        public Supplier? Supplier { get; set; }
        /// <summary>
        /// 价税合计
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 税额
        /// </summary>
        public decimal TaxMoney { get; set; }
        /// <summary>
        /// 未税金额
        /// </summary>
        public decimal NoTaxMoney { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public decimal TaxRate { get; set; }

        /// <summary>
        /// 采购订单行明细
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(POLine.PurchaseOrder))]//POLine表中的PurchaseOrder
        public List<POLine> Lines { get; set; }
    }
    /// <summary>
    /// 采购订单行
    /// </summary>
    [SqlSugar.SugarTable("QYD_PM_POLine")]
    public class POLine : BaseEntity<POLine>
    {
        /// <summary>
        /// 主表ID
        /// </summary>
        public long PurchaseOrder { get; set; }

        /// <summary>
        /// 料品ID
        /// </summary>
        public long ItemId { get; set; }
        /// <summary>
        /// 料品
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(ItemId))]//一对一 ItemId是POLine类里面的
        public Item Item { get; set; }
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
        public decimal TaxRate { get; set; }
        /// <summary>
        /// 采购数量
        /// </summary>
        public decimal Qty { get; set; }
        /// <summary>
        /// 交期
        /// </summary>
        public DateTime RequireDate { get; set; }
        /// <summary>
        /// 采购单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 税额
        /// </summary>
        public decimal TaxMoney { get; set; }
        /// <summary>
        /// 未税金额
        /// </summary>
        public decimal NoTaxMoney { get; set; }
        /// <summary>
        /// 价税合计
        /// </summary>
        public decimal TotalMoney { get; set; }

    }
}

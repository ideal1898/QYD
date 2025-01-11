using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.SCM.PM
{
    public struct PurchaseOrderView
    {
        /// <summary>
        /// 标识
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public long SysVersion { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 单据编号
        /// </summary>
        public string DocNo { get; set; }
        /// <summary>
        /// 单据日期
        /// </summary>
        public DateTime BusinessDate { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public long CurrencyId { get; set; }
        /// <summary>
        /// 币种名称
        /// </summary>
        public string CurrencyName { get; set; }
        /// <summary>
        /// 来源单据类别
        /// </summary>
        public string SrcDocType { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public long SupplierId { get; set; }
        /// <summary>
        /// 供应商编码
        /// </summary>
        public string SupplierCode { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 价税合计
        /// </summary>
        public string TotalMoney { get; set; }
        /// <summary>
        /// 税额
        /// </summary>
        public string TaxMoney { get; set; }
        /// <summary>
        /// 未税金额
        /// </summary>
        public string NoTaxMoney { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public string TaxRate { get; set; }

        public List<POLineView> Lines { get; set; }
    }

    public struct POLineView
    {
        /// <summary>
        /// 标识
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public long SysVersion { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 料品ID
        /// </summary>
        public long ItemId { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 品名
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string ItemSpec { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UomName { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public string TaxRate { get; set; }
        /// <summary>
        /// 采购数量
        /// </summary>
        public string Qty { get; set; }
        /// <summary>
        /// 交期
        /// </summary>
        public DateTime RequireDate { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 税额
        /// </summary>
        public string TaxMoney { get; set; }
        /// <summary>
        /// 未税金额
        /// </summary>
        public string NoTaxMoney { get; set; }
        /// <summary>
        /// 价税合计
        /// </summary>
        public string TotalMoney { get; set; }

    }
}

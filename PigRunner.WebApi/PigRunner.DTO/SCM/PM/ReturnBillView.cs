using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.SCM.PM
{
    /// <summary>
    /// 采购退货单
    /// </summary>
    public class ReturnBillView : DocBaseView
    {
        /// <summary>
        /// 供应商
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
        /// 收货部门
        /// </summary>
        public long Department { get; set; }
        /// <summary>
        /// 收货部门编码
        /// </summary>
        public string DepartmentCode { get; set; } = string.Empty;
        /// <summary>
        /// 收货部门名称
        /// </summary>
        public string DepartmentName { get; set; } = string.Empty;
        /// <summary>
        /// 需求部门ID
        /// </summary>
        public long RequiredDept { get; set; }
        /// <summary>
        /// 需求部门编码
        /// </summary>
        public string RequiredDeptCode { get; set; } = string.Empty;
        /// <summary>
        /// 需求部门编码
        /// </summary>
        public string RequiredDeptName { get; set; } = string.Empty;
        /// <summary>
        /// 需求人员ID
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
        /// 收货人
        /// </summary>
        public string Consignee { get; set; } = string.Empty;
        /// <summary>
        /// 收货地址
        /// </summary>
        public string DeliveryAddress { get; set; } = string.Empty;
        /// <summary>
        /// 币种ID
        /// </summary>
        public long Currency { get; set; }
        /// <summary>
        /// 币种名称
        /// </summary>
        public string CurrencyName { get; set; } = string.Empty;
        /// <summary>
        /// 价格含税
        /// </summary>
        public bool IsPriceIncludeTax { get; set; }
        /// <summary>
        /// 来源单据号
        /// </summary>
        public string SrcDocNo { get; set; } = string.Empty;
        /// <summary>
        /// 业务员ID
        /// </summary>
        public long SalesMan { get; set; }
        /// <summary>
        /// 业务员编码
        /// </summary>
        public string SalesManCode { get; set; } = string.Empty;
        /// <summary>
        /// 业务员名称
        /// </summary>
        public string SalesManName { get; set; } = string.Empty;
        /// <summary>
        /// 明细数据
        /// </summary>
        public List<ReturnBillLineView> Lines { get; set; } = new List<ReturnBillLineView>();

    }

    /// <summary>
    /// 采购退货单行
    /// </summary>
    public class ReturnBillLineView : BaseView
    {
        /// <summary>
        /// 采购收货单
        /// </summary>
        public long ReturnBill { get; set; }
        /// <summary>
        /// //料品ID
        /// </summary>
        public long Material { get; set; }
        /// <summary>
        /// //物料编码
        /// </summary>
        public string ItemCode { get; set; } = string.Empty;
        /// <summary>
        /// //物料名称
        /// </summary>
        public string ItemName { get; set; } = string.Empty;
        /// <summary>
        /// //物料规格
        /// </summary>
        public string ItemSpec { get; set; } = string.Empty;
        /// <summary>
        /// //单位
        /// </summary>
        public string UomName { get; set; } = string.Empty;
        /// <summary>
        /// //收货数量
        /// </summary>
        public string Qty { get; set; } = string.Empty;
        /// <summary>
        /// //退货数量
        /// </summary>
        public string RtnQty { get; set; } = string.Empty;
        /// <summary>
        /// //单价
        /// </summary>
        public string Price { get; set; } = string.Empty;
        /// <summary>
        /// //税率
        /// </summary>
        public string TaxRate { get; set; } = string.Empty;
        /// <summary>
        /// //价税合计
        /// </summary>
        public string TotalMoney { get; set; } = string.Empty;
        /// <summary>
        /// //未税金额
        /// </summary>
        public string NoTaxMoney { get; set; } = string.Empty;
        /// <summary>
        /// //税额
        /// </summary>
        public string TaxMoney { get; set; } = string.Empty;
        /// <summary>
        /// //批次
        /// </summary>
        public long LotMaster { get; set; }
        /// <summary>
        /// //批号
        /// </summary>
        public string LotCode { get; set; } = string.Empty;
        /// <summary>
        /// //仓库
        /// </summary>
        public long Wh { get; set; }
        /// <summary>
        /// //仓库编码
        /// </summary>
        public string WhCode { get; set; } = string.Empty;
        /// <summary>
        /// //仓库名称
        /// </summary>
        public string WhName { get; set; } = string.Empty;
        /// <summary>
        /// //库位
        /// </summary>
        public long Bin { get; set; }
        /// <summary>
        /// //库位编码
        /// </summary>
        public string BinCode { get; set; } = string.Empty;
        /// <summary>
        /// //库位名称
        /// </summary>
        public string BinName { get; set; } = string.Empty;
        /// <summary>
        /// //库管员
        /// </summary>
        public long Treasurer { get; set; }
        /// <summary>
        /// //库管员编码
        /// </summary>
        public string TreasurerCode { get; set; } = string.Empty;
        /// <summary>
        /// //库管员名称
        /// </summary>
        public string TreasurerName { get; set; } = string.Empty;
        /// <summary>
        /// //项目
        /// </summary>
        public long Project { get; set; }
        /// <summary>
        /// //项目编码
        /// </summary>
        public string ProjectCode { get; set; } = string.Empty;
        /// <summary>
        /// //项目名称
        /// </summary>
        public string ProjectName { get; set; } = string.Empty;
        /// <summary>
        /// //生产日期
        /// </summary>
        public string ProduceDate { get; set; } = string.Empty;
        /// <summary>
        /// //生效日期
        /// </summary>
        public string EffectiveDate { get; set; } = string.Empty;
        /// <summary>
        /// //保质天数
        /// </summary>
        public string Expiration { get; set; } = string.Empty;
        /// <summary>
        /// //失效日期
        /// </summary>
        public string ExpirationDate { get; set; } = string.Empty;
        /// <summary>
        /// //备注
        /// </summary>
        public string Memo { get; set; } = string.Empty;
        /// <summary>
        /// //来源单据号
        /// </summary>
        public string SrcDocNo { get; set; } = string.Empty;
        /// <summary>
        /// //来源单据行
        /// </summary>
        public long SrcDocLine { get; set; }
        /// <summary>
        /// //到货日期
        /// </summary>
        public string ArriveDate { get; set; } = string.Empty;
        /// <summary>
        /// //入库确认日期
        /// </summary>
        public string ConfirmDate { get; set; } = string.Empty;
    }
}

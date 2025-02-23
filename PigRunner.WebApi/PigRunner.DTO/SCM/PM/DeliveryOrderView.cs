using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.SCM.PM
{
    /// <summary>
    /// 采购到货单
    /// </summary>
    public class DeliveryOrderView: DocBaseView
    {
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
        /// 部门ID
        /// </summary>
        public long Department { get; set; }
        /// <summary>
        /// 部门编码
        /// </summary>
        public string DepartmentCode { get; set; } = string.Empty;
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; } =string.Empty;
        /// <summary>
        /// 业务员ID
        /// </summary>
        public long SalesMan { get; set; }
        /// <summary>
        /// 业务员编码
        /// </summary>
        public string SalesManCode { get; set;} = string.Empty;
        /// <summary>
        /// 业务员名称
        /// </summary>
        public string SaleManName { get; set;} = string.Empty;
        /// <summary>
        /// 价格含税： 未税单价=含税单价/(1-税率)
        /// 价格不含税 含税单价=未税单价*(1+税率)
        /// </summary>
        public bool IsPriceIncludeTax { get; set; }
        /// <summary>
        /// 来源单据号
        /// </summary>
        public string SrcDocNo { get; set; } = string.Empty;
        /// <summary>
        /// 明细数据
        /// </summary>
        public List<DeliveryOrderLineView> Lines { get; set; }=new List<DeliveryOrderLineView>();
    }
    /// <summary>
    /// 采购到货明细行
    /// </summary>
    public class DeliveryOrderLineView:BaseView
    {
        /// <summary>
        /// 采购到货单ID
        /// </summary>
        public long DeliveryOrder { get; set; }

        /// <summary>
        /// 料品ID
        /// </summary>
        public long Material { get; set; }
        /// <summary>
        /// 料号
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
        /// 到货数量
        /// </summary>
        public string Qty { get; set; } = string.Empty;
        /// <summary>
        /// 已入库数量
        /// </summary>
        public string StorageQty { get; set; } = string.Empty;
        /// <summary>
        /// 单价
        /// </summary>
        public string Price { get; set; } = string.Empty;
        /// <summary>
        /// 税率
        /// </summary>
        public string TaxRate { get; set; } = string.Empty;
        /// <summary>
        /// 批次
        /// </summary>
        public long LotMaster { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public string LotCode { get; set;} = string.Empty;      
        /// <summary>
        /// 仓库ID
        /// </summary>
        public long Wh { get; set; }
        /// <summary>
        /// 仓库编码
        /// </summary>
        public string WhCode { get; set; } = string.Empty;
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WhName { get; set; } = string.Empty;
        /// <summary>
        /// 货位
        /// </summary>
        public long Bin { get; set; }
        /// <summary>
        /// 货位编码
        /// </summary>
        public string BinCode { get; set; } = string.Empty; 
        /// <summary>
        /// 货位名称
        /// </summary>
        public string BinName { get; set; }=string.Empty;    
        /// <summary>
        /// 生产日期
        /// </summary>
        public string ProduceDate { get; set; } = string.Empty;
        /// <summary>
        /// 保质天数
        /// </summary>
        public int Expiration { get; set; }
        /// <summary>
        /// 失效日期
        /// </summary>
        public string ExpirationDate { get; set; } = string.Empty;
        /// <summary>
        /// 生效日期
        /// </summary>
        public string EffectiveDate { get; set; }=string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; } = string.Empty;
    }
}

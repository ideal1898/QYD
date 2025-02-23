using PigRunner.Entitys.Basic;
using PigRunner.Entitys.Basic.Gop;
using PigRunner.Entitys.BCP.Lot;
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
    /// 采购到货单
    /// </summary>
    [SqlSugar.SugarTable("QYD_PM_DeliveryOrder")]
    public class DeliveryOrder:BaseDocEntity<DeliveryOrder>
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        public long Supplier { get; set; }
        /// <summary>
        /// 供应商实体关联属性
        /// </summary>
        [Navigate(NavigateType.OneToOne,nameof(Supplier))]
        public Supplier? Supp { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public long Department { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        [Navigate(NavigateType.OneToOne,nameof(Department))]
        public Department? Dept { get; set; }
        /// <summary>
        /// 业务员ID
        /// </summary>
        public long SalesMan { get; set; }
        /// <summary>
        /// 业务员
        /// </summary>
        [Navigate(NavigateType.OneToOne,nameof(SalesMan))]
        public Operators? Operators { get; set; }

        /// <summary>
        /// 价格含税： 未税单价=含税单价/(1-税率)
        /// 价格不含税 含税单价=未税单价*(1+税率)
        /// </summary>
        public bool IsPriceIncludeTax { get; set; }

        /// <summary>
        /// 来源单据号
        /// </summary>
        public string SrcDocNo { get; set; }=string.Empty;
        /// <summary>
        /// 明细行
        /// </summary>
        [Navigate(NavigateType.OneToMany,nameof(DeliveryOrderLine.DeliveryOrder))]
        public List<DeliveryOrderLine>? Lines { get; set; }
    }


    /// <summary>
    /// 采购到货单行
    /// </summary>
    [SqlSugar.SugarTable("QYD_PM_DeliveryOrderLine")]
    public class DeliveryOrderLine:LineBaseEntity
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
        /// 物料实体
        /// </summary>
        [Navigate(NavigateType.OneToOne,nameof(Material))]
        public Item? Item { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string ItemCode { get; set; }=string.Empty;
        /// <summary>
        /// 物料名称
        /// </summary>
        public string ItemName { get; set; } = string.Empty;
        /// <summary>
        /// 物料规格
        /// </summary>
        public string ItemSpec { get; set; }= string.Empty;
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UomName { get; set; } = string.Empty;
        /// <summary>
        /// 到货数量
        /// </summary>
        public decimal Qty { get; set; }
        /// <summary>
        /// 已入库数量
        /// </summary>
        public decimal StorageQty { get; set; }
        
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public decimal TaxRate { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        public long LotMaster { get; set; }
        /// <summary>
        /// 批次实体
        /// </summary>
        [Navigate(NavigateType.OneToOne,nameof(LotMaster))]
        public LotMaster? Lot { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public long Wh { get; set; }
        /// <summary>
        /// 仓库实体
        /// </summary>
        [Navigate(NavigateType.OneToOne,nameof(Wh))]
        public Wh? Warehouse { get; set; }
        /// <summary>
        /// 货位
        /// </summary>
        public long Bin { get; set; }
        /// <summary>
        /// 货位实体
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(Bin))]
        public WhSh? Freight { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? ProduceDate { get; set; }
        /// <summary>
        /// 保质天数
        /// </summary>
        public int Expiration { get; set; }
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime? EffectiveDate { get; set; }
        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime ExpirationDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }=string.Empty ;
      
    }
}

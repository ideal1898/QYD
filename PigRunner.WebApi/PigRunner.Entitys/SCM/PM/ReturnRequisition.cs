﻿using PigRunner.Entitys.Basic.Gop;
using PigRunner.Entitys.Basic;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PigRunner.Entitys.BCP.Lot;
using PigRunner.Public.Abstract;

namespace PigRunner.Entitys.SCM.PM
{

    /// <summary>
    /// 采购退货申请单
    /// </summary>
    [SqlSugar.SugarTable("QYD_PM_ReturnRequisition")]
    public class ReturnRequisition : BaseDocEntity<ReturnRequisition>
    {
        /// <summary>
        /// 供应商
        /// </summary>
        public long Supplier { get; set; }
        /// <summary>
        /// 供应商实体
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(Supplier))]
        public Supplier? Supp { get; set; }

        /// <summary>
        /// 退货部门
        /// </summary>
        public long RtnDept { get; set; }
        /// <summary>
        /// 退货部门实体
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(RtnDept))]
        public Department? ReqRtnDept { get; set; }

        /// <summary>
        /// 需求人员ID
        /// </summary>
        public long RtnMan { get; set; }
        /// <summary>
        /// 需求人员实体
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(RtnMan))]
        public Operators? ReqRtnMan { get; set; }
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
        /// 币种实体
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(Currency))]
        public Currency? Symbol { get; set; }
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
        /// 业务员实体
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(SalesMan))]
        public Operators? Operators { get; set; }

        /// <summary>
        /// 明细数据
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(ReturnRequisitionLine.ReturnRequisition))]
        public List<ReturnRequisitionLine> Lines { get; set; }
    }

    /// <summary>
    /// 采购退货申请单
    /// </summary>
    [SqlSugar.SugarTable("QYD_PM_ReturnRequisitionLine")]
    public class ReturnRequisitionLine:LineBaseEntity
    {
        /// <summary>
        /// 采购退货申请单
        /// </summary>
        public long ReturnRequisition { get; set; }
        /// <summary>
        /// 物料ID
        /// </summary>
        public long Material { get; set; }
        /// <summary>
        /// 物料
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(Material))]
        public Item? Item { get; set; }
        /// <summary>
        /// 物料编码
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
        /// 单位
        /// </summary>
        public string UomName { get; set; } = string.Empty;
        /// <summary>
        /// 收货数量
        /// </summary>
        public decimal Qty { get; set; }
        /// <summary>
        /// 退货数量
        /// </summary>
        public decimal RtnQty { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public decimal TaxRate { get; set; }
        /// <summary>
        /// 价税合计
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 未税金额
        /// </summary>
        public decimal NoTaxMoney { get; set; }
        /// <summary>
        /// 税额
        /// </summary>
        public decimal TaxMoney { get; set; }
        /// <summary>
        /// 批次
        /// </summary>
        public long LotMaster { get; set; }
        /// <summary>
        /// 批次实体
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(LotMaster))]
        public LotMaster? Lot { get; set; }
        /// <summary>
        /// 仓库
        /// </summary>
        public long Wh { get; set; }
        /// <summary>
        /// 仓库实体
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(Wh))]
        public Wh? Warehouse { get; set; }
        /// <summary>
        /// 货位ID
        /// </summary>
        public long Bin { get; set; }
        /// <summary>
        /// 货位实体
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(Bin))]
        public WhSh? Freight { get; set; }
        /// <summary>
        /// 库管员
        /// </summary>
        public long Treasurer { get; set; }
        /// <summary>
        /// 库管员实体
        /// </summary>
        public Operators? Operator { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        public long Project { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(Project))]
        public Project? Pro { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? ProduceDate { get; set; }
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime EffectiveDate { get; set; }
        /// <summary>
        /// 保质天数
        /// </summary>
        public int Expiration { get; set; }
        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime? ExpirationDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; } = string.Empty;
    }
}

using PigRunner.Entitys.Basic;
using PigRunner.Entitys.BCP.Lot;
using PigRunner.Public.Abstract;
using SqlSugar;

namespace PigRunner.Entitys.MM.PM
{
    /// <summary>
    /// 完工入库单
    /// </summary>
    [SqlSugar.SugarTable("QYD_MM_RcvRpt")]
    public class RcvRpt : BaseEntity<RcvRpt>
    {
        /// <summary>
        /// 入库组织
        /// </summary>
        public long Org { get; set; } = 0;

        /// <summary>
        /// 组织导航关联
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(Org))]//一对一
        public Organization? Organization { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        public string DocType { get; set; } = string.Empty;

        /// <summary>
        /// 单号
        /// </summary>
        public string DocNo { get; set; } = string.Empty;


        /// <summary>
        /// 单据日期
        /// </summary>
        public DateTime BusinessDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; } = string.Empty;


        /// <summary>
        /// 单据状态
        /// </summary>
        public int Status { get; set; } = 0;

        /// <summary>
        /// 入库部门
        /// </summary>
        public long RcvDeptID { get; set; } = 0;

        /// <summary>
        /// 部门导航关联
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(RcvDeptID))]//一对一
        public Department? RcvDept { get; set; }

        /// <summary>
        /// 仓管员
        /// </summary>
        public long RcvPersonID { get; set; } = 0;

        /// <summary>
        /// 导航关联
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(RcvPersonID))]//一对一
        public Operators? RcvPerson { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime ActualRcvTime { get; set; }


        /// <summary>
        /// 完工入库单明细
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(RcvRptLine.RcvRptID))] // 如果使用了外键列名，可以指定  
        public List<RcvRptLine> RcvRptLines { get; set; }
    }

    /// <summary>
    /// 完工入库单行
    /// </summary>
    [SqlSugar.SugarTable("QYD_MM_RcvRptLine")]
    public class RcvRptLine : BaseEntity<RcvRptLine>
    {
        /// <summary>
        /// 完工入库单ID
        /// </summary>
        public long RcvRptID { get; set; } = 0;

        /// <summary>
        /// 行号
        /// </summary>
        public int LineNum { get; set; } = 0;

        /// <summary>
        /// 生产订单行ID
        /// </summary>
        public long MOLineID { get; set; } = 0;

        /// <summary>
        /// 生产单号
        /// </summary>
        public string MODocNo { get; set; } = string.Empty;

        /// <summary>
        /// 生产单行号
        /// </summary>
        public string MOLineNum { get; set; } = string.Empty;

        /// <summary>
        /// 母件料品
        /// </summary>
        public long BOMItemID { get; set; } = 0;

        /// <summary>
        /// 导航关联
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(BOMItemID))]//一对一
        public Item BOMItemMaster { get; set; }


        /// <summary>
        /// 料品
        /// </summary>
        public long ItemID { get; set; } = 0;

        /// <summary>
        /// 导航关联
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(ItemID))]//一对一
        public Item ItemMaster { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public decimal RcvQty { get; set; } = 0;

        /// <summary>
        /// 入库单位
        /// </summary>
        public long RcvUomID { get; set; } = 0;

        /// <summary>
        /// 导航关联
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(RcvUomID))]//一对一
        public UOM RcvUom { get; set; }


        /// <summary>
        /// 入库仓库
        /// </summary>
        public long RcvWhID { get; set; } = 0;

        /// <summary>
        /// 导航关联
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(RcvWhID))]//一对一
        public Wh RcvWh { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        public long LotMasterID { get; set; } = 0;

        /// <summary>
        /// 导航关联
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(LotMasterID))]//一对一
        public LotMaster? LotMaster { get; set; }


        /// <summary>
        /// 货位
        /// </summary>
        public long WhShID { get; set; } = 0;

        /// <summary>
        /// 导航关联
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(WhShID))]//一对一
        public WhSh? WhSh { get; set; }
        
    }
}

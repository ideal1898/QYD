using PigRunner.Entitys.Basic;
using PigRunner.Entitys.BCP.Lot;
using PigRunner.Public.Abstract;
using SqlSugar;

namespace PigRunner.Entitys.MM.PM
{
    /// <summary>
    /// 退料单
    /// </summary>
    [SqlSugar.SugarTable("QYD_MM_RtnIssue")]
    public class RtnIssue : BaseEntity<RtnIssue>
    {
        /// <summary>
        /// 发料组织
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
        /// 发料部门
        /// </summary>
        public long HandleDeptID { get; set; } = 0;

        /// <summary>
        /// 部门导航关联
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(HandleDeptID))]//一对一
        public Department? HandleDept { get; set; }

        /// <summary>
        /// 发料人
        /// </summary>
        public long HandlePersonID { get; set; } = 0;

        /// <summary>
        /// 导航关联
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(HandlePersonID))]//一对一
        public Operators? HandlePerson { get; set; }

        /// <summary>
        /// 确认日期
        /// </summary>
        public DateTime BusinessCreatedOn { get; set; }


        /// <summary>
        /// 领料单明细
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(RtnIssueLine.RtnIssueID))] // 如果使用了外键列名，可以指定  
        public List<RtnIssueLine> RtnIssueLines { get; set; }
    }

    /// <summary>
    /// 领料单行
    /// </summary>
    [SqlSugar.SugarTable("QYD_MM_RtnIssueLine")]
    public class RtnIssueLine : BaseEntity<RtnIssueLine>
    {
        /// <summary>
        /// 领料单ID
        /// </summary>
        public long RtnIssueID { get; set; } = 0;

        /// <summary>
        /// 行号
        /// </summary>
        public int LineNum { get; set; } = 0;

        /// <summary>
        /// 领料行ID
        /// </summary>
        public long IssueLineID { get; set; } = 0;

        /// <summary>
        /// 领料单号
        /// </summary>
        public string IssueDocNo { get; set; } = string.Empty;


        /// <summary>
        /// 退料理由
        /// </summary>
        public int RecedeReason { get; set; } = -1;
        

        /// <summary>
        /// 领料行号
        /// </summary>
        public string IssueLineNum { get; set; } = string.Empty;

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
        /// 生产数量
        /// </summary>
        public decimal MoQty { get; set; } = 0;


        /// <summary>
        /// 应发数量
        /// </summary>
        public decimal IssueQty { get; set; } = 0;


        /// <summary>
        /// 实发数量
        /// </summary>
        public decimal IssuedQty { get; set; } = 0;

        /// <summary>
        /// 发料单位
        /// </summary>
        public long IssueUomID { get; set; } = 0;

        /// <summary>
        /// 导航关联
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(IssueUomID))]//一对一
        public UOM IssueUom { get; set; }


        /// <summary>
        /// 发料仓库
        /// </summary>
        public long IssueWhID { get; set; } = 0;

        /// <summary>
        /// 导航关联
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(IssueWhID))]//一对一
        public Wh IssueWh { get; set; }

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

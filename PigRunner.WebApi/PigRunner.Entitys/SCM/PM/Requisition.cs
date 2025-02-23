using PigRunner.Entitys.Basic;
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
    /// 请购单
    /// </summary>
    [SqlSugar.SugarTable("QYD_PM_Requisition")]
    public class Requisition:BaseDocEntity<Requisition>
    {
        /// <summary>
        /// 需求部门
        /// </summary>
        public long RequriedDept { get; set; }
        /// <summary>
        /// 需求部门实体
        /// </summary>
        [SqlSugar.Navigate(SqlSugar.NavigateType.OneToOne,nameof(RequriedDept))]
        public Department? ReqDepartment { get; set; }

        /// <summary>
        /// 需求人员
        /// </summary>
        public long RequiredMan { get; set; }
        /// <summary>
        /// 需求人员实体
        /// </summary>
        [SqlSugar.Navigate(SqlSugar.NavigateType.OneToOne, nameof(RequiredMan))]
        public Operators? ReqMan { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public long Currency { get; set; }
        /// <summary>
        /// 币种实体
        /// </summary>
        [SqlSugar.Navigate(SqlSugar.NavigateType.OneToOne, nameof(Currency))]
        public Currency? Symbol { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public decimal TaxRate { get; set; }
        /// <summary>
        /// 来源单据号
        /// </summary>
        public string SrcDocNo { get; set; }=string.Empty;
        /// <summary>
        /// 允许超额采购
        /// </summary>
        public bool IsOverPurchase { get; set; }
        /// <summary>
        /// 明细行
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(RequisitionLine.Requisition))]
        public List<RequisitionLine> Lines { get; set; }

    }
    /// <summary>
    /// 请购单行
    /// </summary>
    [SqlSugar.SugarTable("QYD_PM_RequisitionLine")]
    public class RequisitionLine:LineBaseEntity{
        /// <summary>
        /// --请购单
        /// </summary>
        public long Requisition { get; set; }
        [SqlSugar.Navigate(SqlSugar.NavigateType.ManyToOne, nameof(Requisition))]
        public Requisition? Reqution { get; set; }

        /// <summary>
        /// --物料
        /// </summary>
        public long Material { get; set; }
        /// <summary>
        /// 料品关联实体
        /// </summary>
        [SqlSugar.Navigate(SqlSugar.NavigateType.OneToOne,nameof(Material))]
        public Item? Item { get; set; }

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
        /// 项目关联实体
        /// </summary>
        [Navigate(NavigateType.OneToOne,nameof(Project))]
        public Project? Pro { get; set; }
        /// <summary>
        /// 到货数量
        /// </summary>
        public decimal Qty { get; set; }
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
        /// 要货日期
        /// </summary>
        public DateTime RequireDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; } = string.Empty;


    }
}

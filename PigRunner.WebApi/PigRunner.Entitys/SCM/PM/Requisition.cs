using PigRunner.Entitys.Basic;
using PigRunner.Public.Abstract;
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
        public long Currency;
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

    }
    /// <summary>
    /// 请购单行
    /// </summary>
    [SqlSugar.SugarTable("QYD_PM_RequisitionLine")]
    public class RequisitionLine:BaseEntity<RequisitionLine> { 
    
    }
}

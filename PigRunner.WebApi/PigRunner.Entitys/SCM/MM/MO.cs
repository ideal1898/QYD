using PigRunner.Public.Abstract;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Entitys.SCM.MM
{
    /// <summary>
    /// 生产订单
    /// </summary>
    [SqlSugar.SugarTable("QYD_SCM_MO")]
    public class MO : BaseEntity<MO>
    {
        /// <summary>
        /// 组织
        /// </summary>
        public long MoOrg { get; set; } = 0;

        /// <summary>
        /// 单据类型
        /// </summary>
        public string DocType { get; set; } = string.Empty;

        /// <summary>
        /// 单号
        /// </summary>
        public string DocNo { get; set; } = string.Empty;

        /// <summary>
        /// 计划开工日
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
        public DateTime BusinessDate { get; set; }

        /// <summary>
        /// 生产部门
        /// </summary>
        public long MoDept { get; set; } = 0;

        /// <summary>
        /// 业务员
        /// </summary>
        public long BusinessPerson { get; set; } = 0;

        /// <summary>
        /// 计划完工日
        /// </summary>
        public DateTime CompleteDate { get; set; }

        /// <summary>
        /// 完工仓库
        /// </summary>
        public long CompleteWh { get; set; } = 0;

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; } = string.Empty;


        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifiedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifiedBy { get; set; } = string.Empty;


        /// <summary>
        /// 生产订单明细
        /// </summary>
        [Navigate(NavigateType.OneToMany, nameof(MOLine.MO))] // 如果使用了外键列名，可以指定  
        public List<MOLine>? MOLines { get; set; } = null;
    }

    /// <summary>
    /// 生产订单行
    /// </summary>
    [SqlSugar.SugarTable("QYD_SCM_MOLine")]
    public class MOLine : BaseEntity<MOLine>
    {
        /// <summary>
        /// 生产订单ID
        /// </summary>
        public long MO { get; set; } = 0;

        /// <summary>
        /// 行号
        /// </summary>
        public int LineNum { get; set; } = 0;

        /// <summary>
        /// 料品
        /// </summary>
        public long Item { get; set; } = 0;


        /// <summary>
        /// 生产数量
        /// </summary>
        public decimal MoQty { get; set; } = 0;

        /// <summary>
        /// 生产单位
        /// </summary>
        public long MoUom { get; set; } = 0;

        /// <summary>
        /// 计划开工日
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 计划完工日
        /// </summary>
        public DateTime CompleteDate { get; set; }

        /// <summary>
        /// 来源单据
        /// </summary>
        public string SrcDocType { get; set; } = string.Empty;

        /// <summary>
        /// 来源单号
        /// </summary>
        public string SrcDocNo { get; set; } = string.Empty;

        /// <summary>
        /// 业务开始时间
        /// </summary>
        public DateTime ActualStartDate { get; set; }

        /// <summary>
        /// 业务结束时间
        /// </summary>
        public DateTime ActualCompleteDate { get; set; }

        /// <summary>
        /// bom版本号
        /// </summary>
        public string BomVersion { get; set; } = string.Empty;

        /// <summary>
        /// 工艺路线
        /// </summary>
        public string Routing { get; set; } = string.Empty;

        /// <summary>
        /// 批次
        /// </summary>
        public long LotMaster { get; set; } = 0;


        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifiedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifiedBy { get; set; } = string.Empty;
    }
}

using PigRunner.Public.Abstract;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Entitys.BarCode
{
     [SqlSugar.SugarTable("QYD_BC_LotRule")]
    public class BCLotRule : BaseEntity<BCLotRule>
    {
        /// <summary>
        /// 规则编码
        /// </summary>
        public string RuleCode { get; set; } = string.Empty;

        /// <summary>
        /// 规则名称
        /// </summary>
        public string RuleName { get; set; } = string.Empty;

        /// <summary>
        /// 组织
        /// </summary>
        public long Org { get; set; } = 0;

        /// <summary>
        /// 规则描述
        /// </summary>
        public string RuleDes { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; } = string.Empty;

        // 反向导航属性（可选）  
        [Navigate(NavigateType.OneToMany, "BCLotRuleLines")] // 如果使用了外键列名，可以指定  
        public List<BCLotRuleLine>? BCLotRuleLines { get; set; } = null;
    }

    [SqlSugar.SugarTable("QYD_BC_LotRuleLine")]
    public class BCLotRuleLine : BaseEntity<BCLotRuleLine>
    {
        // 导航属性  
       // [Navigate(NavigateType.OneToOne, nameof(LotRule))]
        public long LotRule { get; set; } = 0;

        /// <summary>
        /// 数据源类型:0-固定项；1-组织；2-料号；3-单据日期；4-流水项
        /// </summary>
        public int DsType { get; set; } = -1;

        /// <summary>
        /// 格式
        /// </summary>
        public int DtFormat { get; set; } = -1;


        /// <summary>
        /// 补位符
        /// </summary>
        public string FillInCode { get; set; }= string.Empty;

        /// <summary>
        /// 分隔符
        /// </summary>
        public string SplitCode { get; set; } = string.Empty;

        /// <summary>
        /// 是否流水依据
        /// </summary>
        public bool IsFlow { get; set; } = false;

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; } = string.Empty;
    }
}

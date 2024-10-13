using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public.Common.Views
{
    public class LotRlueRequest
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
        public string Org { get; set; } = string.Empty;

        /// <summary>
        /// 规则描述
        /// </summary>
        public string RuleDes { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; } = string.Empty;

        /// <summary>
        /// 分配规则明细
        /// </summary>
        public List<BCLotRuleLineDTO>? BCLotRuleLines { get; set; } = null;

        /// <summary>
        /// 操作类型：0：新增；1：删除；2：查询
        /// </summary>
        public int OptType { get; set; } = 0;
    }
    public class BCLotRuleLineDTO
    {
       

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
        public string FillInCode { get; set; } = string.Empty;

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

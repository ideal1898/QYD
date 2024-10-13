using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.System.IServices
{
    public interface ILotRuleService : IScopedService
    {
        /// <summary>
        /// 批次规则
        /// </summary>
        /// <param name="RuleCode"></param>
        /// <param name="RuleName"></param>
        /// <param name="Org"></param>
        /// <param name="RuleDes"></param>
        /// <param name="Memo"></param>
        /// <param name="BCLotRuleLines"></param>
        /// <param name="OptType"></param>
        /// <returns></returns>
        PubResponse ActionLotRule(string RuleCode, string RuleName, string Org, string RuleDes,string Memo, List<BCLotRuleLineDTO> BCLotRuleLines, int OptType);

    }
}

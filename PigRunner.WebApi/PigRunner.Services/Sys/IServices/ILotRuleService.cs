using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Sys.IServices
{
    public interface ILotRuleService : IScopedService
    {
        /// <summary>
        /// 批号规则
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PubResponse ActionLotRule(LotRlueRequest request);

    }
}

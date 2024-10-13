using PigRunner.Entitys.BarCode;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.System;
using PigRunner.Services.System.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.System.Services
{
      /// <summary>
      /// 批号规则服务
      /// </summary>
    public class LotRuleService : ILotRuleService
    {
        private LotRuleRepository repository;

        /// <summary>
        /// 批次规则服务
        /// </summary>
        /// <param name="_repository">批号仓库</param>
        public LotRuleService(LotRuleRepository _repository)
        {
            this.repository = _repository;
        }

      

        /// <summary>
        /// 批号规则
        /// </summary>
        /// <param name="RuleCode"></param>
        /// <param name="RuleName"></param>
        /// <param name="Org"></param>
        /// <param name="RuleDes"></param>
        /// <param name="Memo"></param>
        /// <param name="BCLotRuleLines"></param>
        /// <param name="OptType"></param>
        /// <returns></returns>
        public PubResponse ActionLotRule(string RuleCode, string RuleName, string Org, string RuleDes, string Memo, List<BCLotRuleLineDTO> BCLotRuleLines, int OptType)
        {
            PubResponse response = new PubResponse();

            try
            {
                if (string.IsNullOrEmpty(RuleCode))
                    throw new Exception("规则编码不能为空！");
                
                if (OptType == 0)
                {
                    BCLotRule head = repository.GetBCLotRule(RuleCode);
                    if (head != null)
                        throw new Exception(string.Format("规则编码为【{0}】的批次规则已存在，不能再新增！",RuleCode));

                    if (BCLotRuleLines == null || BCLotRuleLines.Count <= 0)
                        throw new Exception("批次规则明细不能为空！");

                    head = BCLotRule.Create();
                    head.RuleCode = RuleCode;
                    head.RuleName = RuleName;

                    long OrgID = 0;
                    long.TryParse(Org, out OrgID);
                    head.Org = OrgID;

                    head.RuleDes = RuleDes;
                    head.Memo = Memo;

                   

                    List<BCLotRuleLine> lines = new List<BCLotRuleLine>();
                    //将单头ID赋值给明细
                    foreach (var item in BCLotRuleLines)
                    {
                        BCLotRuleLine line= BCLotRuleLine.Create();
                        line.LotRule = head.ID;
                        line.DtFormat=item.DtFormat;
                        line.FillInCode = item.FillInCode;
                        line.IsFlow=item.IsFlow;
                        line.SplitCode = item.SplitCode;
                        line.Memo=item.Memo;
                        lines.Add(line);
                    }

                    head.BCLotRuleLines = lines;
                    response.id = head.ID;

                    //先插入单头
                    bool flag = repository.SaveLotRule(head);
                    if (!flag)
                        throw new Exception("新增批次规则失败！");
                }
                response.success = true;
                response.code = 200;
                response.msg = "操作成功";
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
            }
            return response;
        }
    }
}

using PigRunner.Entitys.BarCode;
using PigRunner.Public.Common.Views;
using PigRunner.Repository.Sys;
using PigRunner.Services.Sys.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Sys.Services
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
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionLotRule(LotRlueRequest request)
        {
            PubResponse response = new PubResponse();

            try
            {
                if (string.IsNullOrEmpty(request.RuleCode))
                    throw new Exception("规则编码不能为空！");
                
                if (request.OptType == 0)
                {
                    BCLotRule head = repository.GetBCLotRule(request.RuleCode);
                    if (head != null)
                        throw new Exception(string.Format("规则编码为【{0}】的批次规则已存在，不能再新增！", request.RuleCode));

                    if (request.BCLotRuleLines == null || request.BCLotRuleLines.Count <= 0)
                        throw new Exception("批次规则明细不能为空！");

                    head = BCLotRule.Create();
                    head.RuleCode = request.RuleCode;
                    head.RuleName = request.RuleName;

                    long OrgID = 0;
                    long.TryParse(request.Org, out OrgID);
                    head.Org = OrgID;

                    head.RuleDes = request.RuleDes;
                    head.Memo = request.Memo;

                   

                    List<BCLotRuleLine> lines = new List<BCLotRuleLine>();
                    //将单头ID赋值给明细
                    foreach (var item in request.BCLotRuleLines)
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

using Newtonsoft.Json.Linq;
using PigRunner.Entitys.BarCode;
using PigRunner.Entitys.System;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Helpers;
using PigRunner.Repository.System;
using PigRunner.Services.System.IServices;

namespace PigRunner.Services.System.Services
{
    /// <summary>
    /// 批号服务
    /// </summary>
    public class LotMasterService : ILotMasterService
    {
        private LotMasterRepository lotMasterRepository;
        /// <summary>
        /// 新增批号服务
        /// </summary>
        /// <param name="_lotMasterRepository">批号仓库</param>
        public LotMasterService(LotMasterRepository _lotMasterRepository)
        {
            this.lotMasterRepository = _lotMasterRepository;
        }

        /// <summary>
        /// 批号服务
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PubResponse ActionLotMaster(LotMasterRequest request)
        {
            PubResponse response = new PubResponse();

            try
            {
                if (string.IsNullOrEmpty(request.LotCode))
                    throw new Exception("批号不能为空！");

                if (request.OptType == 0)
                {
                    BcLotMaster head = lotMasterRepository.GetFirst(q => q.LotCode == request.LotCode);
                    if (head == null)
                        head = BcLotMaster.Create();

                    long ItemMasterID = 0, OrgID = 0;
                    int AutoCodeID = 0;
                    long.TryParse(request.ItemMaster, out ItemMasterID);
                    long.TryParse(request.Org, out OrgID);
                    int.TryParse(request.AutoCode, out AutoCodeID);

                    head.LotCode = request.LotCode;
                    head.ItemMaster = ItemMasterID;
                    head.Org = OrgID;
                    head.EffectiveDate = request.EffectiveDate;
                    head.ValidDate = request.ValidDate;
                    head.InvalidDate = request.InvalidDate;
                    head.SrcDocNo = request.SrcDocNo;
                    head.AutoCode = AutoCodeID;
                    head.Memo = request.Memo;
                    response.id = head.ID;

                    bool isSuccess = lotMasterRepository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("批号操作失败！");

                }
                else if (request.OptType == 1)
                {
                    BcLotMaster head = lotMasterRepository.GetFirst(q => q.LotCode == request.LotCode);
                    if (head == null)
                        throw new Exception(string.Format("编码为【{0}】的批号不存在！", request.LotCode));

                    bool isSuccess = lotMasterRepository.Delete(head);
                    if (!isSuccess)
                        throw new Exception("批号删除失败！");

                }
                else if (request.OptType == 2)
                {
                    BcLotMaster head = lotMasterRepository.GetFirst(q => q.LotCode == request.LotCode);
                    if (head == null)
                        throw new Exception(string.Format("编码为【{0}】的批号不存在！", request.LotCode));
                    response.qryData = head;
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

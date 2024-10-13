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
        /// 新增批号服务
        /// </summary>
        /// <param name="LotCode"></param>
        /// <param name="ItemMaster"></param>
        /// <param name="Org"></param>
        /// <param name="EffectiveDate"></param>
        /// <param name="ValidDate"></param>
        /// <param name="InvalidDate"></param>
        /// <param name="SrcDocNo"></param>
        /// <param name="AutoCode"></param>
        /// <param name="Memo"></param>
        /// <returns></returns>
        public PubResponse ActionLotMaster(string LotCode, string ItemMaster, string Org, DateTime EffectiveDate, int ValidDate, DateTime InvalidDate, string SrcDocNo, string AutoCode, string Memo,int OptType)
        {
            PubResponse response = new PubResponse();

            try
            {
                if (string.IsNullOrEmpty(LotCode))
                    throw new Exception("批号不能为空！");

                if (OptType == 0)
                {
                    BcLotMaster head = lotMasterRepository.GetFirst(q => q.LotCode == LotCode);
                    if (head == null)
                        head = BcLotMaster.Create();

                    long ItemMasterID = 0, OrgID = 0;
                    int AutoCodeID = 0;
                    long.TryParse(ItemMaster, out ItemMasterID);
                    long.TryParse(Org, out OrgID);
                    int.TryParse(AutoCode, out AutoCodeID);

                    head.LotCode = LotCode;
                    head.ItemMaster = ItemMasterID;
                    head.Org = OrgID;
                    head.EffectiveDate = EffectiveDate;
                    head.ValidDate = ValidDate;
                    head.InvalidDate = InvalidDate;
                    head.SrcDocNo = SrcDocNo;
                    head.AutoCode = AutoCodeID;
                    head.Memo = Memo;
                    response.id = head.ID;

                    bool isSuccess = lotMasterRepository.InsertOrUpdate(head);
                    if (!isSuccess)
                        throw new Exception("批号操作失败！");

                }
                else if (OptType == 1)
                {
                    BcLotMaster head = lotMasterRepository.GetFirst(q => q.LotCode == LotCode);
                    if (head == null)
                        throw new Exception(string.Format("编码为【{0}】的批号不存在！",LotCode));

                    bool isSuccess = lotMasterRepository.Delete(head);
                    if (!isSuccess)
                        throw new Exception("批号删除失败！");

                }
                else if (OptType == 2)
                {
                    BcLotMaster head = lotMasterRepository.GetFirst(q => q.LotCode == LotCode);
                    if (head == null)
                        throw new Exception(string.Format("编码为【{0}】的批号不存在！", LotCode));
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

using PigRunner.Entitys.BarCode;
using PigRunner.Entitys.System;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Helpers;
using PigRunner.Repository.System;
using PigRunner.Services.System.IServices;

namespace PigRunner.Services.System.Services
{
    /// <summary>
    /// 登录服务
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
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public PubResponse InsertLotMaster(string LotCode, long ItemMaster, long Org, DateTime EffectiveDate, int ValidDate, DateTime InvalidDate, string SrcDocNo, long AutoCode, string Memo)
        {
            PubResponse response = new PubResponse();

            try
            {


                if (string.IsNullOrEmpty(LotCode))
                    throw new Exception("批号不能为空！");

                BcLotMaster oldHead = lotMasterRepository.GetBcLotMaster(LotCode);
                if (oldHead != null)
                    throw new Exception(string.Format("编码为【{0}】的批号已存在！", LotCode));

                BcLotMaster head = BcLotMaster.Create();
                head.LotCode = LotCode;
                head.ItemMaster = ItemMaster;
                head.Org = Org;
                head.EffectiveDate = EffectiveDate;
                head.ValidDate = ValidDate;
                head.InvalidDate = InvalidDate;
                head.SrcDocNo = SrcDocNo;
                head.AutoCode = AutoCode;
                head.Memo = Memo;

                bool isSuccess = lotMasterRepository.Insert(head);
                if (!isSuccess)
                    throw new Exception("批号创建失败！");

                //BcLotMaster newHead= GetFirst(user => user.UserName == username && user.Password == pwd && user.IsActive == 1);

                response.Success = true;
                response.Code = LotCode;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
       

    }
}

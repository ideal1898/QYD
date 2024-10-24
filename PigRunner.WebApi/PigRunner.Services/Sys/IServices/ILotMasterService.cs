using PigRunner.Entitys.Sys;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;

namespace PigRunner.Services.Sys.IServices
{
    public interface ILotMasterService : IScopedService
    {
        /// <summary>
        /// 批号服务
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PubResponse ActionLotMaster(LotMasterRequest request);

    }
}

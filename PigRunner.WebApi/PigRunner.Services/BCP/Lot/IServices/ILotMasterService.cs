using PigRunner.DTO.BCP.Lot;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.BCP.Lot.IServices
{
    public interface ILotMasterService : IScopedService
    {
        /// <summary>
        /// 批次主档
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PubResponse ActionLotMaster(LotMasterView request);


        PubResponse UploadLotMaster(MemoryStream file);
    }
}

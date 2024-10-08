using PigRunner.Entitys.BarCode;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Repository.System
{
     /// <summary>
     /// 批号存储库
     /// </summary>
    public class LotMasterRepository : BaseRepository<BcLotMaster>, IScopedService
    {
        
        /// <summary>
        /// 新增/修改批号
        /// </summary>
        /// <param name="BcLotMaster"></param>
        /// <returns></returns>
        public bool SaveLotMaster(BcLotMaster BcLotMaster)
        {
            return InsertOrUpdate(BcLotMaster);
        }

        /// <summary>
        /// 获取批号信息
        /// </summary>
        /// <param name="LotCode"></param>
        /// <returns></returns>
        public BcLotMaster GetBcLotMaster(string LotCode)
        {

            return GetFirst(q => q.LotCode == LotCode);
        }

        public bool DelLotMaster(BcLotMaster BcLotMaster)
        {
            return Delete(BcLotMaster);
        }
    }
}

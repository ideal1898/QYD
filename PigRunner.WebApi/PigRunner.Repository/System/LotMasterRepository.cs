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
    }
}

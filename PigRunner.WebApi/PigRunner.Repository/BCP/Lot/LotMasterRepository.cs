using PigRunner.Entitys.BCP.Lot;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Repository.BCP.Lot
{
    /// <summary>
    /// 批号存储库
    /// </summary>
    public class LotMasterRepository : BaseRepository<LotMaster>, IScopedService
    {
    }
}

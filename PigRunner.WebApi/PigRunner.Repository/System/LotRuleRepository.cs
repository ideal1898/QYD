using PigRunner.Entitys.BarCode;
using PigRunner.Public.Interface;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PigRunner.Repository.System
{
    public class LotRuleRepository : BaseRepository<BCLotRule>, IScopedService
    {



        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="BCLotRule"></param>
        /// <returns></returns>
        public bool SaveLotRule(BCLotRule BCLotRule)
        {
            return Context.InsertNav(BCLotRule).Include(s => s.BCLotRuleLines).ExecuteCommand();
        }

        /// <summary>
        /// 获取批号信息
        /// </summary>
        /// <param name="LotCode"></param>
        /// <returns></returns>
        public BCLotRule GetBCLotRule(string LotCode)
        {

            return GetFirst(q => q.RuleCode == LotCode);
        }

        public bool DelLotMaster(BCLotRule BCLotRule)
        {
            return Delete(BCLotRule);
        }

    }
}

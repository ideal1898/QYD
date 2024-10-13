using PigRunner.Entitys.System;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;

namespace PigRunner.Services.System.IServices
{
    public interface ILotMasterService : IScopedService
    {
        /// <summary>
        /// 新增批号
        /// </summary>
        /// <param name="LotCode">批号编码</param>
        /// <param name="ItemMaster">料品ID</param>
        /// <param name="Org">组织ID</param>
        /// <param name="EffectiveDate">生效时间</param>
        /// <param name="ValidDate">生效天数</param>
        /// <param name="InvalidDate">失效日期</param>
        /// <param name="SrcDocNo">来源单号</param>
        /// <param name="AutoCode">自动编码</param>
        /// <param name="Memo">备注</param>
        /// <param name="OptType">操作类型</param>
        /// <returns></returns>
        PubResponse ActionLotMaster(string LotCode, string ItemMaster, string Org,DateTime EffectiveDate,int ValidDate,DateTime InvalidDate,string SrcDocNo, string AutoCode,string Memo,int OptType);

    }
}

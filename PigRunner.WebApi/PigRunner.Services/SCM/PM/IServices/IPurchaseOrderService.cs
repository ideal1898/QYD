using PigRunner.DTO.SCM.PM;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.SCM.PM.IServices
{
    public interface IPurchaseOrderService: IScopedService
    {
        #region 业务处理
        /// <summary>
        /// 采购订单
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        ResponseBusBody Save(PurchaseOrderView view);
        /// <summary>
        /// 删除采购订单
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        ResponseBusBody Delete(List<long> ids);
        #endregion
        #region 查询
        /// <summary>
        /// 分页查询采购订单
        /// </summary>
        /// <param name="Where">查询条件</param>
        /// <param name="PageSize">每页大小</param>
        /// <param name="Current">当前页面</param>
        /// <param name="Total">总数量</param>
        /// <returns></returns>
        ResponseBody QueryAllByPage(string Where,int PageSize, int Current, ref int Total);
        /// <summary>
        /// 根据ID查询采购订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseBusBody QueryItemById(long id);
        #endregion
    }
}

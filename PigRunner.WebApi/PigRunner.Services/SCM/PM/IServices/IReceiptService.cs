﻿using PigRunner.DTO.CommonView;
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
    /// <summary>
    /// 采购入库单
    /// </summary>
    public interface IReceiptService:IScopedService
    {
        #region 业务处理
        /// <summary>
        /// 采购入库单
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        ResponseBusBody Save(ReceiptView view);
        /// <summary>
        /// 删除采购入库单
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        ResponseBusBody Delete(List<long> ids);

        ResponseBusBody Submit(ReceiptView view);
        ResponseBusBody Approve(ReceiptView view);
        ResponseBusBody UnApprove(ReceiptView view);

        ResponseBody BatchSubmit(List<DoActionView> views);
        ResponseBody BatchApprove(List<DoActionView> views);
        ResponseBody BatchUnApprove(List<DoActionView> views);

        #endregion
        #region 查询
        /// <summary>
        /// 分页查询采购入库单
        /// </summary>
        /// <param name="Where">查询条件</param>
        /// <param name="PageSize">每页大小</param>
        /// <param name="Current">当前页面</param>
        /// <param name="Total">总数量</param>
        /// <returns></returns>
        ResponseBody QueryAllByPage(PageView view);
        /// <summary>
        /// 根据ID查询采购入库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseBusBody QueryDocById(long id);
        /// <summary>
        /// 根据单据编号查询采购入库单
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        ResponseBusBody QueryDocByDocNo(string DocNo);
        #endregion
    }
}

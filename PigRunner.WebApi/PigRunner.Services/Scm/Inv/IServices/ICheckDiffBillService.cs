using PigRunner.DTO.SCM.INV;
using PigRunner.Public.Common.Views;
using PigRunner.DTO.CommonView;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.SCM.INV.IServices
{
    /// <summary>
    /// 差异核对单接口
    /// </summary>
    public interface ICheckDiffBillService : IScopedService
    {
        #region 业务处理
        /// <summary>
        /// 新增差异核对单
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        ResponseBusBody Save(CheckDiffBillView view);

        /// <summary>
        /// 删除差异核对单
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        ResponseBusBody Delete(List<long> ids);

        /// <summary>
        /// 提交差异核对单
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        ResponseBusBody Submit(CheckDiffBillView view);

        /// <summary>
        /// 审批差异核对单
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        ResponseBusBody Approve(CheckDiffBillView view);

        /// <summary>
        /// 反审批差异核对单
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        ResponseBusBody UnApprove(CheckDiffBillView view);

        /// <summary>
        /// 批量提交差异核对单
        /// </summary>
        /// <param name="views"></param>
        /// <returns></returns>
        ResponseBody BatchSubmit(List<DoActionView> views);

        /// <summary>
        /// 批量审批差异核对单
        /// </summary>
        /// <param name="views"></param>
        /// <returns></returns>
        ResponseBody BatchApprove(List<DoActionView> views);

        /// <summary>
        /// 批量反审批差异核对单
        /// </summary>
        /// <param name="views"></param>
        /// <returns></returns>
        ResponseBody BatchUnApprove(List<DoActionView> views);

        #endregion

        #region 查询
        /// <summary>
        /// 分页查询差异核对单
        /// </summary>
        /// <param name="Where">查询条件</param>
        /// <param name="PageSize">每页大小</param>
        /// <param name="Current">当前页面</param>
        /// <param name="Total">总数量</param>
        /// <returns></returns>
        ResponseBody QueryAllByPage(PageView view);

        /// <summary>
        /// 根据ID查询差异核对单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseBusBody QueryDocById(long id);

        /// <summary>
        /// 根据单据编号查询差异核对单
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        ResponseBusBody QueryDocByDocNo(string DocNo);

        /// <summary>
        /// 分页查询明细
        /// </summary>
        /// <param name="Where">查询条件</param>
        /// <param name="PageSize">每页大小</param>
        /// <param name="Current">当前页面</param>
        /// <param name="Total">总数量</param>
        /// <returns></returns>
        ResponseBody queryLineByPage(PageView view);
        #endregion
    }
}
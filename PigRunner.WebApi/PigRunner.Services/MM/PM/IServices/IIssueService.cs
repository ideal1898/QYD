using PigRunner.DTO.CommonView;
using PigRunner.DTO.MM.PM;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.MM.PM.IServices
{
    public interface IIssueService : IScopedService
    {
        #region 业务处理
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        ResponseBusBody Save(IssueView view);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        ResponseBusBody Delete(List<long> ids);

        ResponseBusBody Submit(IssueView view);
        ResponseBusBody Approve(IssueView view);
        ResponseBusBody UnApprove(IssueView view);

        ResponseBody BatchSubmit(List<DoActionView> views);
        ResponseBody BatchApprove(List<DoActionView> views);
        ResponseBody BatchUnApprove(List<DoActionView> views);

        /// <summary>
        /// 生产转领料
        /// </summary>
        /// <param name="views"></param>
        /// <returns></returns>
        ResponseBody MOToIssue(List<MOToIssueView> views);

        #endregion

        #region 查询
        /// <summary>
        /// 分页查询领料单
        /// </summary>
        /// <param name="Where">查询条件</param>
        /// <param name="PageSize">每页大小</param>
        /// <param name="Current">当前页面</param>
        /// <param name="Total">总数量</param>
        /// <returns></returns>
        ResponseBody QueryAllByPage(PageView view);
        /// <summary>
        /// 根据ID查询领料单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseBusBody QueryDocById(long id);
        /// <summary>
        /// 根据单据编号查询领料单
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        ResponseBusBody QueryDocByDocNo(string DocNo);
        #endregion
    }
}

using PigRunner.DTO.Scm.Inv;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Scm.Inv.IServices
{

    public interface ICheckDiffBillLineService : IScopedService
    {

        #region 新增
        bool InsertCheckDiffBillLine(CheckDiffBillLineView view);

        #endregion

        #region 查询
        ResponseBody QueryCheckDiffBillLine(int current, int size);
        #endregion

    }

}
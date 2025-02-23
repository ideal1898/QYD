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

    public interface ITransferLineService : IScopedService
    {

        #region 新增
        bool InsertTransferLine(TransferLineView view);

        #endregion

        #region 查询
        ResponseBody QueryTransferLine(int current, int size);
        #endregion
    }

}
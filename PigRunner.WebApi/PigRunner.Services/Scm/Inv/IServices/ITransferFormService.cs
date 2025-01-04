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

    public interface ITransferFormService : IScopedService
    {

        #region 新增
        bool InsertTransferForm(TransferFormView view);

        #endregion

        #region 查询
        ResponseBody QueryTransferForm(int current, int size);
        #endregion
    }

}
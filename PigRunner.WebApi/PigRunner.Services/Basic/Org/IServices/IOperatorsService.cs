using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Basic.IServices
{

    public interface IOperatorsService : IScopedService
    {
        
        /// <summary>
        /// 备  注:业务员
        ///</summary>
        /// <param name=request></param>
        /// <returns></returns>
        
        PubResponse ActionOperators(OperatorsVo request);

    }
    
}
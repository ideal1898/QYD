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

    public interface IWhService : IScopedService
    {
        
        /// <summary>
        /// 备  注:仓库
        ///</summary>
        /// <param name=request></param>
        /// <returns></returns>
        
        PubResponse ActionWh(WhVo request);

    }
    
}
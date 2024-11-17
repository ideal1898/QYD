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

    public interface IWhBinService : IScopedService
    {
        
        /// <summary>
        /// 备  注:库位
        ///</summary>
        /// <param name=request></param>
        /// <returns></returns>
        
        PubResponse ActionWhBin(WhBinVo request);

    }
    
}
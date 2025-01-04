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

    public interface IWhShService : IScopedService
    {
        
        /// <summary>
        /// 货位
        ///</summary>
        /// <param name=request></param>
        /// <returns></returns>
        
        PubResponse ActionWhSh(WhShView request);

        /// <summary>
        /// 导入货位
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        PubResponse UploadWhSh(MemoryStream file);

    }
    
}
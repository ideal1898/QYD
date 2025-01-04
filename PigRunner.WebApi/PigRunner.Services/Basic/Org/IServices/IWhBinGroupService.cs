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

    public interface IWhBinGroupService : IScopedService
    {
        
        /// <summary>
        /// 备  注:库区
        ///</summary>
        /// <param name=request></param>
        /// <returns></returns>
        
        PubResponse ActionWhBinGroup(WhBinGroupView request);



        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        PubResponse UploadWhBinGroup(MemoryStream file);
    }
    
}
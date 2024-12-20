using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;

namespace PigRunner.Services.Basic.IServices
{

    public interface IDepartmentService : IScopedService
    {
        
        /// <summary>
        /// 备  注:部门
        ///</summary>
        /// <param name=request></param>
        /// <returns></returns>
        
        PubResponse ActionDepartment(DepartmentView request);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        PubResponse UploadDepartment(MemoryStream file);
    }
    
}
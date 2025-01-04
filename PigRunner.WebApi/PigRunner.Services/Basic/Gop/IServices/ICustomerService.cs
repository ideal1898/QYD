using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;

namespace PigRunner.Services.Basic.Gop.IServices
{
    public interface ICustomerService : IScopedService
    {
        /// <summary>
        /// 客户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PubResponse ActionCustomer(CustomerView request);

        /// <summary>
        /// 导入客户
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        PubResponse UploadCustomer(MemoryStream file);
    }
}

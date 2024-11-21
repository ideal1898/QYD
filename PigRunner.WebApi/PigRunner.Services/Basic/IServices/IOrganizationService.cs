using PigRunner.DTO.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;

namespace PigRunner.Services.Basic.IServices
{
   public interface IOrganizationService : IScopedService
    {
        /// <summary>
        /// 组织
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PubResponse ActionOrganization(OrganizationView request);
    }
}

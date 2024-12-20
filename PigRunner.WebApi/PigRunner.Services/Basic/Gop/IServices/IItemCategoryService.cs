using PigRunner.DTO.Basic.Gop;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;

namespace PigRunner.Services.Basic.Gop.IServices
{
   public interface IItemCategoryService : IScopedService
    {
        /// <summary>
        /// 物料分类
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PubResponse ActionItemCategory(ItemCategoryView request);


        PubResponse UploadItemCategory(MemoryStream file);
    }
}

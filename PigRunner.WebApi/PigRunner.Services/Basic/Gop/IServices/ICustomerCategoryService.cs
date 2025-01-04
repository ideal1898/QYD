using PigRunner.DTO.Basic.Gop;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Basic.Gop.IServices
{
    public interface ICustomerCategoryService : IScopedService
    {
        /// <summary>
        /// 客户分类
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PubResponse ActionCustomerCategory(CustomerCategoryView request);


        PubResponse UploadCustomerCategory(MemoryStream file);
    }
}

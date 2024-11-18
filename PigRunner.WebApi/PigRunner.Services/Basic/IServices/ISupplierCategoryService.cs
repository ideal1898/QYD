
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Services.Basic.IServices
 * 唯一标识：ab88b68d-ea28-453f-96f2-e52f9eb68592
 * 文件名：ISupplierCategoryService
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/11/17 10:36:18
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>


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
    public interface ISupplierCategoryService:IScopedService
    {
        #region 新增
        bool InsertSupplierCategory(SupplierCategoryView view);

        #endregion

        #region 查询
        ResponseBody GetAllSupplierCategories(int current,int size);

        #endregion
    }
}

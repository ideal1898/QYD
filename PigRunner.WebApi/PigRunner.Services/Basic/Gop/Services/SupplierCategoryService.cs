
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Services.Basic.Services
 * 唯一标识：0ca131f5-2ddb-4b5c-9ce6-2136ba9f5fe6
 * 文件名：SupplierCategoryService
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/11/17 10:44:53
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


using AutoMapper;
using Newtonsoft.Json.Linq;
using PigRunner.DTO.Basic;
using PigRunner.Entitys.Basic;
using PigRunner.Public.Common.Views;
using PigRunner.Public.Helpers;
using PigRunner.Repository.Basic;
using PigRunner.Services.Basic.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Basic.Services
{
    public class SupplierCategoryService : ISupplierCategoryService
    {
        private readonly IMapper mapper;
        private SupplierCategoryRepository SupplierCategoryRepository;
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="_mapper"></param>
        /// <param name="_SupplierCategoryRepository"></param>
        public SupplierCategoryService(IMapper _mapper, SupplierCategoryRepository _SupplierCategoryRepository)
        {
            this.mapper = _mapper;
            this.SupplierCategoryRepository = _SupplierCategoryRepository;
        }

        public ResponseBody GetAllSupplierCategories(int current, int size)
        {
            ResponseBody body = new ResponseBody();

           // List<SupplierCategoryView> list = new List<SupplierCategoryView>();
            int total = 0;
            //SupplierCategoryRepository.AsQueryable().ToPageList(current, size, ref total).ForEach(item =>
            //{
            //    var view = mapper.Map<SupplierCategoryView>(item);
            //    list.Add(view);
            //});
            List<SupplierCategory> supplierCategories= SupplierCategoryRepository.AsQueryable().ToOffsetPage(current, size, ref total);
            SupplierCategoryView[] list = mapper.Map<SupplierCategoryView[]>(supplierCategories);
            body.total = total;
            body.code = 200;
            body.msg = "OK";
            body.data = JArray.FromObject(list);
            return body;
        }
        public bool InsertSupplierCategory(SupplierCategoryView view)
        {
            SupplierCategory supplierCategory = mapper.Map<SupplierCategory>(view);
            supplierCategory.ID = IdGeneratorHelper.GetNextId();
            return SupplierCategoryRepository.Insert(supplierCategory);
        }
    }
}

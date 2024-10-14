
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Services.Basic.Services
 * 唯一标识：a76ff77b-8b71-4774-913e-4aa5ae4c3b65
 * 文件名：ItemService
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/10/13 13:46:50
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
using PigRunner.Entitys.Basic;
using PigRunner.Repository.Basic;
using PigRunner.Services.Basic.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Basic.Services
{
    public class ItemService : IItemService
    {
        private ItemRepository repository;
        public ItemService(ItemRepository _repository) { 
        this.repository= _repository;
        }
        public bool Add(ItemVo vo)
        {
            Item item = Item.Create();
            item.Code = vo.Code;
            item.Name = vo.Name;
           
            return repository.Add(item);
        }

        public ItemVo Update(ItemVo vo)
        {
           var itemE= repository.GetFirst(item => item.Code == vo.Code);
            itemE.Name = vo.Name;

            repository.Update(itemE);
            return vo;
        }
    }
}


#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Repository.Basic
 * 唯一标识：46c708fc-0b12-4b8f-ba3c-602e168f56ef
 * 文件名：ItemRepository
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/10/13 13:38:24
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


using PigRunner.Entitys.Basic;
using PigRunner.Entitys.Sys;
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Repository.Basic
{
    public class ItemRepository : BaseRepository<Item>, IScopedService
    {
        /// <summary>
        /// 新增料品
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Add(Item item) {
            return Insert(item);    
        }

        public void casedate<Item>(Item item) {
            BeginTran();
            ///

            CommitTran();


        }
    }
}

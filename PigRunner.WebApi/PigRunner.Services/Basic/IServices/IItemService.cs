
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Services.Basic.IServices
 * 唯一标识：d18a0cc6-19cb-4823-8ade-04305dad9301
 * 文件名：IItemService
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/10/13 13:41:31
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
using PigRunner.Public.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Services.Basic.IServices
{
     public interface IItemService : IScopedService
    {
       bool Add(ItemVo vo);
        ItemVo Update(ItemVo vo);
    }
}

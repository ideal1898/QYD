
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Entitys.Basic
 * 唯一标识：ad491bcd-cffb-4595-b1b0-a2fd1b334e81
 * 文件名：Item
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/10/13 13:35:40
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


using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Entitys.Basic
{
    [SqlSugar.SugarTable("QYD_Basic_Item")]
    public class Item:BaseEntity<Item>
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; }=string.Empty;
    }
}


#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.DTO.Basic
 * 唯一标识：1f417ad6-9534-474a-96cb-640ebda52d3f
 * 文件名：SupplierCategoryVo
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/11/17 10:38:58
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


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PigRunner.DTO.Basic
{
    public class SupplierCategoryView
    {
        [JsonProperty("id")]
        public long ID { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreatedTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string? CreatedBy { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public long SysVersion { get; set; } = 0;
        public int? IsEffective { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public long? ParentNode { get; set; }
    }
}

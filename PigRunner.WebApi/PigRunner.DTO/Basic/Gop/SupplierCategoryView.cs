
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
using PigRunner.DTO.Basic.Pub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PigRunner.DTO.Basic
{
    /// <summary>
    /// 供应商分类
    /// </summary>
    public class SupplierCategoryView : PubView
    {
        /// <summary>
        /// 上级分类编码
        /// </summary>
        public string ParentCode { get; set; } = string.Empty;

        /// <summary>
        /// 上级分类名称
        /// </summary>
        public string ParentName { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = string.Empty;

        /// <summary>
        /// 是否生效
        /// </summary>
        public bool IsEffective { get; set; } = false;

        /// <summary>
        /// 生效名称
        /// </summary>
        public string Effective { get; set; } = string.Empty;
    }
}

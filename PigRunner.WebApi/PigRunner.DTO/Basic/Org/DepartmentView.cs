﻿using PigRunner.DTO.Basic.Pub;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PigRunner.DTO.Basic
{
    /// <summary>
    /// 部门
    /// </summary>
    public class DepartmentView : PubView
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
        public string IsEffective { get; set; } = string.Empty;

        /// <summary>
        /// 生效名称
        /// </summary>
        public string Effective { get; set; } = string.Empty;
    }
    
}
﻿using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 供应商分类
    ///</summary>
    [SugarTable("QYD_Basic_SupplierCategory")]
    public class SupplierCategory : BaseEntity<SupplierCategory>
    {

        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "IsEffective")]
        public int IsEffective { get; set; } = 0;
        
         
        
        /// <summary>
        /// 备  注:供应商分类编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string Code  { get; set;  }=string.Empty;
        
         
        
        /// <summary>
        /// 备  注:供应商分类名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string Name  { get; set;  } = string.Empty;

        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "Remark")]
        public string Remark { get; set; } = string.Empty;


        /// <summary>
        /// 备  注:供应商上级分类ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ParentNode" ) ]
        public long ParentNode  { get; set;  } = 0;

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifiedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifiedBy { get; set; } = string.Empty;

    }
    
}
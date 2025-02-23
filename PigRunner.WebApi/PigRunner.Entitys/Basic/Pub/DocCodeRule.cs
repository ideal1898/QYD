﻿using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 单据编码规则
    ///</summary>
    [SugarTable("QYD_Basic_DocCodeRule")]
    public class DocCodeRule : BaseEntity<DocCodeRule>
    {
        
         
         
         
         
         
         
        
        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsEffective" ) ]
        public int? IsEffective  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string? Code  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string? Name  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:编码规则
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="RuleText" ) ]
        public string? RuleText  { get; set;  } 
        
         
        

    }
    
}
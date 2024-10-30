using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 档案编码规则
    ///</summary>
    [SugarTable("QYD_Basic_ArchiveCodeRule")]
    public class ArchiveCodeRule : BaseEntity<ArchiveCodeRule>
    {
        
         
         
         
         
         
         
        
        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsEffective" ) ]
        public int? IsEffective  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:档案规则编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string? Code  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:档案规则名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string? Name  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:组织ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Org" ) ]
        public long? Org  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:档案编码规则
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="CodeRule" ) ]
        public string? CodeRule  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:所属档案
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="EnTity" ) ]
        public string? EnTity  { get; set;  } 
        
         
        

    }
    
}
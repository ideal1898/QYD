using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 部门
    ///</summary>
    [SugarTable("QYD_Basic_Department")]
    public class Department : BaseEntity<Department>
    {
        
         
         
        
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
        /// 备  注:生效
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsEffective" ) ]
        public bool? IsEffective  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="remark" ) ]
        public string? Remark  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:上级部门
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ParentNode" ) ]
        public long? ParentNode  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:部门分类
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="depclass" ) ]
        public string? Depclass  { get; set;  } 
        
         
         
         
        

    }
    
}
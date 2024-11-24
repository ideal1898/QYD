using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 料品分类
    ///</summary>
    [SugarTable("QYD_Basic_ItemCategory")]
    public class ItemCategory : BaseEntity<ItemCategory>
    {
        
         
         
         
         
         
         
         
        
        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsEffective" ) ]
        public int? IsEffective  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:分类编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string? Code  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:分类名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string? Name  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:上级分类
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ParentNode" ) ]
        public long? ParentNode  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:顶层分类
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="TopNode" ) ]
        public long? TopNode  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Remark" ) ]
        public string? Remark  { get; set;  } 
        
        

    }
    
}
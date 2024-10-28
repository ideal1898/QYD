using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 库区
    ///</summary>
    [SugarTable("QYD_Basic_WhBinGroup")]
    public class WhBinGroup : BaseEntity<WhBinGroup>
    {
        
         
         
        
        /// <summary>
        /// 备  注:库区编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string? Code  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:库区名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string? Name  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:仓库
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="wh" ) ]
        public long? Wh  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:组织
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="org" ) ]
        public long? Org  { get; set;  } 
        
         
         
         
         
         
        
        /// <summary>
        /// 备  注:面积
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="area" ) ]
        public string? Area  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:体积
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="volume" ) ]
        public string? Volume  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="remark" ) ]
        public string? Remark  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:有效性
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsEffective" ) ]
        public int? IsEffective  { get; set;  } 
        
         
        

    }
    
}
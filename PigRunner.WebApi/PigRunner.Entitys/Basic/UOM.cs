using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 计量单位
    ///</summary>
    [SugarTable("QYD_Basic_UOM")]
    public class UOM : BaseEntity<UOM>
    {
        
     
     
     
     
         
     
     
        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsEffective" ) ]
        public int? IsEffective  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:计量单位编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string? Code  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:计量单位名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string? Name  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:是否基准单位
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsBase" ) ]
        public int? IsBase  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:副单位
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="BaseUOM" ) ]
        public string? BaseUOM  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:主副单位转换系数
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="RatioToBase" ) ]
        public decimal? RatioToBase  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:计量单位组
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="UOMGroup" ) ]
        public string? UOMGroup  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Remark" ) ]
        public string? Remark  { get; set;  } 
    

        

    }
    
}
using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 税率
    ///</summary>
    [SugarTable("QYD_Basic_TaxSchedule")]
    public class TaxSchedule : BaseEntity<TaxSchedule>
    {
        
         
         
         
         
         
         
        
        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsEffective" ) ]
        public int? IsEffective  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:税率编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string? Code  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:税率名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string? Name  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:税率
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Tax" ) ]
        public decimal? Tax  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:税率类型
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="TaxType" ) ]
        public int? TaxType  { get; set;  } 
        
         
        

    }
    
}
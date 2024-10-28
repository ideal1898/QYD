using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 业务员
    ///</summary>
    [SugarTable("QYD_Basic_Operators")]
    public class Operators : BaseEntity<Operators>
    {
        
     
        /// <summary>
        /// 备  注:业务员ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ID" ,IsPrimaryKey = true,IsIdentity = true) ]
        public long ID  { get; set;  } 
     
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string? Code  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string? Name  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Dept" ) ]
        public long? Dept  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:是否采购员
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsPurer" ) ]
        public int? IsPurer  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:是否销售人员
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsSaler" ) ]
        public int? IsSaler  { get; set;  } 
        
         
     
        /// <summary>
        /// 备  注:是否计划人员
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsPlaner" ) ]
        public int? IsPlaner  { get; set;  } 
        
         
     
        /// <summary>
        /// 备  注:是否生产人员
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsMoer" ) ]
        public int? IsMoer  { get; set;  } 
        
         
     
        /// <summary>
        /// 备  注:是否库存管理员
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsInver" ) ]
        public int? IsInver  { get; set;  } 
        
         
         
         
         
         
    

    }
    
}
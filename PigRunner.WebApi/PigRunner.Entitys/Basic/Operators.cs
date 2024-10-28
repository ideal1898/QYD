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
    public class Operators
    {
        
     
        /// <summary>
        /// 备  注:业务员ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ID" ,IsPrimaryKey = true,IsIdentity = true) ]
        public long ID  { get; set;  } 
     
        /// <summary>
        /// 备  注:业务员编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string? Code  { get; set;  } 
     
        /// <summary>
        /// 备  注:业务员名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string? Name  { get; set;  } 
     
        /// <summary>
        /// 备  注:部门ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Dept" ) ]
        public long? Dept  { get; set;  } 
     
        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsEffective" ) ]
        public int? IsEffective  { get; set;  } 
     
        /// <summary>
        /// 备  注:采购员
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="OptTypePurer" ) ]
        public int? OptTypePurer  { get; set;  } 
     
        /// <summary>
        /// 备  注:销售业务员
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="OptTypeSaler" ) ]
        public int? OptTypeSaler  { get; set;  } 
     
        /// <summary>
        /// 备  注:库管员
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="OptTypeDepot" ) ]
        public int? OptTypeDepot  { get; set;  } 
    

    }
    
}
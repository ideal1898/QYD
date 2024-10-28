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
    public class DocCodeRule
    {
        
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ID" ,IsPrimaryKey = true,IsIdentity = true) ]
        public long ID  { get; set;  } 
     
        /// <summary>
        /// 备  注:创建人
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="CreatedBy" ) ]
        public string? CreatedBy  { get; set;  } 
     
        /// <summary>
        /// 备  注:创建时间
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="CreatedOn" ) ]
        public DateTime? CreatedOn  { get; set;  } 
     
        /// <summary>
        /// 备  注:修改人
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ModifiedBy" ) ]
        public string? ModifiedBy  { get; set;  } 
     
        /// <summary>
        /// 备  注:修改时间
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ModifiedOn" ) ]
        public DateTime? ModifiedOn  { get; set;  } 
     
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
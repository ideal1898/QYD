using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 单据类型
    ///</summary>
    [SugarTable("QYD_Basic_DocType")]
    public class DocType : BaseEntity<DocType>
    {
        
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ID" ,IsPrimaryKey = true,IsIdentity = true) ]
        public long ID  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="CreatedBy" ) ]
        public string? CreatedBy  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="CreatedOn" ) ]
        public DateTime? CreatedOn  { get; set;  } 
     
         
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ModifiedOn" ) ]
        public DateTime? ModifiedOn  { get; set;  } 
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsEffective" ) ]
        public int? IsEffective  { get; set;  } 
     
         
        
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
        /// 备  注:收发规则_收
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="RuleRcv" ) ]
        public int? RuleRcv  { get; set;  } 
        
         
     
        /// <summary>
        /// 备  注:收发规则_发
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="RuleShip" ) ]
        public int? RuleShip  { get; set;  } 
        
         
     
        /// <summary>
        /// 备  注:编码规则
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="DocCodeRule" ) ]
        public long? DocCodeRule  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:自动编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsAutoCode" ) ]
        public int? IsAutoCode  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:是否启用审批流
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsApprovalProcess" ) ]
        public int? IsApprovalProcess  { get; set;  } 
    

        

    }
    
}
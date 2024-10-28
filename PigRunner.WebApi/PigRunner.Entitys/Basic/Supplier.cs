using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 供应商主表
    ///</summary>
    [SugarTable("QYD_Basic_Supplier")]
    public class Supplier : BaseEntity<Supplier>
    {
        
     
     
     
     
     
         
     
        /// <summary>
        /// 备  注:供应商编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string? Code  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:供应商名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string? Name  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:供应商分类ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Category" ) ]
        public long? Category  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:税号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="TaxNo" ) ]
        public string? TaxNo  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:税率
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="TaxData" ) ]
        public decimal? TaxData  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:立账条件名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="APConfirmTermName" ) ]
        public string? APConfirmTermName  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:供应商简称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ShortName" ) ]
        public string? ShortName  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:微信公众号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="WeChat" ) ]
        public string? WeChat  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:状态
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Stauts" ) ]
        public string? Stauts  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:上级供应商
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ParentNodeSup" ) ]
        public long? ParentNodeSup  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:是否内部组织
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsOrg" ) ]
        public int? IsOrg  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:收货人电话
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="RcvTel" ) ]
        public string? RcvTel  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:收货规则
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="RcvRule" ) ]
        public string? RcvRule  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:采购员ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Purchaser" ) ]
        public long? Purchaser  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:地区ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Province" ) ]
        public long? Province  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:付款条件名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="PayRuleName" ) ]
        public string? PayRuleName  { get; set;  } 
    

        

    }
    
}
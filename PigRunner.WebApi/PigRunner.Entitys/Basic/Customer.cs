using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 客户主表
    ///</summary>
    [SugarTable("QYD_Basic_Customer")]
    public class Customer : BaseEntity<Customer>
    {
        
         
         
         
         
         
         
        
        /// <summary>
        /// 备  注:客户编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string? Code  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:客户名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string? Name  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:客户简称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ShortName" ) ]
        public string? ShortName  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:立账条件名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ARConfirmTermName" ) ]
        public string? ARConfirmTermName  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:税率数值
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="TaxData" ) ]
        public decimal? TaxData  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:业务员ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Saleser" ) ]
        public long? Saleser  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:部门ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Department" ) ]
        public long? Department  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:税号
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="TaxNo" ) ]
        public string? TaxNo  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:客户分类ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Category" ) ]
        public long? Category  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:组织ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Org" ) ]
        public byte? Org  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:省/自治区ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Province" ) ]
        public long? Province  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:收货地址
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="RcvAddress" ) ]
        public string? RcvAddress  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:收货电话
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="RcvTel" ) ]
        public string? RcvTel  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:上级客户ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ParentNodeCus" ) ]
        public long? ParentNodeCus  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:是否内部组织
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsOrg" ) ]
        public int? IsOrg  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:客户状态
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Status" ) ]
        public string? Status  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:出货原则
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ShipRule" ) ]
        public string? ShipRule  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:收款条件名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="RcvPayRule" ) ]
        public string? RcvPayRule  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:供应商ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Supplier" ) ]
        public long? Supplier  { get; set;  } 
        
         
        

    }
    
}
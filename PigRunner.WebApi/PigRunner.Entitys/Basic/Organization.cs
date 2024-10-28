using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 组织
    ///</summary>
    [SugarTable("QYD_Base_Organization")]
    public class Organization : BaseEntity<Organization>
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
        public string? CreatedOn  { get; set;  } 
     
         
     
        /// <summary>
        /// 备  注:修改时间
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ModifiedOn" ) ]
        public string? ModifiedOn  { get; set;  } 
     
        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsEffective" ) ]
        public int? IsEffective  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:组织编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string? Code  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:组织名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string? Name  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:默认语言
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="DefaultLanguage" ) ]
        public int? DefaultLanguage  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:办公地址
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Location" ) ]
        public string? Location  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:注册地址
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="RegisterAddress" ) ]
        public string? RegisterAddress  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:社会统一信用代码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="CCBL" ) ]
        public string? CCBL  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:联系人
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Contacts" ) ]
        public string? Contacts  { get; set;  } 
     
         
        
        /// <summary>
        /// 备  注:组织简称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Shortname" ) ]
        public string? Shortname  { get; set;  } 
    

        

    }
    
}
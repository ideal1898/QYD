using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 仓库
    ///</summary>
    [SugarTable("QYD_Basic_Wh")]
    public class Warehouse
    {
        
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ID" ,IsPrimaryKey = true,IsIdentity = true) ]
        public long ID  { get; set;  } 
     
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
        /// 备  注:组织
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Org" ) ]
        public long? Org  { get; set;  } 
     
        /// <summary>
        /// 备  注:是否库位
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsStoreBin" ) ]
        public int? IsStoreBin  { get; set;  } 
     
        /// <summary>
        /// 备  注:面积
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Area" ) ]
        public decimal? Area  { get; set;  } 
     
        /// <summary>
        /// 备  注:容积
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Volume" ) ]
        public decimal? Volume  { get; set;  } 
     
        /// <summary>
        /// 备  注:供应商
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Supplier" ) ]
        public long? Supplier  { get; set;  } 
     
        /// <summary>
        /// 备  注:客户
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Customer" ) ]
        public long? Customer  { get; set;  } 
     
        /// <summary>
        /// 备  注:地址
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Address" ) ]
        public string? Address  { get; set;  } 
     
        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Remark" ) ]
        public string? Remark  { get; set;  } 
     
        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsEffective" ) ]
        public int? IsEffective  { get; set;  } 
     
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
    

    }
    
}
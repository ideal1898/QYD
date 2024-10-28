using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 库区
    ///</summary>
    [SugarTable("QYD_Basic_WhBinGroup")]
    public class WarehouseBinGroup
    {
        
     
        /// <summary>
        /// 备  注:
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ID" ,IsPrimaryKey = true,IsIdentity = true) ]
        public long ID  { get; set;  } 
     
        /// <summary>
        /// 备  注:库区编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string? Code  { get; set;  } 
     
        /// <summary>
        /// 备  注:库区名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string? Name  { get; set;  } 
     
        /// <summary>
        /// 备  注:仓库
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="wh" ) ]
        public long? wh  { get; set;  } 
     
        /// <summary>
        /// 备  注:组织
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="org" ) ]
        public long? org  { get; set;  } 
     
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
        /// 备  注:面积
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="area" ) ]
        public string? area  { get; set;  } 
     
        /// <summary>
        /// 备  注:体积
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="volume" ) ]
        public string? volume  { get; set;  } 
     
        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="remark" ) ]
        public string? remark  { get; set;  } 
     
        /// <summary>
        /// 备  注:有效性
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsEffective" ) ]
        public int? IsEffective  { get; set;  } 
    

    }
    
}
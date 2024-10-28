using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 货位
    ///</summary>
    [SugarTable("QYD_Basic_WhBin")]
    public class WarehouseBin
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
        /// 备  注:有效性
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsEffective" ) ]
        public int? IsEffective  { get; set;  } 
     
        /// <summary>
        /// 备  注:库位编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string? Code  { get; set;  } 
     
        /// <summary>
        /// 备  注:库位名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string? Name  { get; set;  } 
     
        /// <summary>
        /// 备  注:组织ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Org" ) ]
        public long? Org  { get; set;  } 
     
        /// <summary>
        /// 备  注:面积
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Area" ) ]
        public string? Area  { get; set;  } 
     
        /// <summary>
        /// 备  注:体积
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Volume" ) ]
        public string? Volume  { get; set;  } 
     
        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Remark" ) ]
        public string? Remark  { get; set;  } 
     
        /// <summary>
        /// 备  注:仓库ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Wh" ) ]
        public long? Wh  { get; set;  } 
     
        /// <summary>
        /// 备  注:库区ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="WhbinGroup" ) ]
        public long? WhbinGroup  { get; set;  } 
    

    }
    
}
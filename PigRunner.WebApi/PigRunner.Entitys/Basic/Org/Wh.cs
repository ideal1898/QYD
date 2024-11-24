using PigRunner.Public.Abstract;
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
    public class Wh : BaseEntity<Wh>
    {
        
         
         
        
        /// <summary>
        /// 备  注:编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string Code  { get; set;  } =string.Empty;
        
         
        
        /// <summary>
        /// 备  注:名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string Name  { get; set;  } = string.Empty;



        /// <summary>
        /// 备  注:组织
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Org" ) ]
        public long Org  { get; set;  }



        /// <summary>
        /// 备  注:是否库位
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "IsStoreBin")]
        public int IsStoreBin { get; set; } = -1;
        
         
        
        /// <summary>
        /// 备  注:面积
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Area" ) ]
        public decimal Area  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:容积
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Volume" ) ]
        public decimal Volume  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:供应商
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Supplier" ) ]
        public long Supplier  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:客户
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Customer" ) ]
        public long Customer  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:地址
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Address" ) ]
        public string Address  { get; set;  } = string.Empty;



        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Remark" ) ]
        public string Remark  { get; set;  } = string.Empty;



        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsEffective" ) ]
        public int IsEffective  { get; set; } = -1;








    }
    
}
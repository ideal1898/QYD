using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 物料主表
    ///</summary>
    [SugarTable("QYD_Basic_Item")]
    public class Item : BaseEntity<Item>
    {
        
         
         
        
        /// <summary>
        /// 备  注:物料编码
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code" ) ]
        public string? Code  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:物料名称
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Name" ) ]
        public string? Name  { get; set;  } 
        
         
         
         
         
        
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
        /// 备  注:规格
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="SPECS" ) ]
        public string? SPECS  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:库存物料分类ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="StockCategory" ) ]
        public int? StockCategory  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:组织ID
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Org" ) ]
        public int? Org  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:主单位
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="UOM" ) ]
        public long? UOM  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:副单位
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="BaseUOM" ) ]
        public long? BaseUOM  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:主副单位转化系数
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="RatioToBase" ) ]
        public decimal? RatioToBase  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:参考编码1
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code1" ) ]
        public string? Code1  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:参考编码2
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Code2" ) ]
        public string? Code2  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:描述
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Description" ) ]
        public string? Description  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:物料形态属性
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="ItemFormAttribute" ) ]
        public string? ItemFormAttribute  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:可销售
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsSalesEnable" ) ]
        public int? IsSalesEnable  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:可生产
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsBuildEnable" ) ]
        public int? IsBuildEnable  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:可采购
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsPurchaseEnable" ) ]
        public int? IsPurchaseEnable  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:可委外
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsOutsideOperationEnable" ) ]
        public int? IsOutsideOperationEnable  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:物料图片
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Picture" ) ]
        public string? Picture  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:是否批次管理
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsLot" ) ]
        public int? IsLot  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:是否质检
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsQc" ) ]
        public int? IsQc  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:是否质保期管理
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="IsQgPeriod" ) ]
        public int? IsQgPeriod  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:质保天数
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="QgDay" ) ]
        public string? QgDay  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:质保预警天数
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="QgAlterDay" ) ]
        public string? QgAlterDay  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:质保预警日期单位
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="QgAlterDayUom" ) ]
        public string? QgAlterDayUom  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:默认存储地点
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Warehouse" ) ]
        public long? Warehouse  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:标准包装数量
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="PackagQty" ) ]
        public string? PackagQty  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:最小采购量
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="MinRcvQty" ) ]
        public string? MinRcvQty  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:采购周期
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="PurPeriod" ) ]
        public string? PurPeriod  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:供应商
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="Supplier" ) ]
        public long? Supplier  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:采购周期单位
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="PurPeriodUom" ) ]
        public string? PurPeriodUom  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:生产批量
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="MoBatch" ) ]
        public string? MoBatch  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:生产部门
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName="MoDep" ) ]
        public long? MoDep  { get; set;  } 
        
         
        

    }
}

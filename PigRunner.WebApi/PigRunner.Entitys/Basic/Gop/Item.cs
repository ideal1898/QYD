using PigRunner.Public.Abstract;
using SqlSugar;
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
        public string Code { get; set; } = string.Empty;
        
         
        
        /// <summary>
        /// 备  注:物料名称
        /// 默认值:
        ///</summary>
        public string Name  { get; set;  } = string.Empty;

        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        public int IsEffective  { get; set;  } = 0;



        /// <summary>
        /// 备  注:规格
        /// 默认值:
        ///</summary>
        public string SPECS  { get; set;  } = string.Empty;



        /// <summary>
        /// 备  注:库存物料分类ID
        /// 默认值:
        ///</summary>
        public long StockCategory { get; set; } = 0;



        /// <summary>
        /// 备  注:组织ID
        /// 默认值:
        ///</summary>
        public long Org { get; set; } = 0;



        /// <summary>
        /// 备  注:主单位
        /// 默认值:
        ///</summary>
        public long UOM { get; set; } = 0;



        /// <summary>
        /// 备  注:副单位
        /// 默认值:
        ///</summary>
        public long BaseUOM { get; set; } = 0;
        
         
        
        /// <summary>
        /// 备  注:主副单位转化系数
        /// 默认值:
        ///</summary>
        public decimal RatioToBase  { get; set;  }



        /// <summary>
        /// 旧编码
        ///</summary>
        public string Code1 { get; set; } = string.Empty;
        
        
        /// <summary>
        /// 备  注:描述
        /// 默认值:
        ///</summary>
        public string Description  { get; set;  } = string.Empty;



        /// <summary>
        /// 备  注:物料形态属性
        /// 默认值:
        ///</summary>
        public int ItemFormAttribute { get; set; } = 0;
        
         
        
        /// <summary>
        /// 备  注:可销售
        /// 默认值:
        ///</summary>
        public int IsSalesEnable  { get; set;  } = 0;



        /// <summary>
        /// 备  注:可生产
        /// 默认值:
        ///</summary>
        public int IsBuildEnable  { get; set;  } = 0;



        /// <summary>
        /// 备  注:可采购
        /// 默认值:
        ///</summary>
        public int IsPurchaseEnable  { get; set;  } = 0;



        /// <summary>
        /// 备  注:可委外
        /// 默认值:
        ///</summary>
        public int IsOutsideOperationEnable  { get; set;  } = 0;



        /// <summary>
        /// 备  注:物料图片
        /// 默认值:
        ///</summary>
        public string Picture { get; set; } = string.Empty; 
        
         
        
        /// <summary>
        /// 备  注:是否批次管理
        /// 默认值:
        ///</summary>
        public int IsLot  { get; set;  } = 0;



        /// <summary>
        /// 备  注:是否质检
        /// 默认值:
        ///</summary>
        public int IsQc  { get; set;  } = 0;



        /// <summary>
        /// 备  注:是否质保期管理
        /// 默认值:
        ///</summary>
        public int IsQgPeriod  { get; set; } = 0;



        /// <summary>
        /// 备  注:质保天数
        /// 默认值:
        ///</summary>
        public int QgDay { get; set; } = 0;
        
         
        
        /// <summary>
        /// 备  注:质保预警天数
        /// 默认值:
        ///</summary>
        public int QgAlterDay  { get; set;  } = 0;



        /// <summary>
        /// 备  注:质保期单位
        /// 默认值:
        ///</summary>
        [SugarColumn(ColumnName = "QgAlterDayUom")]
        public long QgAlterDayUom { get; set; } = 0;



        /// <summary>
        /// 备  注:默认存储地点
        /// 默认值:
        ///</summary>
        public long Warehouse { get; set; } = 0;



        /// <summary>
        /// 备  注:标准包装数量
        /// 默认值:
        ///</summary>
        public decimal PackagQty { get; set; } = 0;



        /// <summary>
        /// 备  注:最小采购量
        /// 默认值:
        ///</summary>
        public decimal MinRcvQty { get; set; } = 0;



        /// <summary>
        /// 备  注:采购周期
        /// 默认值:
        ///</summary>
        public int PurPeriod { get; set; } = 0;



        /// <summary>
        /// 备  注:供应商
        /// 默认值:
        ///</summary>
        public long Supplier { get; set; } = 0;



        /// <summary>
        /// 备  注:采购周期单位
        /// 默认值:
        ///</summary>
        public long PurPeriodUom { get; set; } = 0;
        
         
        
        /// <summary>
        /// 备  注:生产批量
        /// 默认值:
        ///</summary>
        public long MoBatch  { get; set;  }



        /// <summary>
        /// 备  注:生产部门
        /// 默认值:
        ///</summary>
        public long MoDept { get; set; } = 0;



        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifiedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifiedBy { get; set; } = string.Empty;

    }
    
}
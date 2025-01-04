using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 计量单位
    ///</summary>
    [SugarTable("QYD_Basic_UOM")]
    public class UOM : BaseEntity<UOM>
    {
        /// <summary>
        /// 备  注:计量单位编码
        /// 默认值:
        ///</summary>
        public string Code  { get; set;  } = string.Empty;



        /// <summary>
        /// 备  注:计量单位名称
        /// 默认值:
        ///</summary>
        public string Name  { get; set;  } = string.Empty;



        /// <summary>
        /// 备  注:是否基准单位
        /// 默认值:
        ///</summary>
        public int IsBase { get; set; } = 0;
        
         
        /// <summary>
        /// 备  注:主副单位转换系数
        /// 默认值:
        ///</summary>
        public decimal RatioToBase { get; set; } = 0;



        /// <summary>
        /// 舍位方式：1-四舍五入，2-舍位，3-入位
        /// 默认值:
        ///</summary>
        public int RoundWay { get; set; } = 0;



        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        public string Remark { get; set; } = string.Empty;

        /// <summary>
        /// 单位精度
        /// </summary>
        public decimal UomPrecision { get; set; } = 0;

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
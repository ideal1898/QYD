using PigRunner.Public.Abstract;
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
    public class WhBinGroup : BaseEntity<WhBinGroup>
    {
        /// <summary>
        /// 备  注:库区编码
        /// 默认值:
        ///</summary>
        public string Code { get; set; } = string.Empty;
        
        /// <summary>
        /// 备  注:库区名称
        /// 默认值:
        ///</summary>
        public string Name  { get; set;  } = string.Empty;


        /// <summary>
        /// 备  注:仓库
        /// 默认值:
        ///</summary>
        public long Wh { get; set; } = 0;


        /// <summary>
        /// 备  注:组织
        /// 默认值:
        ///</summary>
        public long Org { get; set; } = 0;
        
        
        /// <summary>
        /// 备  注:面积
        /// 默认值:
        ///</summary>
        public decimal Area  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:体积
        /// 默认值:
        ///</summary>
        public decimal Volume  { get; set;  }

        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        public string Remark { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:有效性
        /// 默认值:
        ///</summary>
        public int IsEffective { get; set; } = 0;

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
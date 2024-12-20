using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 业务员
    ///</summary>
    [SugarTable("QYD_Basic_Operators")]
    public class Operators : BaseEntity<Operators>
    {
        /// <summary>
        /// 备  注:人员编码
        /// 默认值:
        ///</summary>
        public string Code { get; set; } = string.Empty;
        
         
        
        /// <summary>
        /// 备  注:人员名称
        /// 默认值:
        ///</summary>
        public string Name  { get; set;  } = string.Empty;



        /// <summary>
        /// 备  注:部门ID
        /// 默认值:
        ///</summary>
        public long Dept { get; set; } = 0;



        /// <summary>
        /// 备  注:是否采购员
        /// 默认值:
        ///</summary>
        public int IsPurer  { get; set;  } = 0;



        /// <summary>
        /// 备  注:是否销售人员
        /// 默认值:
        ///</summary>
        public int IsSaler  { get; set;  } = 0;



        /// <summary>
        /// 备  注:是否计划人员
        /// 默认值:
        ///</summary>
        public int IsPlaner  { get; set;  } = 0;

        /// <summary>
        /// 备  注:是否库存管理员
        /// 默认值:
        ///</summary>
        public int IsInver { get; set; } = 0;

        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        public int IsEffective { get; set; } = 0;

        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        public string Remark { get; set; } = string.Empty;

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
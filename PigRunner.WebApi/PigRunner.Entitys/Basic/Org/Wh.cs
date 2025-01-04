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
        public string Code  { get; set;  } =string.Empty;
        
         
        
        /// <summary>
        /// 备  注:名称
        /// 默认值:
        ///</summary>
        public string Name  { get; set;  } = string.Empty;



        /// <summary>
        /// 备  注:组织
        /// 默认值:
        ///</summary>
        public long Org  { get; set; } = 0;



        /// <summary>
        /// 备  注:是否库位
        /// 默认值:
        ///</summary>
        public int IsStoreBin { get; set; } = 0;
        
         
        
        /// <summary>
        /// 备  注:面积
        /// 默认值:
        ///</summary>
        public decimal Area  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:容积
        /// 默认值:
        ///</summary>
        public decimal Volume  { get; set;  } 
        
         
        
        /// <summary>
        /// 备  注:供应商
        /// 默认值:
        ///</summary>
        public long Supplier  { get; set; } = 0;



        /// <summary>
        /// 备  注:客户
        /// 默认值:
        ///</summary>
        public long Customer  { get; set; } = 0;



        /// <summary>
        /// 备  注:地址
        /// 默认值:
        ///</summary>
        public string Address  { get; set;  } = string.Empty;



        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        public string Remark  { get; set;  } = string.Empty;



        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        public int IsEffective  { get; set; } = 0;

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
using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic
{
    /// <summary>
    /// 客户主表
    ///</summary>
    [SugarTable("QYD_Basic_Customer")]
    public class Customer : BaseEntity<Customer>
    {
        /// <summary>
        /// 备  注:客户编码
        /// 默认值:
        ///</summary>
        public string Code { get; set; } = string.Empty; 
        
        /// <summary>
        /// 备  注:客户名称
        /// 默认值:
        ///</summary>
        public string Name  { get; set;  } = string.Empty;



        /// <summary>
        /// 备  注:客户简称
        /// 默认值:
        ///</summary>
        public string ShortName  { get; set;  } = string.Empty;

        /// <summary>
        /// 备  注:客户分类ID
        /// 默认值:
        ///</summary>
        public long Category { get; set; }

        /// <summary>
        /// 备  注:地区
        /// 默认值:
        ///</summary>
        public long Country { get; set; }

        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        public string Remark { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:供应商ID
        /// 默认值:
        ///</summary>
        public long Supplier { get; set; } = 0;


        /// <summary>
        /// 收货地址
        ///</summary>
        public string RcvAddress { get; set; } = string.Empty;


        /// <summary>
        /// 是否内部组织
        ///</summary>
        public int IsInerOrg { get; set; } = 0;


        /// <summary>
        /// 部门
        ///</summary>
        public long Dept { get; set; } = 0;

        /// <summary>
        /// 业务员
        ///</summary>
        public long Operators { get; set; } = 0;

        /// <summary>
        /// 税率
        ///</summary>
        public decimal TaxRate { get; set; } = 0;

        /// <summary>
        /// 税号
        ///</summary>
        public string TaxNum { get; set; } = string.Empty;

        /// <summary>
        /// 上级客户
        ///</summary>
        public long ParentCustomer { get; set; } = 0;

        /// <summary>
        /// 收货人电话
        ///</summary>
        public string RcvManTell { get; set; } = string.Empty;

        /// <summary>
        /// 收款条件
        ///</summary>
        public string RecTerm { get; set; } = string.Empty;

        /// <summary>
        /// 立账条件
        ///</summary>
        public string AccrueTerm { get; set; } = string.Empty;

        /// <summary>
        /// 出货原则
        ///</summary>
        public string ShipRule { get; set; } = string.Empty;

        /// <summary>
        /// 组织ID
        ///</summary>
        public long Org { get; set; } = 0;

        /// <summary>
        /// 状态：1-开立；2-核准中；3-已核准
        ///</summary>
        public int Status { get; set; } = 0;

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
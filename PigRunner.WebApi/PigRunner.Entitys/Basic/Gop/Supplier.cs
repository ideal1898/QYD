using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace PigRunner.Entitys.Basic.Gop
{
    /// <summary>
    /// 供应商主表
    ///</summary>
    [SugarTable("QYD_Basic_Supplier")]
    public class Supplier : BaseEntity<Supplier>
    {
        /// <summary>
        /// 备  注:供应商编码
        /// 默认值:
        ///</summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:供应商名称
        /// 默认值:
        ///</summary>
        public string Name { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:供应商简称
        /// 默认值:
        ///</summary>
        public string ShortName { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:供应商分类ID
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
        /// 备  注:对于客户
        /// 默认值:
        ///</summary>
        public long Customer { get; set; } = 0;


        /// <summary>
        /// 微信公众号
        ///</summary>
        public string WeChat { get; set; } = string.Empty;


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
        /// 上级供应商
        ///</summary>
        public long ParentSuppiler { get; set; } = 0;

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
        /// 状态：0-失效；1-生效
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
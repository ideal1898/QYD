using PigRunner.DTO.Basic.Pub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.Basic.Gop
{
    /// <summary>
    /// 供应商
    /// </summary>
     public class SupplierView : PubView
    {

        /// <summary>
        /// 备  注:客户简称
        ///</summary>
        public string ShortName { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:客户分类
        ///</summary>
        public string CategoryCode { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:客户分类名称
        ///</summary>
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>
        ///地区
        ///</summary>
        public string CountryCode { get; set; } = string.Empty;


        /// <summary>
        ///地区名称
        ///</summary>
        public string CountryName { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        ///</summary>
        public string Remark { get; set; } = string.Empty;

        /// <summary>
        ///客户编码
        ///</summary>
        public string CustomerCode { get; set; } = string.Empty;

        /// <summary>
        ///客户名称
        ///</summary>
        public string CustomerName { get; set; } = string.Empty;


        /// <summary>
        /// 微信公众号
        ///</summary>
        public string WeChat { get; set; } = string.Empty;


        /// <summary>
        /// 是否内部组织
        ///</summary>
        public bool IsInerOrg { get; set; } = false;

        /// <summary>
        /// 是否内部组织
        ///</summary>
        public string InerOrgName { get; set; } = string.Empty;


        /// <summary>
        /// 部门
        ///</summary>
        public string DeptCode { get; set; } = string.Empty;

        /// <summary>
        /// 部门名称
        ///</summary>
        public string DeptName { get; set; } = string.Empty;

        /// <summary>
        /// 业务员
        ///</summary>
        public string OperatorsCode { get; set; } = string.Empty;

        /// <summary>
        /// 业务员名称
        ///</summary>
        public string OperatorsName { get; set; } = string.Empty;

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
        public string ParentSupCode { get; set; } = string.Empty;

        /// <summary>
        /// 上级客户名称
        ///</summary>
        public string ParentSupName { get; set; } = string.Empty;

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
        /// 状态
        /// </summary>
        public bool Status { get; set; } = false;

        /// <summary>
        /// 状态名称
        ///</summary>
        public string StatusName { get; set; } = string.Empty;
    }
}

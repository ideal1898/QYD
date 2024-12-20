
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.DTO.Basic
 * 唯一标识：1f417ad6-9534-474a-96cb-640ebda52d3f
 * 文件名：SupplierCategoryVo
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/11/17 10:38:58
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>


using Newtonsoft.Json;
using PigRunner.DTO.Basic.Pub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PigRunner.DTO.Basic
{
    /// <summary>
    /// 客户
    /// </summary>
    public class CustomerView : PubView
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
        ///供应商编码
        ///</summary>
        public string SupplierCode { get; set; } = string.Empty;

        /// <summary>
        ///供应商名称
        ///</summary>
        public string SupplierName { get; set; } = string.Empty;


        /// <summary>
        /// 收货地址
        ///</summary>
        public string RcvAddress { get; set; } = string.Empty;


        /// <summary>
        /// 是否内部组织
        ///</summary>
        public bool IsInerOrg { get; set; } = false;


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
        public string ParentCustCode { get; set; } = string.Empty;

        /// <summary>
        /// 上级客户名称
        ///</summary>
        public string ParentCustName { get; set; } = string.Empty;

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
        public int Status { get; set; } = 0;

        /// <summary>
        /// 状态名称
        ///</summary>
        public string StatusName { get; set; } = string.Empty;
    }
}

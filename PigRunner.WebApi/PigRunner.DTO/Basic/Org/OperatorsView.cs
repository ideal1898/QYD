using PigRunner.DTO.Basic.Pub;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PigRunner.DTO.Basic
{
    /// <summary>
    /// 业务员
    /// </summary>
    public class OperatorsView : PubView
    {
        /// <summary>
        /// 备  注:部门ID
        /// 默认值:
        ///</summary>
        public string DeptCode { get; set; } = string.Empty;

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:是否采购员
        /// 默认值:
        ///</summary>
        public bool IsPurer { get; set; } = false;

        /// <summary>
        /// 是否采购员
        /// </summary>
        public string IsPurerName { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:是否销售人员
        /// 默认值:
        ///</summary>
        public bool IsSaler { get; set; } = false;

        /// <summary>
        /// 是否销售人员
        /// </summary>
        public string IsSalerName { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:是否计划人员
        /// 默认值:
        ///</summary>
        public bool IsPlaner { get; set; } = false;

        /// <summary>
        /// 是否计划人员
        /// </summary>
        public string IsPlanerName { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:是否库存管理员
        /// 默认值:
        ///</summary>
        public bool IsInver { get; set; } = false;

        /// <summary>
        /// 是否计划人员
        /// </summary>
        public string IsInverName { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        public bool IsEffective { get; set; } = false;

        /// <summary>
        /// 生效名称
        /// </summary>
        public string Effective { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        public string Remark { get; set; } = string.Empty;

    }

}
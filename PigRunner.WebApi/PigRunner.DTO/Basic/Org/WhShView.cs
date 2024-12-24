using PigRunner.DTO.Basic.Pub;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PigRunner.DTO.Basic
{

    public class WhShView : PubView
    {
        /// <summary>
        /// 备  注:组织名称
        /// 默认值:
        ///</summary>
        public string OrgName { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:组织
        /// 默认值:
        ///</summary>
        public string OrgCode { get; set; } = string.Empty;


        /// <summary>
        /// 备  注:面积
        /// 默认值:
        ///</summary>
        public decimal Area { get; set; } = 0;

        /// <summary>
        /// 备  注:容积
        /// 默认值:
        ///</summary>
        public decimal Volume { get; set; } = 0;



        /// <summary>
        /// 仓库编码
        ///</summary>
        public string WhCode { get; set; } = string.Empty;

        /// <summary>
        /// 仓库名称
        ///</summary>
        public string WhName { get; set; } = string.Empty;

        /// <summary>
        /// 库区编码
        ///</summary>
        public string WhBinGroupCode { get; set; } = string.Empty;

        /// <summary>
        /// 库区名称
        ///</summary>
        public string WhBinGroupName { get; set; } = string.Empty;


        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        public string Remark { get; set; } = string.Empty;


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
        /// 是否拣货货位
        ///</summary>
        public bool IsWhSh { get; set; } = false;

        /// <summary>
        /// 拣货货位名称
        /// </summary>
        public string WhSh { get; set; } = string.Empty;
    }

}
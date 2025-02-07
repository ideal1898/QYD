using PigRunner.DTO.Basic.Pub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.Basic.Gop
{
    public class UOMView : PubView
    {

        /// <summary>
        /// 备  注:是否基准单位
        /// 默认值:
        ///</summary>
        public string IsBase { get; set; } = string.Empty;

        /// <summary>
        /// 是否基准单位名称
        /// </summary>
        public string IsBaseName { get; set; } = string.Empty;


        /// <summary>
        /// 备  注:主副单位转换系数
        /// 默认值:
        ///</summary>
        public string RatioToBase { get; set; } = string.Empty;



        /// <summary>
        /// 舍位方式：1-四舍五入，2-舍位，3-入位
        /// 默认值:
        ///</summary>
        public string RoundWay { get; set; } = string.Empty;

        /// <summary>
        /// 舍位方式名称
        /// </summary>
        public string RoundWayName { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        public string Remark { get; set; } = string.Empty;

        /// <summary>
        /// 单位精度
        /// </summary>
        public string UomPrecision { get; set; } = string.Empty;
    }
}

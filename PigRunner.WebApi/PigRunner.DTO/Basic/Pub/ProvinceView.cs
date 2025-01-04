using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.Basic.Pub
{
    /// <summary>
    /// 省/自治区
    /// </summary>
    public class ProvinceView: PubView
    {

        /// <summary>
        /// 编码
        /// </summary>
        public string CountryCode { get; set; } = string.Empty;

        /// <summary>
        /// 名称
        /// </summary>
        public string CountryName { get; set; } = string.Empty;
    }
}

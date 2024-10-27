using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.Basic
{
    public class CountryVo
    {
        /// <summary>
        /// 国家/地区编码
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 国家/地区名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 时区
        /// </summary>
        public int TimeZone { get; set; } = -1;

        /// <summary>
        /// 地区格式
        /// </summary>
        public int CountryFormat { get; set; } = -1;

        /// <summary>
        /// 币种
        /// </summary>
        public int Currency { get; set; } = -1;

        /// <summary>
        /// 语言
        /// </summary>
        public int Language { get; set; } = -1;

        /// <summary>
        /// 姓名格式
        /// </summary>
        public int NameFormat { get; set; } = -1;


        /// <summary>
        /// 操作类型
        /// </summary>
        public int OptType { get; set; } = -1;
    }
}

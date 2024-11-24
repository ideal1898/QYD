using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.Basic
{
    /// <summary>
    /// 枚举类型返回值
    /// </summary>
    public class EnumView
    {
        /// <summary>
        /// key值
        /// </summary>
        public string value { get; set; } = String.Empty;

        /// <summary>
        /// 名称
        /// </summary>

        public string label { get; set; } = String.Empty;

        /// <summary>
        /// 操作类型
        /// </summary>
        public string optType { get; set; } = String.Empty;
    }
}

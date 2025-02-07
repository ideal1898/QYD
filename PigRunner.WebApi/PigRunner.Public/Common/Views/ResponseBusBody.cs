using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public.Common.Views
{
    /// <summary>
    /// 业务数据返回
    /// </summary>
    public struct ResponseBusBody
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ResponseBusBody()
        {
        }

        /// <summary>
        /// 状态：200,401,502
        /// </summary>
        public int code { get; set; } = 200;
        /// <summary>
        /// 信息
        /// </summary>
        public string msg { get; set; } = string.Empty;
        /// <summary>
        /// 业务数据
        /// </summary>
        public JObject data { get; set; } = new JObject();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public.Common.Views
{
    /// <summary>
    /// 公共返回实体
    /// </summary>
    public class PubResponse
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; } = false;
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// 单号/编码
        /// </summary>
        public string Code { get; set; }= string.Empty;
        

        public static PubResponse Error(string msg)
        {
            return new PubResponse { Success = false, Message = msg };
        }
    }
}

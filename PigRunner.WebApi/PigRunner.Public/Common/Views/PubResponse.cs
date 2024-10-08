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


        /// <summary>
        /// 单据ID
        /// </summary>
        public long ID { get; set; } = 0;


        /// <summary>
        /// 查询返回的数据
        /// </summary>
        public object Data { get; set; } = null;

    }
}

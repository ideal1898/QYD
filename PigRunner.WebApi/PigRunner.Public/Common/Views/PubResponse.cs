using Newtonsoft.Json.Linq;
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
        public bool success { get; set; } = false;
        /// <summary>
        /// 信息
        /// </summary>
        public string msg { get; set; } = string.Empty;

        /// <summary>
        /// 单号/编码
        /// </summary>
        public int code { get; set; }= 0;


        /// <summary>
        /// 单据ID
        /// </summary>
        public long id { get; set; } = 0;


        ///// <summary>
        ///// 查询返回的数据
        ///// </summary>
        //public object qryData { get; set; } = null;

        /// <summary>
        /// 查询返回的数据
        /// </summary>
        public object data { get; set; } = null;

    }
}

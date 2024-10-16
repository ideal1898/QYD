
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.Public.Common.Views
 * 唯一标识：f6d4d382-fb32-4560-8a7b-36b6eff74d31
 * 文件名：ResponseBody
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/10/16 9:43:44
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>


using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public.Common.Views
{
    public class ResponseBody
    {
        /// <summary>
        /// 状态：200,401,502
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string msg { get; set; } = string.Empty;
        /// <summary>
        /// 总数：查询时，需要返回，其他均为0
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 业务数据
        /// </summary>
        public JArray data { get; set; } = new JArray();
    }
}

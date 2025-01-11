using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.Basic.Pub
{

    /// <summary>
    /// 公共档案视图基类
    /// </summary>
    public class PubView
    {
        /// <summary>
        /// id
        /// </summary>
        public string ID { get; set; } = string.Empty;


        public string LineNum { get; set; } = string.Empty;
        /// <summary>
        ///编码
        /// </summary>
        public string Code { get; set; } = string.Empty;



        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = string.Empty;


        /// <summary>
        /// 操作类型
        /// </summary>
        public string OptType { get; set; } = string.Empty;

        /// <summary>
        /// 当前页
        /// </summary>
        public string Current { get; set; } = string.Empty;

        /// <summary>
        /// 每页几行
        /// </summary>
        public string Size { get; set; } = string.Empty;

        /// <summary>
        /// 编号集合
        /// </summary>
        public List<string> Codes { get; set; } = new List<string>();
    }
}

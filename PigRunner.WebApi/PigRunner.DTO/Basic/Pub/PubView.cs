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
        public long ID { get; set; } = -1;


        public int LineNum { get; set; } = -1;
        /// <summary>
        /// 国家/地区编码
        /// </summary>
        public string Code { get; set; } = string.Empty;



        /// <summary>
        /// 国家/地区名称
        /// </summary>
        public string Name { get; set; } = string.Empty;


        /// <summary>
        /// 操作类型
        /// </summary>
        public string OptType { get; set; } = string.Empty;

        /// <summary>
        /// 当前页
        /// </summary>
        public int Current { get; set; } = 1;

        /// <summary>
        /// 每页几行
        /// </summary>
        public int Size { get; set; } = 2;

        /// <summary>
        /// 编号集合
        /// </summary>
        public List<string> Codes { get; set; } = new List<string>();
    }
}

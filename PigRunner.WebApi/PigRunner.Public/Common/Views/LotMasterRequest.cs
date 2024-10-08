using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public.Common.Views
{
    public class LotMasterRequest
    {
        /// <summary>
        /// 批号
        /// </summary>
        public string LotCode { get; set; } = string.Empty;

        /// <summary>
        /// 料品
        /// </summary>
        public string ItemMaster { get; set; } = string.Empty;

        /// <summary>
        /// 组织
        /// </summary>
        public string Org { get; set; } = string.Empty;

        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime EffectiveDate { get; set; }

        /// <summary>
        /// 生效天数
        /// </summary>
        public int ValidDate { get; set; }

        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime InvalidDate { get; set; }

        /// <summary>
        /// 来源单号
        /// </summary>
        public string SrcDocNo { get; set; } = string.Empty;

        /// <summary>
        /// 自动编码
        /// </summary>
        public string AutoCode { get; set; } = string.Empty;


        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; } = string.Empty;

        /// <summary>
        /// 操作类型：0：新增；1：删除；2：查询
        /// </summary>
        public int OptType { get; set; } = 0;
    }
}

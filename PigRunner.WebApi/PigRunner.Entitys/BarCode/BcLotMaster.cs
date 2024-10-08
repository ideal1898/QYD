using PigRunner.Public.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Entitys.BarCode
{
    [SqlSugar.SugarTable("QYD_BC_LotMaster")]
    public class BcLotMaster : BaseEntity<BcLotMaster>
    {
        /// <summary>
        /// 批号
        /// </summary>
        public string LotCode { get; set; } = string.Empty;

        /// <summary>
        /// 料品
        /// </summary>
        public long ItemMaster { get; set; } = 0;

        /// <summary>
        /// 组织
        /// </summary>
        public long Org { get; set; } = 0;

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
        public long AutoCode { get; set; } = 0;


        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; } = string.Empty;
    }
}

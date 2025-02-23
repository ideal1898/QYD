using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.Public.Abstract
{
    /// <summary>
    /// 实体基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LineBaseEntity
    {
        /// <summary>
        /// 业务标识
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnName = "ID")]
        public long ID { get; set; } = 0;
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;
        /// <summary>
        /// 版本
        /// </summary>
        public long SysVersion { get; set; } = 0;
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifiedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifiedBy { get; set; } = string.Empty;
        /// <summary>
        /// 来源单据号
        /// </summary>
        public string SrcDocNo { get; set; } = string.Empty;
        /// <summary>
        /// 来源单据行
        /// </summary>
        public long SrcDocLine { get; set; }
        /// <summary>
        /// 来源单据
        /// </summary>
        public int SrcType { get; set; }
    }
}

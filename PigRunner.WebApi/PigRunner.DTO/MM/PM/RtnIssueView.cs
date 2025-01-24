using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.MM.PM
{
    /// <summary>
    /// 退料单视图
    /// </summary>
    public class RtnIssueView: OrderBaseView
    {

        /// <summary>
        /// 发料部门
        /// </summary>
        public long HandleDeptID { get; set; } = 0;

        /// <summary>
        /// 发料部门编码
        /// </summary>
        public string HandleDeptCode { get; set; } = string.Empty;

        /// <summary>
        /// 发料部门名称
        /// </summary>
        public string HandleDeptName { get; set; } = string.Empty;


        /// <summary>
        /// 发料人
        /// </summary>
        public long HandlePersonID { get; set; } = 0;

        /// <summary>
        /// 发料人编码
        /// </summary>
        public string HandlePersonCode { get; set; } = string.Empty;

        /// <summary>
        /// 发料人名称
        /// </summary>
        public string HandlePersonName { get; set; } = string.Empty;

        /// <summary>
        /// 确认日期
        /// </summary>
        public string BusinessCreatedOn { get; set; } = string.Empty;

        /// <summary>
        /// 领料明细
        /// </summary>
        public List<RtnIssueLineView> RtnIssueLines { get; set; } = new List<RtnIssueLineView>();
    }

    /// <summary>
    /// 退料单行视图
    /// </summary>
    public class RtnIssueLineView
    {
        /// <summary>
        /// 业务主键
        /// </summary>
        public long id { get; set; } = 0;
        /// <summary>
        /// 领料单ID
        /// </summary>
        public long RtnIssueID { get; set; } = 0;

        /// <summary>
        /// 行号
        /// </summary>
        public int LineNum { get; set; } = 0;

        /// <summary>
        /// 领料行id
        /// </summary>
        public long IssueLineID { get; set; } = 0;

        /// <summary>
        /// 领料单号
        /// </summary>
        public string IssueDocNo { get; set; } = string.Empty;

        /// <summary>
        /// 领料行号
        /// </summary>
        public string IssueLineNum { get; set; } = string.Empty;

        /// <summary>
        /// 退料理由
        /// </summary>
        public int RecedeReason { get; set; } = -1;

        /// <summary>
        /// 料品
        /// </summary>
        public long ItemID { get; set; } = 0;

        /// <summary>
        /// 料品编码
        /// </summary>
        public string ItemCode { get; set; } = string.Empty;

        /// <summary>
        /// 料品名称
        /// </summary>
        public string ItemName { get; set; } = string.Empty;

        /// <summary>
        /// 料品规格
        /// </summary>
        public string ItemSpecs { get; set; } = string.Empty;


        /// <summary>
        /// 生产数量
        /// </summary>
        public decimal MoQty { get; set; } = 0;


        /// <summary>
        /// 应发数量
        /// </summary>
        public decimal IssueQty { get; set; } = 0;


        /// <summary>
        /// 实发数量
        /// </summary>
        public decimal IssuedQty { get; set; } = 0;

        /// <summary>
        /// 发料单位
        /// </summary>
        public long IssueUomID { get; set; } = 0;

        /// <summary>
        /// 发料单位编码
        /// </summary>
        public string IssueUomCode { get; set; } = string.Empty;

        /// <summary>
        /// 发料单位名称
        /// </summary>
        public string IssueUomName { get; set; } = string.Empty;


        /// <summary>
        /// 发料仓库
        /// </summary>
        public long IssueWhID { get; set; } = 0;

        /// <summary>
        /// 发料仓库编码
        /// </summary>
        public string IssueWhCode { get; set; } = string.Empty;

        /// <summary>
        /// 发料仓库名称
        /// </summary>
        public string IssueWhName { get; set; } = string.Empty;

        /// <summary>
        /// 批次
        /// </summary>
        public long LotMasterID { get; set; } = 0;

        /// <summary>
        /// 批号
        /// </summary>
        public string LotCode { get; set; } = string.Empty;


        /// <summary>
        /// 货位
        /// </summary>
        public long WhShID { get; set; } = 0;

        /// <summary>
        /// 货位编码
        /// </summary>
        public string WhShCode { get; set; } = string.Empty;

        /// <summary>
        /// 货位名称
        /// </summary>
        public string WhShName { get; set; } = string.Empty;

    }


    /// <summary>
    ///查询视图
    /// </summary>
    public class RntIssueQueryView
    {

        /// <summary>
        /// 单据编码
        /// </summary>
        public string DocNo { get; set; } = string.Empty;

        /// <summary>
        /// 生产部门
        /// </summary>
        public string MoDept { get; set; } = string.Empty;

        /// <summary>
        /// 生产数量
        /// </summary>
        public string MoQty { get; set; } = string.Empty;

        /// <summary>
        /// 料号
        /// </summary>
        public string ItemCode { get; set; } = string.Empty;

        /// <summary>
        /// 品名
        /// </summary>
        public string ItemName { get; set; } = string.Empty;

        /// <summary>
        /// 规格
        /// </summary>
        public string ItemSpec { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreatedTime { get; set; } = string.Empty;

        /// <summary>
        /// 计划开工日
        /// </summary>
        public string StartDate { get; set; } = string.Empty;

        /// <summary>
        /// 单据日期
        /// </summary>
        public string BusinessDate { get; set; } = string.Empty;

        /// <summary>
        /// 单据状态
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// 当前页
        /// </summary>
        public string Current { get; set; } = string.Empty;

        /// <summary>
        /// 每页几行
        /// </summary>
        public string Size { get; set; } = string.Empty;
    }
}

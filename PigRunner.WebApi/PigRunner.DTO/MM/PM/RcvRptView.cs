using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.MM.PM
{
    /// <summary>
    /// 完工入库单视图
    /// </summary>
    public class RcvRptView: OrderBaseView
    {

        /// <summary>
        /// 入库部门
        /// </summary>
        public long RcvDeptID { get; set; } = 0;

        /// <summary>
        /// 入库部门编码
        /// </summary>
        public string RcvDeptCode { get; set; } = string.Empty;

        /// <summary>
        /// 入库部门名称
        /// </summary>
        public string RcvDeptName { get; set; } = string.Empty;


        /// <summary>
        /// 入库人
        /// </summary>
        public long RcvPersonID { get; set; } = 0;

        /// <summary>
        /// 入库人编码
        /// </summary>
        public string RcvPersonCode { get; set; } = string.Empty;

        /// <summary>
        /// 入库人名称
        /// </summary>
        public string RcvPersonName { get; set; } = string.Empty;

        /// <summary>
        /// 入库日期
        /// </summary>
        public string ActualRcvTime { get; set; } = string.Empty;

        /// <summary>
        /// 完工入库明细
        /// </summary>
        public List<RcvRptLineView> RcvRptLines { get; set; } = new List<RcvRptLineView>();
    }

    /// <summary>
    /// 完工入库单行视图
    /// </summary>
    public class RcvRptLineView
    {
        /// <summary>
        /// 业务主键
        /// </summary>
        public long id { get; set; } = 0;
        /// <summary>
        /// 完工入库单ID
        /// </summary>
        public long RcvRptID { get; set; } = 0;

        /// <summary>
        /// 行号
        /// </summary>
        public int LineNum { get; set; } = 0;

        /// <summary>
        /// 生产订单行id
        /// </summary>
        public long MOLineID { get; set; } = 0;

        /// <summary>
        /// 生产单号
        /// </summary>
        public string MODocNo { get; set; } = string.Empty;

        /// <summary>
        /// 生产订单行号
        /// </summary>
        public string MOLineNum { get; set; } = string.Empty;



        /// <summary>
        /// 母件料品
        /// </summary>
        public long BOMItemID { get; set; } = 0;

        /// <summary>
        /// 母件料品编码
        /// </summary>
        public string BOMItemCode { get; set; } = string.Empty;

        /// <summary>
        /// 母件料品名称
        /// </summary>
        public string BOMItemName { get; set; } = string.Empty;

        /// <summary>
        /// 母件料品规格
        /// </summary>
        public string BOMItemSpecs { get; set; } = string.Empty;

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
        /// 入库数量
        /// </summary>
        public decimal RcvQty { get; set; } = 0;



        /// <summary>
        /// 入库单位
        /// </summary>
        public long RcvUomID { get; set; } = 0;

        /// <summary>
        /// 入库单位编码
        /// </summary>
        public string RcvUomCode { get; set; } = string.Empty;

        /// <summary>
        /// 入库单位名称
        /// </summary>
        public string RcvUomName { get; set; } = string.Empty;


        /// <summary>
        /// 入库仓库
        /// </summary>
        public long RcvWhID { get; set; } = 0;

        /// <summary>
        /// 入库仓库编码
        /// </summary>
        public string RcvWhCode { get; set; } = string.Empty;

        /// <summary>
        /// 入库仓库名称
        /// </summary>
        public string RcvWhName { get; set; } = string.Empty;

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
    public class RcvRptQueryView
    {

        /// <summary>
        /// 单据编码
        /// </summary>
        public string DocNo { get; set; } = string.Empty;

        /// <summary>
        /// 单据日期
        /// </summary>
        public string BusinessDate { get; set; } = string.Empty;

        /// <summary>
        /// 单据状态
        /// </summary>
        public string Status { get; set; } = string.Empty;
     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.MM.PM
{
    /// <summary>
    /// 生产订单视图
    /// </summary>
    public class MOView:OrderBaseView
    {
        /// <summary>
        /// 计划开工日
        /// </summary>
        public string StartDate { get; set; } = string.Empty;

        /// <summary>
        /// 生产部门
        /// </summary>
        public long MoDept { get; set; } =0;

        /// <summary>
        /// 生产部门编码
        /// </summary>
        public string MoDeptCode { get; set; } = string.Empty;

        /// <summary>
        /// 生产部门名称
        /// </summary>
        public string MoDeptName { get; set; } = string.Empty;

        /// <summary>
        /// 业务员
        /// </summary>
        public long BusinessPerson { get; set; } = 0;

        /// <summary>
        ///业务员编码
        /// </summary>
        public string BusinessPersonCode { get; set; } = string.Empty;

        /// <summary>
        /// 业务员名称
        /// </summary>
        public string BusinessPersonName { get; set; } = string.Empty;

        /// <summary>
        /// 计划完工日
        /// </summary>
        public string CompleteDate { get; set; } = string.Empty;

        /// <summary>
        /// 完工仓库
        /// </summary>
        public long CompleteWh { get; set; } = 0;

        /// <summary>
        /// 完工仓库编码
        /// </summary>
        public string CompleteWhCode { get; set; } = string.Empty;

        /// <summary>
        /// 完工仓库名称
        /// </summary>
        public string CompleteWhName { get; set; } = string.Empty;

       

        public List<MOLineView> MOLines { get; set; } = new List<MOLineView>();
    }

    /// <summary>
    /// 生产订单行视图
    /// </summary>
    public class MOLineView : BaseView
    {
      
        /// <summary>
        /// 生产订单ID
        /// </summary>
        public long MO { get; set; } = 0;

        /// <summary>
        /// 行号
        /// </summary>
        public string LineNum { get; set; } = string.Empty;

        /// <summary>
        /// 料品
        /// </summary>
        public long Item { get; set; } = 0;

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
        public string MoQty { get; set; } = string.Empty;

        /// <summary>
        /// 生产单位
        /// </summary>
        public long MoUom { get; set; } = 0;

        /// <summary>
        ///生产单位编码
        /// </summary>
        public string MoUomCode { get; set; } = string.Empty;

        /// <summary>
        /// 生产单位名称
        /// </summary>
        public string MoUomName { get; set; } = string.Empty;

        /// <summary>
        /// 计划开工日
        /// </summary>
        public string StartDate { get; set; } = string.Empty;

        /// <summary>
        /// 完工仓库编码
        /// </summary>
        public string CompleteDate { get; set; } = string.Empty;

        /// <summary>
        /// 来源单据
        /// </summary>
        public string SrcDocType { get; set; } = string.Empty;


        /// <summary>
        /// 业务开始时间
        /// </summary>
        public string ActualStartDate { get; set; } = string.Empty;

        /// <summary>
        /// 业务结束时间
        /// </summary>
        public string ActualCompleteDate { get; set; } = string.Empty;

        /// <summary>
        /// bom版本号
        /// </summary>
        public string BomVersion { get; set; } = string.Empty;

        /// <summary>
        /// 工艺路线
        /// </summary>
        public string Routing { get; set; } = string.Empty;

        /// <summary>
        /// 批次
        /// </summary>
        public string LotCode { get; set; } = string.Empty;

        /// <summary>
        /// 批次
        /// </summary>
        public long LotMaster { get; set; } = 0;
    }


    /// <summary>
    /// mo列表视图
    /// </summary>
    public class MOListView
    {

        /// <summary>
        /// 行ID
        /// </summary>
        public long id { get; set;} = 0;

        /// <summary>
        /// 主表ID
        /// </summary>
        public long MainID { get; set; } = 0;
        

        /// <summary>
        /// 行号
        /// </summary>
        public string LineNum { get; set; } = string.Empty;

        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrgName { get; set; } = string.Empty;

        /// <summary>
        /// 单据类型
        /// </summary>
        public string DocTypeName { get; set; } = string.Empty;

        /// <summary>
        /// 单据编码
        /// </summary>
        public string DocNo { get; set; } = string.Empty;

        /// <summary>
        /// 生产部门
        /// </summary>
        public string MoDeptName { get; set; } = string.Empty;

        /// <summary>
        /// 生产数量
        /// </summary>
        public decimal MoQty { get; set; } = 0;

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
        public string ItemSpecs { get; set; } = string.Empty;

        /// <summary>
        /// 单位
        /// </summary>
        public string MoUomName { get; set; } = string.Empty;

        /// <summary>
        /// bom版本
        /// </summary>
        public string BomVersion { get; set; } = string.Empty;

        /// <summary>
        /// 仓库
        /// </summary>
        public string CompleteWhName { get; set; } = string.Empty;

        /// <summary>
        /// 单据状态
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// 单据状态
        /// </summary>
        public string StatusName { get; set; } = string.Empty;

    }

    /// <summary>
    /// mo查询视图
    /// </summary>
    public class MOQueryView
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

    /// <summary>
    /// 删除MO视图
    /// </summary>
    public class MODelView
    {
        /// <summary>
        /// 行ID集合
        /// </summary>
        public List<long> MainIDs { get; set; } = new List<long>();
    }
   
}

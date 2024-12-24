
#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 P R C  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：NXBY
 * 命名空间：PigRunner.DTO.Basic
 * 唯一标识：1e33f0ec-98f6-4f0c-af4d-e88dcb9d9343
 * 文件名：ItemVo
 * 
 * 创建者：Administrator
 * 电子邮箱：1003590782@qq.com
 * 创建时间：2024/10/13 13:45:31
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


using PigRunner.DTO.Basic.Pub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigRunner.DTO.Basic
{
    public class ItemView: PubView
    {

        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        public bool IsEffective { get; set; } = false;

        /// <summary>
        /// 备  注:生效名称
        /// 默认值:
        ///</summary>
        public string Effective { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:规格
        /// 默认值:
        ///</summary>
        public string SPECS { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:库存分类编码
        /// 默认值:
        ///</summary>
        public string StockCategoryCode { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:库存分类名称
        /// 默认值:
        ///</summary>
        public string StockCategoryName { get; set; } = string.Empty;


        /// <summary>
        /// 备  注:组织ID
        /// 默认值:
        ///</summary>
        public string OrgCode { get; set; } = string.Empty;


        /// <summary>
        /// 备  注:组织名称
        /// 默认值:
        ///</summary>
        public string OrgName { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:主单位
        /// 默认值:
        ///</summary>
        public string UOMCode { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:主单位名称
        /// 默认值:
        ///</summary>
        public string UOMName { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:副单位
        /// 默认值:
        ///</summary>
        public string BaseUOMCode { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:副单位名称
        /// 默认值:
        ///</summary>
        public string BaseUOMName { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:主副单位转化系数
        /// 默认值:
        ///</summary>
        public decimal RatioToBase { get; set; } = 0;



        /// <summary>
        /// 旧编码
        ///</summary>
        public string Code1 { get; set; } = string.Empty;


        /// <summary>
        /// 备  注:描述
        /// 默认值:
        ///</summary>
        public string Description { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:物料形态属性
        /// 默认值:
        ///</summary>
        public int ItemFormAttribute { get; set; } = 0;



        /// <summary>
        /// 备  注:可销售
        /// 默认值:
        ///</summary>
        public bool IsSalesEnable { get; set; } = false;



        /// <summary>
        /// 备  注:可生产
        /// 默认值:
        ///</summary>
        public bool IsBuildEnable { get; set; } = false;



        /// <summary>
        /// 备  注:可采购
        /// 默认值:
        ///</summary>
        public bool IsPurchaseEnable { get; set; } = false;



        /// <summary>
        /// 备  注:可委外
        /// 默认值:
        ///</summary>
        public bool IsOutsideOperationEnable { get; set; } = false;



        /// <summary>
        /// 备  注:物料图片
        /// 默认值:
        ///</summary>
        public string Picture { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:是否批次管理
        /// 默认值:
        ///</summary>
        public bool IsLot { get; set; } = false;



        /// <summary>
        /// 备  注:是否质检
        /// 默认值:
        ///</summary>
        public bool IsQc { get; set; } = false;



        /// <summary>
        /// 备  注:是否质保期管理
        /// 默认值:
        ///</summary>
        public bool IsQgPeriod { get; set; } = false;



        /// <summary>
        /// 备  注:质保天数
        /// 默认值:
        ///</summary>
        public int QgDay { get; set; } = 0;



        /// <summary>
        /// 备  注:质保预警天数
        /// 默认值:
        ///</summary>
        public int QgAlterDay { get; set; } = 0;



        /// <summary>
        /// 备  注:质保期单位
        /// 默认值:
        ///</summary>
        public string QgAlterDayUomCode { get; set; } = string.Empty;


        /// <summary>
        /// 备  注:质保期单位名称
        /// 默认值:
        ///</summary>
        public string QgAlterDayUomName { get; set; } = string.Empty;


        /// <summary>
        /// 备  注:默认存储地点
        /// 默认值:
        ///</summary>
        public string WarehouseCode { get; set; } = string.Empty;


        /// <summary>
        /// 备  注:默认存储地点名称
        /// 默认值:
        ///</summary>
        public string WarehouseName { get; set; } = string.Empty;


        /// <summary>
        /// 备  注:标准包装数量
        /// 默认值:
        ///</summary>
        public decimal PackagQty { get; set; } = 0;



        /// <summary>
        /// 备  注:最小采购量
        /// 默认值:
        ///</summary>
        public decimal MinRcvQty { get; set; } = 0;



        /// <summary>
        /// 备  注:采购周期
        /// 默认值:
        ///</summary>
        public int PurPeriod { get; set; } = 0;



        /// <summary>
        /// 备  注:供应商
        /// 默认值:
        ///</summary>
        public string SupplierCode { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:供应商名称
        /// 默认值:
        ///</summary>
        public string SupplierName { get; set; } = string.Empty;


        /// <summary>
        /// 备  注:采购周期单位
        /// 默认值:
        ///</summary>
        public string PurPeriodUomCode { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:采购周期单位名称
        /// 默认值:
        ///</summary>
        public string PurPeriodUomName { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:生产批量
        /// 默认值:
        ///</summary>
        public long MoBatch { get; set; }



        /// <summary>
        /// 备  注:生产部门
        /// 默认值:
        ///</summary>
        public string MoDeptCode { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:生产部门名称
        /// 默认值:
        ///</summary>
        public string MoDeptName { get; set; } = string.Empty;



    }
}

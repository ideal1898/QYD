using PigRunner.DTO.Basic.Pub;

namespace PigRunner.DTO.Basic
{
    /// <summary>
    /// 仓库视图
    /// </summary>
    public class WhView : PubView
    {
        /// <summary>
        /// 备  注:组织名称
        /// 默认值:
        ///</summary>
        public string OrgName { get; set; } = string.Empty;

        /// <summary>
        /// 备  注:组织
        /// 默认值:
        ///</summary>
        public string OrgCode { get; set; } = string.Empty;


        /// <summary>
        /// 备  注:是否库位
        /// 默认值:
        ///</summary>
        public string IsStoreBin { get; set; }  = string.Empty;

        /// <summary>
        /// 是否库位
        /// 默认值:
        ///</summary>
        public string StoreBinName { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:面积
        /// 默认值:
        ///</summary>
        public string Area { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:容积
        /// 默认值:
        ///</summary>
        public string Volume { get; set; } = string.Empty;



        /// <summary>
        /// 供应商
        ///</summary>
        public string SupplierCode { get; set; } = string.Empty;

        /// <summary>
        /// 供应商名称
        ///</summary>
        public string SupplierName { get; set; } = string.Empty;

        /// <summary>
        /// 客户
        ///</summary>
        public string CustomerCode { get; set; } = string.Empty;

        /// <summary>
        /// 客户名称
        ///</summary>
        public string CustomerName { get; set; } = string.Empty;


        /// <summary>
        /// 备  注:地址
        /// 默认值:
        ///</summary>
        public string Address { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:备注
        /// 默认值:
        ///</summary>
        public string Remark { get; set; } = string.Empty;



        /// <summary>
        /// 备  注:是否生效
        /// 默认值:
        ///</summary>
        public string IsEffective { get; set; } = string.Empty;

        /// <summary>
        /// 生效名称
        /// </summary>
        public string Effective { get; set; } = string.Empty;
    }
    
}
using PigRunner.DTO.Basic.Pub;

namespace PigRunner.DTO.Basic
{

    public class WhBinGroupView : PubView
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
        /// 仓库编码
        ///</summary>
        public string WhCode { get; set; } = string.Empty;

        /// <summary>
        /// 仓库名称
        ///</summary>
        public string WhName { get; set; } = string.Empty;


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
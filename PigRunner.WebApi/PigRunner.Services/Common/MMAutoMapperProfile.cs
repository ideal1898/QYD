using AutoMapper;
using PigRunner.DTO.MM.PM;
using PigRunner.Entitys.MM.PM;
using PigRunner.Public.Helpers;

namespace PigRunner.Services.Common
{
    public class MMAutoMapperProfile : Profile
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="session"></param>
        public MMAutoMapperProfile()
        {
            

            #region 生产订单
            CreateMap<MOView, MO>()
                 .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(src => src.id > 0 ? (!string.IsNullOrEmpty(src.CreatedTime) ? DateTime.Now : DateTime.Parse(src.CreatedTime)) : DateTime.Now))
               .ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.SysVersion, opt => opt.Ignore())
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.id > 0 ? src.id : IdGeneratorHelper.GetNextId()))
               .ForMember(dest => dest.DocNo, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.DocNo) ? src.DocNo : $"MO{DateTime.Now.ToString("yyyyMMddHHss")}"))
               .ReverseMap()
               .ForPath(dest => dest.id, opt => opt.MapFrom(src => src.ID))
               .ForPath(dest => dest.OrgCode, opt => opt.MapFrom(src => src.Organization != null ? src.Organization.Code : ""))
               .ForPath(dest => dest.OrgName, opt => opt.MapFrom(src => src.Organization != null ? src.Organization.Name : ""))

               .ForPath(dest => dest.MoDeptCode, opt => opt.MapFrom(src => src.MODepartment != null ? src.MODepartment.Code : ""))
               .ForPath(dest => dest.MoDeptName, opt => opt.MapFrom(src => src.MODepartment != null ? src.MODepartment.Name : ""))

               .ForPath(dest => dest.BusinessPersonCode, opt => opt.MapFrom(src => src.Operators != null ? src.Operators.Code : ""))
               .ForPath(dest => dest.BusinessPersonName, opt => opt.MapFrom(src => src.Operators != null ? src.Operators.Name : ""))

                 .ForPath(dest => dest.CompleteWhCode, opt => opt.MapFrom(src => src.WH != null ? src.WH.Name : ""))
               .ForPath(dest => dest.CompleteWhName, opt => opt.MapFrom(src => src.WH != null ? src.WH.Name : ""))
                 ;
            CreateMap<MOLineView, MOLine>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.id > 0 ? src.id : IdGeneratorHelper.GetNextId()))
                .ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(src => DateTime.Now))
                .ReverseMap()
                .ForPath(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForPath(dest => dest.ItemCode, opt => opt.MapFrom(src => src.ItemMaster != null ? src.ItemMaster.Code : ""))
                .ForPath(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemMaster != null ? src.ItemMaster.Name : ""))
                .ForPath(dest => dest.ItemSpecs, opt => opt.MapFrom(src => src.ItemMaster != null ? src.ItemMaster.SPECS : ""))
                  .ForPath(dest => dest.MoUomCode, opt => opt.MapFrom(src => src.Uom != null ? src.Uom.Code : ""))
                .ForPath(dest => dest.MoUomName, opt => opt.MapFrom(src => src.Uom != null ? src.Uom.Name : ""))
                 .ForPath(dest => dest.LotCode, opt => opt.MapFrom(src => src.Lot != null ? src.Lot.LotCode : ""))
                ;

            #endregion
        }
    }
}

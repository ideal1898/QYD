// PMAutoMapperProfile.cs （假设在合适的命名空间下）
using AutoMapper;
using PigRunner.DTO.SCM.INV;
using PigRunner.Entitys.SCM.INV;



namespace PigRunner.Services.Common
{
    public class INVAutoMapperProfile : Profile
    {
        public INVAutoMapperProfile()
        {
            // 其他已有的映射配置...

            // 添加CheckDiffBill的映射配置
            CreateMap<CheckDiffBill, CheckDiffBillView>().ReverseMap();
        }
    }
}

using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class MedicineProfile : Profile
    {
        public MedicineProfile()
        {
            CreateMap<Medicine, MedicineDto>()
                .ForMember(dto => dto.Instructions, opt => opt.MapFrom(model => model.Instructions));

            CreateMap<MedicineDto, Medicine>()
                .ForMember(dto => dto.Instructions, opt => opt.MapFrom(model => model.Instructions));

            CreateMap<MedicineModel, MedicineDto>()
                .ForMember(dto => dto.Instructions, opt => opt.MapFrom(model => model.LinkToInstructions));
        }
    }
}
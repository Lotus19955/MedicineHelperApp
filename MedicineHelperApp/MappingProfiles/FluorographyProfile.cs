using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class FluorographyProfile : Profile
    {
        public FluorographyProfile()
        {
            CreateMap<Fluorography, FluorographyDto>()
                .ForMember(dto => dto.ClinicDto, opt => opt.MapFrom(fluorography => fluorography.Clinic));

            CreateMap<FluorographyModel, FluorographyDto>()
                .ForMember(dto => dto.ClinicDtoId, opt => opt.MapFrom(model => model.ClinicId))
                .ForMember(dto => dto.UserDtoId, opt => opt.MapFrom(model => model.UserId));

            CreateMap<FluorographyDto, Fluorography>()
                .ForMember(entity => entity.UserId, opt => opt.MapFrom(dto => dto.UserDtoId))
                .ForMember(entity => entity.ClinicId, opt => opt.MapFrom(dto => dto.ClinicDtoId));
        }
    }
}
using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class ConclusionProfile : Profile
    {
        public ConclusionProfile()
        {
            CreateMap<Conclusion, ConclusionDto>()
                .ForMember(dto => dto.ClinicDtoId, opt => opt.MapFrom(conc => conc.ClinicId))
                .ForMember(dto => dto.ClinicDto, opt => opt.MapFrom(conc => conc.Clinic))
                .ForMember(dto => dto.DateOfConclusion, opt => opt.MapFrom(conc => conc.DateOfConclusion));

            CreateMap<ConclusionModel, ConclusionDto>()
                .ForMember(dto => dto.ClinicDtoId, opt => opt.MapFrom(model => model.ClinicId))
                .ForMember(dto => dto.DateOfConclusion, opt => opt.MapFrom(model => model.DateOfConclusion));
            CreateMap<ConclusionDto, ConclusionModel>()
                .ForMember(dto => dto.ClinicId, opt => opt.MapFrom(model => model.ClinicDtoId))
                .ForMember(dto => dto.DateOfConclusion, opt => opt.MapFrom(model => model.DateOfConclusion));

            CreateMap<ConclusionDto, Conclusion>()
                .ForMember(entity => entity.ClinicId, opt => opt.MapFrom(dto => dto.ClinicDtoId))
                .ForMember(entity => entity.Clinic, opt => opt.MapFrom(dto => dto.ClinicDto))
                .ForMember(entity => entity.DateOfConclusion, opt => opt.MapFrom(dto => dto.DateOfConclusion));

        }
    }
}
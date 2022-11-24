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
                .ForMember(dto => dto.ClinicDto, opt => opt.MapFrom(conc => conc.Clinic));

            CreateMap<ConclusionModel, ConclusionDto>()
                .ForMember(dto => dto.ClinicDtoId, opt => opt.MapFrom(model => model.ClinicId))
                .ForMember(dto => dto.AppointmentId, opt => opt.MapFrom(model => model.AppointmentId));

            CreateMap<ConclusionDto, Conclusion>()
                .ForMember(entity => entity.ClinicId, opt => opt.MapFrom(dto => dto.ClinicDtoId));

        }
    }
}
using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class DoctorVisitProfile : Profile
    {
        public DoctorVisitProfile()
        {
            CreateMap<DoctorVisit, DoctorVisitDto>()
                .ForMember(dto => dto.NameOfDisease, opt => opt.MapFrom(entity => entity.DiseaseHistory.Disease.Name))
                .ForMember(dto => dto.ClinicDto, opt => opt.MapFrom(entity => entity.Clinic))
                .ForMember(dto => dto.DoctorDto, opt => opt.MapFrom(entity => entity.Doctor))
                .ForMember(dto => dto.DoctorDtoId, opt => opt.MapFrom(entity => entity.Id))
                .ForMember(dto => dto.AppointmentDto, opt => opt.MapFrom(entity => entity.Appointment));

            CreateMap<DoctorVisitModel, DoctorVisitDto>()
                .ForMember(dto => dto.ClinicDtoId, opt => opt.MapFrom(model => model.ClinicId))
                .ForMember(dto => dto.DoctorDtoId, opt => opt.MapFrom(model => model.DoctorId))
                .ForMember(dto => dto.PriceVisit, opt => opt.MapFrom(model => model.PriceVisit))
                .ForMember(dto => dto.UserDtoId, opt => opt.MapFrom(model => model.UserId));

            CreateMap<DoctorVisitDto, DoctorVisit>()
                .ForMember(entity => entity.ClinicId, opt => opt.MapFrom(dto => dto.ClinicDtoId))
                .ForMember(entity => entity.DoctorId, opt => opt.MapFrom(dto => dto.DoctorDtoId))
                .ForMember(entity => entity.UserId, opt => opt.MapFrom(dto => dto.UserDtoId));
        }
    }
}
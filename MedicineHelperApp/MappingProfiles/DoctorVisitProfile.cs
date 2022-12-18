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
                .ForMember(dto => dto.ClinicDtoId, opt => opt.MapFrom(entity => entity.ClinicId))
                .ForMember(dto => dto.ClinicDto, opt => opt.MapFrom(entity => entity.Clinic))
                .ForMember(dto => dto.DoctorDto, opt => opt.MapFrom(entity => entity.Doctor))
                .ForMember(dto => dto.DoctorDtoId, opt => opt.MapFrom(entity => entity.DoctorId))
                .ForMember(dto => dto.AppointmentDto, opt => opt.MapFrom(entity => entity.Appointment))
                .ForMember(dto => dto.UserDtoId, opt => opt.MapFrom(entity => entity.UserId));

            CreateMap<DoctorVisitModel, DoctorVisitDto>()
                .ForMember(dto => dto.ClinicDtoId, opt => opt.MapFrom(model => model.ClinicId))
                .ForMember(dto => dto.DoctorDtoId, opt => opt.MapFrom(model => model.DoctorId))
                .ForMember(dto => dto.PriceVisit, opt => opt.MapFrom(model => model.PriceVisit))
                .ForMember(dto => dto.UserDtoId, opt => opt.MapFrom(model => model.UserId));

            CreateMap<DoctorVisitDto, DoctorVisit>()
                .ForMember(dto => dto.ClinicId, opt => opt.MapFrom(entity => entity.ClinicDtoId))
                .ForMember(dto => dto.Clinic, opt => opt.MapFrom(entity => entity.ClinicDto))
                .ForMember(dto => dto.Doctor, opt => opt.MapFrom(entity => entity.DoctorDto))
                .ForMember(dto => dto.DoctorId, opt => opt.MapFrom(entity => entity.DoctorDtoId))
                .ForMember(dto => dto.Appointment, opt => opt.MapFrom(entity => entity.AppointmentDto))
                .ForMember(dto => dto.UserId, opt => opt.MapFrom(entity => entity.UserDtoId));

        }
    }
}
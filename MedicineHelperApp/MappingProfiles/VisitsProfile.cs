using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class VisitsProfile : Profile
    {
        public VisitsProfile()
        {
            CreateMap<Visit, VisitDto>();
            CreateMap<VisitDto, Visit>();

            CreateMap<VisitDto, VisitModel>();
            CreateMap<VisitModel, VisitDto>();

            //CreateMap<VisitDto, VisitHumanReadableModel>()
            //    .ForMember(ent => ent.Doctor,
            //        opt
            //            => opt.MapFrom(dto => $"{dto.Doctor.Specialization.Name} " +
            //                                  $"{dto.Doctor.DoctorPersonalData.FullName} " +
            //                                  $"at {dto.Doctor.Clinic.Name}, {dto.Doctor.Clinic.Address}"));

            //CreateMap<VisitDto, VisitFullModel>()
            //    .ForMember(ent => ent.Doctor,
            //        opt
            //            => opt.MapFrom(dto => $"{dto.Doctor.Specialization.Name} " +
            //                                  $"{dto.Doctor.DoctorPersonalData.FullName} " +
            //                                  $"at {dto.Doctor.Clinic.Name}, {dto.Doctor.Clinic.Address}"));
        }
    }
}
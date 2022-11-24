using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class MedicineСheckupProfile:Profile
    {
        public MedicineСheckupProfile()
        {
            CreateMap<MedicineСheckup, MedicineСheckupDto>();

            CreateMap<MedicineСheckupModel, MedicineСheckupDto>()
                .ForMember(dto => dto.ClinicId, opt => opt.MapFrom(model => model.ClinicId))
                .ForMember(dto => dto.AppointmentId, opt => opt.MapFrom(model => model.AppointmentId));

            CreateMap<MedicineСheckupDto, MedicineСheckup>();
        }
    }
}
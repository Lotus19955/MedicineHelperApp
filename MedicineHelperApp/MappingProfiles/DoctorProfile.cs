using AutoMapper;
using MedicineHelperApp.Models;
using MedicineHelper.DataBase.Entities;
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelperApp.MappingProfiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorDto>();

            CreateMap<DoctorModel, DoctorDto>();

            CreateMap<DoctorDto, DoctorModel>();

            CreateMap<DoctorDto, Doctor>();
        }
    }
}
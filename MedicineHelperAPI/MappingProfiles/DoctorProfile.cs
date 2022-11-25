﻿using AutoMapper;
using MedicineHelper.DataBase.Entities;
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelperApp.MappingProfiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorDto>();

            //CreateMap<DoctorModel, DoctorDto>();

            CreateMap<DoctorDto, Doctor>();
        }
    }
}
using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class MedicinePrescriptionProfile : Profile
    {
        public MedicinePrescriptionProfile()
        {
            CreateMap<MedicinePrescription, MedicinePrescriptionDto>()
                .ForMember(dto => dto.MedicinesDto, opt => opt.MapFrom(entity => entity.Medicine));

            CreateMap<MedicinePrescriptionDto, MedicinePrescription>()
                .ForMember(dto => dto.Medicine, opt => opt.MapFrom(entity => entity.MedicinesDto));

            CreateMap<MedicinePrescriptionModel, MedicinePrescriptionDto>();

            CreateMap<MedicinePrescriptionDto, MedicinePrescriptionModel>();
        }
    }
}
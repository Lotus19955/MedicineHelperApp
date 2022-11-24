using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelperApp.MappingProfiles
{
    public class MedicinePrescriptionProfile : Profile
    {
        public MedicinePrescriptionProfile()
        {
            CreateMap<MedicinePrescription, MedicinePrescriptionDto>()
                .ForMember(dto => dto.MedicinesDto, opt => opt.MapFrom(entity => entity.Medicine));
        }
    }
}
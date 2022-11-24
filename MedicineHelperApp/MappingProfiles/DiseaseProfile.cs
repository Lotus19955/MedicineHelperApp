using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class DiseaseProfile:Profile
    {
        public DiseaseProfile()
        {
            CreateMap<Disease, DiseaseDto>();

            CreateMap<DiseaseModel, DiseaseDto>();

            CreateMap<DiseaseDto, Disease>();
        }
    }
}
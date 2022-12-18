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

            CreateMap<Disease, DiseaseDto>()
                .ForMember(dto => dto.NameOfDisease, opt => opt.MapFrom(entity => entity.Name))
                .ForMember(dto => dto.ShotDescriptionDisease, opt => opt.MapFrom(entity => entity.DiseaseHistory));

            CreateMap<DiseaseModel, DiseaseDto>();

            CreateMap<DiseaseDto, Disease>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(entity => entity.NameOfDisease))
                .ForMember(dto => dto.Description, opt => opt.MapFrom(entity => entity.ShotDescriptionDisease));
        }
    }
}
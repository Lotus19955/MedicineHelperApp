using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class DiseaseHistoryProfile : Profile
    {
        public DiseaseHistoryProfile()
        {
            CreateMap<DiseaseHistory, DiseaseHistoryDto>()
                .ForMember(dto => dto.NameOfDisease, opt => opt.MapFrom(entity => entity.Disease.Name));
            CreateMap<DiseaseHistoryDto, DiseaseHistory>();

            CreateMap<DiseaseHistoryModel, DiseaseHistoryDto>()
                .ForMember(dto => dto.SeverityOfTheIllness, opt => opt.MapFrom(entity => entity.SeverityOfTheIllnessList));

            CreateMap<DiseaseHistoryDto, DiseaseHistoryModel>()
                .ForMember(dto => dto.SeverityOfTheIllnessList, opt => opt.MapFrom(entity => entity.SeverityOfTheIllness));
        }
    }
}
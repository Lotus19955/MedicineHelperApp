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

            CreateMap<DiseaseHistoryModel, DiseaseHistoryDto>();

            CreateMap<DiseaseHistoryDto, DiseaseHistory>();
        }
    }
}
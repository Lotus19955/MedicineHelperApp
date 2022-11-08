using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class VaccinationProfile : Profile
    {
        public VaccinationProfile()
        {
            CreateMap<Vaccination, VaccinationDto>();
            CreateMap<VaccinationDto, Vaccination>();

            CreateMap<VaccinationDto, VaccinationModel>();
            CreateMap<VaccinationModel, VaccinationDto>();

            //not good practice
            CreateMap<AddVaccinationModel, VaccinationDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(vaccination => Guid.NewGuid()));
        }
    }
}
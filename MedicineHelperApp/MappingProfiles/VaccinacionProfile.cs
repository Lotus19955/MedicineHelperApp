using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class VaccinacionProfile : Profile
    {
        public VaccinacionProfile()
        {
            CreateMap<Vaccination, VaccinationDto>();

            CreateMap<VaccinationModel, VaccinationDto>();

            CreateMap<VaccinationDto, Vaccination>();
        }
    }
}
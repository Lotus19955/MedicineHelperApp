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
            CreateMap<Vaccination, VaccinationDto>()
                .ForMember(dto => dto.VaccineCountry, opt => opt.MapFrom(model => model.VaccineProducingCountry))
                .ForMember(dto => dto.ClinicDto, opt => opt.MapFrom(model => model.Clinic));


            CreateMap<VaccinationModel, VaccinationDto>()
                .ForMember(dto => dto.VaccineCountry, opt => opt.MapFrom(model => model.VaccineCountry))
                .ForMember(dto => dto.VacineSeria, opt => opt.MapFrom(model => model.VaccineSeria));

            CreateMap<VaccinationModel, VaccinationDto>()
                .ForMember(dto => dto.VaccineCountry, opt => opt.MapFrom(model => model.VaccineCountry))
                .ForMember(dto => dto.VacineSeria, opt => opt.MapFrom(model => model.VaccineSeria))
                .ForMember(dto => dto.ApplicationOfVaccine, opt => opt.MapFrom(model => model.ApplicationOfVaccine));

            CreateMap<VaccinationDto, Vaccination>()
                .ForMember(dto => dto.Clinic, opt => opt.MapFrom(model => model.ClinicDto))
                .ForMember(dto => dto.VaccineProducingCountry, opt => opt.MapFrom(model => model.VaccineCountry));
        }
    }
}
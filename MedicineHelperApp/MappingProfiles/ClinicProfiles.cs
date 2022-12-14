using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class ClinicProfiles : Profile
    {
        public ClinicProfiles()
        {
            CreateMap<Clinic, ClinicDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(clin => clin.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(clin => clin.Name))
                .ForMember(dto => dto.Adress, opt => opt.MapFrom(clin => clin.Adress))
                .ForMember(dto => dto.OperatingMode, opt => opt.MapFrom(clin => clin.OperatingMode))
                .ForMember(dto => dto.Contact, opt => opt.MapFrom(clin => clin.Contact));

            CreateMap<ClinicModel, ClinicDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(clin => clin.NameClinic));
            CreateMap<ClinicDto, ClinicModel>()
                .ForMember(model => model.NameClinic, opt => opt.MapFrom(clin => clin.Name));

            CreateMap<ClinicDto, Clinic>();
        }
    }
}
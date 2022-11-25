using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperWebAPI.Models.Requests;

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

            CreateMap<AddOrUpdateClinicRequestModel, ClinicDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(clin => clin.ClinicId))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(clin => clin.ClinicName));

            CreateMap<ClinicDto, Clinic>();
        }
    }
}
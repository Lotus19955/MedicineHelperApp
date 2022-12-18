using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class MedicineСheckupProfile:Profile
    {
        public MedicineСheckupProfile()
        {
            CreateMap<MedicineСheckup, MedicineСheckupDto>()
                .ForMember(dto => dto.ClinicDto, opt => opt.MapFrom(model => model.Clinic))
                .ForMember(dto => dto.ClinicDtoId, opt => opt.MapFrom(model => model.ClinicId));

            CreateMap<MedicineСheckupModel, MedicineСheckupDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(model => model.NameOfMedicalCheckUp))
                .ForMember(dto => dto.PriceOfMedicineСheckup, opt => opt.MapFrom(model => model.PriceOfMedicalCheckUp))
                .ForMember(dto => dto.ClinicDtoId, opt => opt.MapFrom(model => model.ClinicId));

            CreateMap<MedicineСheckupDto, MedicineСheckupModel>()
                .ForMember(dto => dto.NameOfMedicalCheckUp, opt => opt.MapFrom(model => model.Name))
                .ForMember(dto => dto.PriceOfMedicalCheckUp, opt => opt.MapFrom(model => model.PriceOfMedicineСheckup))
                .ForMember(dto => dto.ClinicId, opt => opt.MapFrom(model => model.ClinicDtoId));

            CreateMap<MedicineСheckupDto, MedicineСheckup>()
                .ForMember(dto => dto.Clinic, opt => opt.MapFrom(model => model.ClinicDto))
                .ForMember(dto => dto.ClinicId, opt => opt.MapFrom(model => model.ClinicDtoId));
        }
    }
}
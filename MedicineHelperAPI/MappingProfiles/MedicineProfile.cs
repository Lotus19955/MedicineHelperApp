using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperWebAPI.Models.Requests;

namespace MedicineHelperWebAPI.MappingProfiles
{
    public class MedicineProfile : Profile
    {
        public MedicineProfile()
        {
            CreateMap<Medicine, MedicineDto>()
                .ForMember(dto => dto.MedicinePrescriptionDto, opt => opt.MapFrom(entities => entities.MedicinePrescription));

            CreateMap<MedicineDto, Medicine>();

            CreateMap<AddOrUpdateClinicRequestModel, MedicineDto>();
        }
    }
}
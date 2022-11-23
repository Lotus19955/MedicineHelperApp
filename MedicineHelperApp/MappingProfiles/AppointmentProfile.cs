using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelperApp.MappingProfiles
{
    public class AppointmentProfile:Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(opt => opt.Id))
                .ForMember(dto => dto.DescriptionOfDestination, opt => opt.MapFrom(entity => entity.DescriptionOfDestination))
                .ForMember(dto => dto.MedicinePrescriptionDto, opt => opt.MapFrom(entity => entity.MedicinePrescription))
                .ForMember(dto => dto.ConclusionDto, opt => opt.MapFrom(entity => entity.Conclusion))
                .ForMember(dto => dto.MedicineProcedureDto, opt => opt.MapFrom(entity => entity.MedicineProcedure))
                .ForMember(dto => dto.MedicinePrescriptionDto, opt => opt.MapFrom(entity => entity.MedicinePrescription));
        }
    }
}
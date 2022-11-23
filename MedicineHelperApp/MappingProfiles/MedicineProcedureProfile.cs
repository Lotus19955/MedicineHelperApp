using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class MedicineProcedureProfile : Profile
    {
        public MedicineProcedureProfile()
        {
            CreateMap<MedicineProcedureModel, MedicineProcedureDto>()
                .ForMember(dto => dto.AppointmentId, opt => opt.MapFrom(model => model.AppointmentId));

            CreateMap<MedicineProcedureDto, MedicineProcedure>();

            CreateMap<MedicineProcedure, MedicineProcedureDto>()
                .ForMember(dto => dto.ClinicDto, opt => opt.MapFrom(entity => entity.Clinic));
        }

    }
}
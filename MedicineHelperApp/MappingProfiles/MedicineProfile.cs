using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelperApp.MappingProfiles
{
    public class MedicineProfile : Profile
    {
        public MedicineProfile()
        {
            CreateMap<Medicine, MedicineDto>();

            CreateMap<MedicineDto, Medicine>();
        }
    }
}
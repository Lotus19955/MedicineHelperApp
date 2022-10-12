using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entites;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles
{
    public class VisitsProfile : Profile
    {
        public VisitsProfile()
        {
            CreateMap<Visits, VisitsDto>()
                .ForMember(dto => dto.Status, opt => opt.MapFrom(visits => visits.Status)).ReverseMap();
            
            CreateMap<VisitsDto, Visits>()
              //  .ForMember(visits => visits.CurrenciesId, opt
              //=> opt.MapFrom(visits => new Guid("6D105994-4170-43B6-A3C7-101C482D569C")))
            .ForMember(visits => visits.DoctorsId, opt
               => opt.MapFrom(visits => new Guid("00BC8F75-2353-4134-9598-8E33F845E9B2")))
            .ForMember(visits => visits.UsersId, opt
               => opt.MapFrom(visits => new Guid("9E489D82-21A0-4564-87E4-714C73A2A0E2")));

            CreateMap<VisitsDto, VisitsModel>().ReverseMap();
        }
    }
}
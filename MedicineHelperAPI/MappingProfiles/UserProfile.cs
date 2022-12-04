using AutoMapper;
using MedicineHelper.DataBase.Entities;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperApp.Models;
using MedicineHelperWebAPI.Models.Requests;

namespace MedicineHelperWebAPI.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dto => dto.RoleName, opt => opt.MapFrom(entity => entity.Role.Name))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(entity => entity.Id));

            CreateMap<UserDto, User>()
                .ForMember(ent => ent.Id,opt => opt.MapFrom(dto => Guid.NewGuid()))
            .ForMember(ent => ent.RegistrationDate,opt => opt.MapFrom(dto => DateTime.Now));

            CreateMap<RegisterUserRequestModel, UserDto>()
                .ForMember(ent => ent.Id, opt => opt.MapFrom(dto => Guid.NewGuid()));
                


        }
    }
}
using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelper.Models;
using MedicineHelperApp.Models;

namespace MedicineHelperApp.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ForMember(dto => dto.RoleName,
            opt
                => opt.MapFrom(entity => entity.Role.Name));

        CreateMap<UserDto, User>()
            .ForMember(ent => ent.Id, opt => opt.MapFrom(dto => Guid.NewGuid()))
            .ForMember(ent => ent.RegistrationDate, opt => opt.MapFrom(dto => DateTime.Now));

        CreateMap<RegisterModel, UserDto>();

        CreateMap<LoginModel, UserDto>();

        CreateMap<UserDto, UserDataModel>();
    }
}

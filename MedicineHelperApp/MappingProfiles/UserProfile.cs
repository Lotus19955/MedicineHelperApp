using AutoMapper;
using MedicineHelperApp.Models;
using MedicineHelper.DataBase.Entities;
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelperApp.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dto => dto.RoleName, opt => opt.MapFrom(entity => entity.Role.Name))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(entity => entity.Id));

            CreateMap<RegisterModel, UserDto>()
                .ForMember(dto => dto.Email, opt => opt.MapFrom(model => model.Email))
                .ForMember(dto => dto.Password, opt => opt.MapFrom(model => model.Password));

            CreateMap<UserDto, User>();

            CreateMap<UserDto, UserModel>();

            CreateMap<UserModel, UserDto>();
        }
    }
}
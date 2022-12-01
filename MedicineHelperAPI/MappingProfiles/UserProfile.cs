using AutoMapper;
using MedicineHelper.DataBase.Entities;
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelperWebAPI.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dto => dto.RoleName, opt => opt.MapFrom(entity => entity.Role.Name))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(entity => entity.Id));

            //CreateMap<RegisterModel, UserDto>()
            //    .ForMember(dto => dto.Email, opt => opt.MapFrom(model => model.Email))
            //    .ForMember(dto => dto.PasswordHash, opt => opt.MapFrom(model => model.Password));

            CreateMap<UserDto, User>();
        }
    }
}
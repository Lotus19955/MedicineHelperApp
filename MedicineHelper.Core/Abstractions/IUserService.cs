using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions;

public interface IUserService
{
    //READ
    Task<UserDto> GetUserByEmailAsync(string email);
    Task<bool> IsUserExistsAsync(Guid userId);
    Task<bool> IsUserExistsAsync(string email);
    Task<bool> CheckUserPasswordAsync(string email, string password);
    Task<bool> CheckUserPasswordAsync(Guid userId, string password);
    
    //CREATE
    Task<int> RegisterUserAsync(UserDto dto);
    
    //UPDATE
    
    //REMOVE
}
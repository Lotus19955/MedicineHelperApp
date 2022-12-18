using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IUserService
    {
        Task<bool> CheckUserPasswordAsync(string email, string password);
        Task<bool> IsUserExistAsync(string email);
        UserDto? GetUserByEmailAsync(string email);
        Task<int> RegisterUser(UserDto user, string password);
        Task<List<UserDto>> GetAllUserAsync();
        Task DeleteUserAsync(Guid id); 
        Task DeleteUserAsync(string email);
        Task<int> UpdateUserAsync(UserDto user, Guid id);
        Task<int> UpdateUserAsync(UserDto user, string email);
        Task<UserDto?> GetUserByRefreshTokenAsync(Guid token);
        Task DeleteAvatar(Guid id);
    }
}
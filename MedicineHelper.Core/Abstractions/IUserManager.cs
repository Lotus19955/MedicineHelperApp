using System.Security.Claims;
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions;

public interface IUserManager
{
    Task<UserDto> GetUserAsync();
    Task<Guid> GetUserIdAsync();
    string GetRoleName();
    bool IsUser();
    bool IsAdmin();
}
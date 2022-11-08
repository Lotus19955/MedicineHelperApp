using System.Security.Claims;

namespace MedicineHelper.Core.Abstractions;

public interface ISignInManager
{
    Task SignOutAsync();
    bool IsSignedIn(ClaimsPrincipal principal);
}
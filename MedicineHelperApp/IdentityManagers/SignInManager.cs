using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using MedicineHelper.Core.Abstractions;

namespace MedicineHelper.IdentityManagers;

public class SignInManager : ISignInManager
{
    private readonly IHttpContextAccessor _contextAccessor;
    private HttpContext _context;

    public SignInManager(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public HttpContext Context
    {
        get
        {
            var context = _context ?? _contextAccessor?.HttpContext;
            if (context == null)
            {
                throw new InvalidOperationException("HttpContext must not be null.");
            }
            return context;
        }
        set => _context = value;
    }

    public async Task SignOutAsync()
    {
        await Context.SignOutAsync();
    }

    public bool IsSignedIn(ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentNullException(nameof(principal));
        }
        return principal.Identities != null && principal.Identities
            .Any(i => i.IsAuthenticated.Equals(true));
    }
}
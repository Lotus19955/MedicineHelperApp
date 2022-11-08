using System.Security.Claims;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using System.Security.Authentication;

namespace MedicineHelper.IdentityManagers;

public class UserManager : IUserManager
{
    private readonly IHttpContextAccessor _contextAccessor;
    private HttpContext _context;
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public UserManager(IHttpContextAccessor contextAccessor, 
        IUserService userService, 
        IRoleService roleService)
    {
        _contextAccessor = contextAccessor;
        _userService = userService;
        _roleService = roleService;
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

    public async Task<UserDto> GetUserAsync()
    {
        var email = Context.User.Identity?.Name;
        if (email != null)
        {
            return await _userService.GetUserByEmailAsync(email);
        }

        throw new AuthenticationException(nameof(email));
    }

    public async Task<Guid> GetUserIdAsync()
    {
        var email = Context.User.Identity?.Name;
        if (email != null)
        {
            return (await _userService.GetUserByEmailAsync(email)).Id;
        }

        throw new AuthenticationException(nameof(email));
    }

    public string GetRoleName()
    {
        var roleClaim = Context.User.Claims
            .FirstOrDefault(claim => claim.Type
                .Equals(ClaimsIdentity.DefaultRoleClaimType));

        if (roleClaim == null)
        {
            throw new AuthenticationException(nameof(roleClaim));
        }

        return roleClaim.Value;
    }

    public bool IsUser()
    {
        var roleName = GetRoleName();
        var userRoleNameByDefault = _roleService.GetDefaultRoleNameForUser();
        return roleName.Equals(userRoleNameByDefault);
    }

    public bool IsAdmin()
    {
        var roleName = GetRoleName();
        var adminRoleNameByDefault = _roleService.GetDefaultRoleNameForAdmin();
        return roleName.Equals(adminRoleNameByDefault);
    }
}
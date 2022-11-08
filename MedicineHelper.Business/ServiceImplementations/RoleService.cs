using System.Text.Json;
using System.Xml.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Data.Abstractions;

namespace MedicineHelper.Business.ServicesImplementations;

public class RoleService : IRoleService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public RoleService(IMapper mapper, 
        IUnitOfWork unitOfWork, 
        IConfiguration configuration)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public async Task<string> GetRoleNameByIdAsync(Guid id)
    {
        var role = await _unitOfWork.Roles.GetByIdAsync(id);
        return role != null
            ? role.Name
            : string.Empty;
    }

    public async Task<Guid> GetRoleIdByNameAsync(string name)
    {
        var role = await _unitOfWork.Roles
            .FindBy(role1 =>
                role1.Name.Equals(name)).FirstOrDefaultAsync();
        if (role != null)
        {
            return role.Id;
        }
        else
        {
            throw new ArgumentException(nameof(name));
        }
    }

    public async Task<bool> IsRoleExistAsync(Guid id)
    {
        var entity = await _unitOfWork.Roles
            .Get()
            .AsNoTracking()
            .FirstOrDefaultAsync(entity =>
                entity.Id.Equals(id));
        return entity != null;
    }

    public async Task<Guid> GetRoleIdForDefaultRoleAsync()
    {
        var roleNameByDefault = GetDefaultRoleNameForUser();
        var role = await _unitOfWork.Roles
        .FindBy(role1 =>
                role1.Name.Equals(roleNameByDefault))
        .AsNoTracking().FirstOrDefaultAsync();
        if (role == null)
        {
            throw new ArgumentException(
                $"There is no entry in the database matching the default role value: {nameof(roleNameByDefault)}");
        }

        return role.Id;
    }

    public string GetDefaultRoleNameForUser()
    {
        var roleName = _configuration["RoleByDefault"];
        if (roleName == null)
        {
            throw new JsonException(
                "Failed to retrieve a valid default role value.");
        }

        return roleName;
    }

    public string GetDefaultRoleNameForAdmin()
    {
        var roleName = _configuration["RoleNameForAdmin"];
        if (roleName == null)
        {
            throw new JsonException(
                "Failed to retrieve a valid default role value for admin.");
        }

        return roleName;
    }
}
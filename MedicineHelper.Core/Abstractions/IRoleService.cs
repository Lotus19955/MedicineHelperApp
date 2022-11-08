using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions;

public interface IRoleService
{
    //READ
    Task<string> GetRoleNameByIdAsync(Guid id);
    Task<Guid> GetRoleIdByNameAsync(string name);
    Task<bool> IsRoleExistAsync(Guid id);
    Task<Guid> GetRoleIdForDefaultRoleAsync();
    string GetDefaultRoleNameForUser();
    string GetDefaultRoleNameForAdmin();

    //CREATE

    //UPDATE

    //REMOVE
}
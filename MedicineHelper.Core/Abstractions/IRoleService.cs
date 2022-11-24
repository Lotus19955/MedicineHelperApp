namespace MedicineHelper.Core.Abstractions
{
    public interface IRoleService
    {
        Task<Guid?> GetRoleIdByNameAsync(string roleName);
    }
}
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Data.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid?> GetRoleIdByNameAsync(string roleName)
        {
            var role = await _unitOfWork.Role.FindBy(roleSearch => roleSearch.Name.ToLower().Equals(roleName.ToLower())).FirstOrDefaultAsync();
            if (role == null) 
            {
                role.Name = "user";
                role.Id= Guid.NewGuid();
            }

            return role?.Id;
        }
    }
}
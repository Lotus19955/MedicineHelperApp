using System.Reflection;
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IClinicService
    {
        Task<List<ClinicDto>> GetClinicAsync();
        Task<ClinicDto> GetByIdClinicAsync(Guid id);
        Task<int> CreateClinicAsync(ClinicDto dto);
        Task<int> UpdateClinicAsync(ClinicDto dto, Guid id);
        Task DeleteClinicAsync(Guid id);
    }
}
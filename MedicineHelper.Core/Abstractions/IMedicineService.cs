using System.Reflection;
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IMedicineService
    {
        Task<List<MedicineDto>> GetAllMedicineAsync();
        Task<int> AddMedicineAsync(MedicineDto dto);
        Task<MedicineDto> GetByIdMedicineAsync(Guid id);
        Task<int> UpdateMedicineAsync(MedicineDto dto, Guid id);
        Task DeleteMedicineAsync(Guid id);
        Task AddMedicineInfoTablekaByAsync();
    }
}
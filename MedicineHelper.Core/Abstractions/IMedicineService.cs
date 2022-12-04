using System.Reflection;
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IMedicineService
    {
        Task<List<MedicineDto>> GetAllMedicineAsync();
        List<string>? SearchMedicineInTabletkaBy(string nameOfMedicine);
        Task<int> AddMedicineAsync(List<string>? listLinkMedicine);
        Task<MedicineDto> GetByIdMedicineAsync(Guid id);
        Task<int> UpdateMedicineAsync(MedicineDto dto, Guid id);
        Task DeleteMedicineAsync(Guid id);
        Task AddMedicineInfoTablekaByAsync();
    }
}
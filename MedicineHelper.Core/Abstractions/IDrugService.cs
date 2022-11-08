using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Core.Enums;

namespace MedicineHelper.Core.Abstractions;

public interface IDrugService
{
    //READ
    Task<DrugDto> GetDrugByIdAsync(Guid id);
    Task<bool> IsDrugExistAsync(string name, string unit, string producer, Guid userId);
    Task<List<DrugDto>> GetAllGlobalDrugsAsync(bool isOnlyEnabled = false);
    Task<List<DrugDto>> GetAllDrugsByUserIdAsync(Guid userId, bool isOnlyEnabled = false);

    //CREATE
    Task<int> CreateDrugAsync(DrugDto dto);

    //UPDATE
    Task<int> UpdateAsync(Guid id, DrugDto dto);
    Task<int> ChangeStatusAsync(Guid id, DrugStatus status);

    //REMOVE

}
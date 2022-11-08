using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions;

public interface IVaccineService
{
    //READ
    Task<VaccineDto> GetVaccineByIdAsync(Guid id);
    Task<bool> IsVaccineExistAsync(string name);
    Task<List<VaccineDto>> GetAllGlobalVaccinesAsync(bool isOnlyEnabled);
    Task<List<VaccineDto>> GetAllVaccinesByUserIdAsync(Guid userId, bool isOnlyEnabled = false);

    //CREATE
    Task<int> CreateVaccineAsync(VaccineDto dto);

    //UPDATE
    Task<int> UpdateAsync(Guid id, VaccineDto dto);
    Task<int> ChangeAvailabilityAsync(Guid id, bool newValue);

    //REMOVE

}
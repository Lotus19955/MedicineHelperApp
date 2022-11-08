using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions;

public interface IVaccinationStatusService
{
    //READ
    Task<VaccinationStatusDto> GetVaccinationStatusByIdAsync(Guid id);
    Task<bool> IsVaccinationStatusExistAsync(string name);
    Task<List<VaccinationStatusDto>> GetAllVaccinationStatusesAsync();

    //CREATE
    Task<int> CreateVaccinationStatusAsync(VaccinationStatusDto dto);

    //UPDATE
    Task<int> UpdateAsync(Guid id, VaccinationStatusDto dto);
    Task<int> ChangeAvailabilityAsync(Guid id, bool newValue);

    //REMOVE

}
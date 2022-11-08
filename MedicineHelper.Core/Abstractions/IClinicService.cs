using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions;

public interface IClinicService
{
    //READ
    Task<ClinicDto> GetClinicByIdAsync(Guid id);
    Task<bool> IsClinicExistAsync(string name, string address, Guid userId);
    Task<bool> IsClinicExistAsync(Guid id);
    Task<List<ClinicDto>> GetAllClinicsAsync();
    Task<List<ClinicDto>> GetAllClinicsByUserIdAsync(Guid userId);
    Task<List<ClinicDto>> GetAvailableClinicsAsync();
    Task<(string, string)> GetClinicSummaryByIdAsync(Guid id);

    //CREATE
    Task<int> CreateClinicAsync(ClinicDto dto);

    //UPDATE
    Task<int> UpdateAsync(Guid id, ClinicDto dto);
}
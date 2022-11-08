using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions;

public interface IVaccinationService
{
    //READ
    Task<VaccinationDto> GetVaccinationByIdAsync(Guid id);
    Task<bool> IsVaccinationExistAsync(Guid clinicId, Guid vaccineId, Guid userId, DateTime dateOfVaccination);
    Task<List<VaccinationDto>> GetAllVaccinationsByUserIdAsync(Guid userId);

    //CREATE
    Task<int> CreateVaccinationAsync(VaccinationDto dto);

    //UPDATE
    Task<int> UpdateAsync(Guid id, VaccinationDto dto);

    //REMOVE
}
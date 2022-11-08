using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions;

public interface IClinicPhoneService
{
    //READ
    Task<ClinicPhoneDto> GetClinicPhoneByIdAsync(Guid id);
    Task<bool> IsClinicPhoneExistAsync(string number, Guid clinicId);
    Task<List<ClinicPhoneDto>> GetAllClinicPhonesByClinicIdAsync(Guid clinicId);

    //CREATE
    Task<int> CreateClinicPhoneAsync(ClinicPhoneDto dto);

    //UPDATE
    Task<int> UpdateClinicPhoneAsync(ClinicPhoneDto clinicPhoneDto);
    Task<int> PatchAsync(Guid id, List<PatchModel> patchList);

    //REMOVE
    Task<int> DeleteAsync(ClinicPhoneDto dto);
}
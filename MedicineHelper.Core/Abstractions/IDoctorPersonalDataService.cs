using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions;

public interface IDoctorPersonalDataService
{
    //READ
    Task<DoctorPersonalDataDto> GetDoctorPersonalDataByIdAsync(Guid id);
    Task<bool> IsDoctorPersonalDataExistAsync(string name);
    Task<bool> IsDoctorPersonalDataExistAsync(Guid id);
    Task<List<DoctorPersonalDataDto>> GetAllDoctorPersonalDataAsync();
    Task<List<DoctorPersonalDataDto>> GetAllDoctorPersonalDataByUserIdAsync(Guid userId);
    Task<DoctorPersonalDataDto> GetDoctorPersonalDataSummaryByIdAsync(Guid id);

    //CREATE
    Task<int> CreateDoctorPersonalDataAsync(DoctorPersonalDataDto dto);

    //UPDATE
    Task<int> UpdateAsync(Guid id, DoctorPersonalDataDto dto);

    //REMOVE
    Task<int> RemoveAsync(Guid id);
}
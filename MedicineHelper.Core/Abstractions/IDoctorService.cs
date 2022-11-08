using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions;

public interface IDoctorService
{
    //READ
    Task<DoctorDto> GetDoctorByIdAsync(Guid id);
    Task<bool> IsDoctorExistAsync(Guid id);
    Task<bool> IsDoctorExistAsync(DoctorDto dto);
    Task<bool> IsDoctorExistAsync(Guid doctorPersonalDataId, 
        Guid specializationId, Guid clinicId, Guid userId);

    Task<List<DoctorDto>> GetAllDoctorsAsync();
    Task<List<DoctorDto>> GetAllDoctorsByUserIdAsync(Guid userId, Guid clinicId = default,
        Guid specializationId = default);

    //CREATE
    Task<int> CreateDoctorAsync(DoctorDto dto);

    //UPDATE
    Task<int> UpdateAsync(Guid id, DoctorDto dto);

    //REMOVE
    Task<int> RemoveAsync(Guid id);
}
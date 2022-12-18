using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IDoctorService
    {
        Task<List<DoctorDto>> GetAllDoctorAsync();
        Task<int> CreateDoctorAsync(DoctorDto dto);
        Task Delete(Guid id);
        Task<DoctorDto> GetByIdDoctorAsync(Guid id);
        Task<int> UpdateDoctorAsync(DoctorDto dto, Guid id);
    }
}
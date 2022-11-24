using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IDoctorService
    {
        Task<List<DoctorDto>> GetAllDoctorAsync();
        Task<int> CreateDoctorAsync(DoctorDto dto);
    }
}
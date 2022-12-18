using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IMedicineСheckupService
    {
        Task<List<MedicineСheckupDto>> GetAllMedicineСheckupAsync(Guid userId);
        Task<int> CreateMedicineСheckupAsync(MedicineСheckupDto dto);
        Task DeleteMedicineСheckup(Guid id);
        Task<List<MedicineСheckupDto>> GetPeriodMedicineСheckupAsync(DateTime SearchDateStart, DateTime SearchDateEnd, Guid userId);
    }
}
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IDiseaseHistoryService
    {
        Task<List<DiseaseHistoryDto>> GetAllDiseaseHistoryForUserAsync(Guid userId);
        Task<List<DiseaseDto>> GetAllDiseaseAsync();
        Task<int> CreateDiseaseHistoryAsync(DiseaseHistoryDto dto);
        Task<int> CreateDiseaseAsync(DiseaseDto dto);
        Task DeleteDiseaseHistory(Guid id);
        Task<List<DiseaseHistoryDto>> GetAllDiseaseHistoryForUserAsyncForPeriod(DateTime SearchDateStart, DateTime SearchDateEnd, Guid userId);
    }
}
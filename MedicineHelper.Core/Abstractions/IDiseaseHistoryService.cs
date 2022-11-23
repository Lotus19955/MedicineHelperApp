using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IDiseaseHistoryService
    {
        Task<List<DiseaseHistoryDto>> GetAllDiseaseHistoryAsync(Guid userId);
        Task<List<DiseaseDto>> GetAllDiseaseAsync();
        Task<int> CreateDiseaseHistoryAsync(DiseaseHistoryDto dto);
        Task<int> CreateDiseaseAsync(DiseaseDto dto);
    }
}
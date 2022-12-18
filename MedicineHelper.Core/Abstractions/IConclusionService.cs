using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IConclusionService
    {
        Task <List<ConclusionDto>> GetAllConclusionAsync(Guid id);
        Task<List<ConclusionDto>> GetPeriodConclusionAsync(DateTime SearchDateStart, DateTime SearchDateEnd, Guid userId);
        Task<int> CreateConclusionAsync(ConclusionDto conclusionDto);
        Task DeleteConclusion(Guid id);
    }
}
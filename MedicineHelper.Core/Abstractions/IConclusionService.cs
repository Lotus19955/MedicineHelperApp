using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IConclusionService
    {
        Task<IOrderedQueryable<ConclusionDto>> GetAllConclusionAsync(Guid userId);
        Task<List<ConclusionDto>> GetPeriodConclusionAsync(DateTime SearchDateStart, DateTime SearchDateEnd, Guid userId);
        Task<int> CreateConclusionAsync(ConclusionDto conclusionDto);

    }
}
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IVisitsService
    {
        Task<List<VisitsDto>> GetAllVisitsAsync();
        Task<List<VisitsDto>> GetVisitsForPeriodAsync(DateTime firstDate, DateTime secondDate);
        Task<VisitsDto> GetVisitsByIdAsync(Guid id);
        Task<int> CreateVisitAsync(VisitsDto dto);
        Task<int> PatchAsync(Guid id, List<PatchModel> patchList);
    }
}

using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IVisitsService
    {
        Task<List<VisitsDto>> GetVisitByNumber(int number, int amount);
        Task<List<VisitsDto>> GetVisitsCost(decimal cost);
    }
}

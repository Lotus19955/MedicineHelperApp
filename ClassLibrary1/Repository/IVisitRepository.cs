using MedicineHelper.DataBase.Entites;

namespace MedicineHelper.Data.Repositories.Repository
{
    public interface IVisitRepository
    {
        Task AddVisitAsync(Visits visit);
        Task AddVisitsAsync(IEnumerable<Visits> visits);
        Task<List<Visits?>> GetAllVisitAsync();
        IQueryable<Visits> GetAllVisitsAsQueryable();
        Task<Visits?> GetVisitByIdAsync(Guid id);
        Task RemoveVisitAsync(Visits visit);
        Task RemoveVisitSAsync(IEnumerable<Visits> visits);
        Task UpdateVisitAsync(Guid id, Visits visit);
    }
}
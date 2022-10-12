using MedicineHelper.Data.Repositories.Repository;
using MedicineHelper.DataBase;
using MedicineHelper.DataBase.Entites;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Data.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private readonly MedicineHelperContext _database;
        public VisitRepository(MedicineHelperContext database)
        {
            _database = database;
        }

        public async Task<Visits?> GetVisitByIdAsync(Guid id)
        {
            return await _database.Visits.FirstOrDefaultAsync(visit => visit.Id.Equals(id));
        }
        //not for regular use
        public IQueryable<Visits> GetAllVisitsAsQueryable()
        {
            return _database.Visits;
        }
        public async Task<List<Visits>> GetAllVisitAsync()
        {
            return await _database.Visits.ToListAsync();
        }

        public async Task AddVisitAsync(Visits visit)
        {
            await _database.Visits.AddAsync(visit);
        }
        public async Task AddVisitsAsync(IEnumerable<Visits> visits)
        {
            await _database.Visits.AddRangeAsync(visits);
        }

        public async Task RemoveVisitAsync(Visits visit)
        {
            _database.Visits.Remove(visit);
        }
        public async Task RemoveVisitSAsync(IEnumerable<Visits> visits)
        {
            _database.Visits.RemoveRange(visits);
        }

        public async Task UpdateVisitAsync(Guid id, Visits visit)
        {
            var entity = await _database.Visits.FirstOrDefaultAsync(visit => visit.Id.Equals(visit.Id));
            if (entity != null)
            {
                entity = visit;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _database.SaveChangesAsync();
        }

    }
}
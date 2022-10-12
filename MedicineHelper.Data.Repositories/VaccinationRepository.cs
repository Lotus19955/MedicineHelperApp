using MedicineHelper.Data.Repositories.Repository;
using MedicineHelper.DataBase;
using MedicineHelper.DataBase.Entites;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Data.Repositories
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private readonly MedicineHelperContext _database;
        public VaccinationRepository(MedicineHelperContext database)
        {
            _database = database;
        }

        public async Task<Vaccination?> GetVaccinationByIdAsync(Guid id)
        {
            return await _database.Vaccinations.FirstOrDefaultAsync(vaccination => vaccination.Id.Equals(id));
        }
        //not for regular use
        public IQueryable<Vaccination> GetAllVisitsAsQueryable()
        {
            return _database.Vaccinations;
        }
        public async Task<List<Vaccination>> GetAllVaccinationAsync()
        {
            return await _database.Vaccinations.ToListAsync();
        }

        public async Task AddVaccinationAsync(Vaccination vaccination)
        {
            await _database.Vaccinations.AddAsync(vaccination);
        }
        public async Task AddVaccinationsAsync(IEnumerable<Vaccination> vaccinations)
        {
            await _database.Vaccinations.AddRangeAsync(vaccinations);
        }

        public async Task RemoveVaccinationAsync(Vaccination vaccination)
        {
            _database.Vaccinations.Remove(vaccination);
        }
        public async Task RemoveVaccinationSAsync(IEnumerable<Vaccination> vaccinations)
        {
            _database.Vaccinations.RemoveRange(vaccinations);
        }

        public async Task UpdateVaccinationAsync(Guid id, Vaccination vaccination)
        {
            var entity = await _database.Vaccinations.FirstOrDefaultAsync(vaccination => vaccination.Id.Equals(vaccination.Id));
            if (entity != null)
            {
                entity = vaccination;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _database.SaveChangesAsync();
        }
    }
}
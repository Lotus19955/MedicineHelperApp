using MedicineHelper.Data.Abstractions;
using MedicineHelper.Data.Abstractions.Repository;
using MedicineHelper.Data.Repositories.Repository;
using MedicineHelper.DataBase;
using MedicineHelper.DataBase.Entites;

namespace MedicineHelper.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedicineHelperContext _database;
        public IAdditionalVisitRepository Visits { get; }
        public IRepository<Vaccination> Vaccinations { get; }
        public UnitOfWork(MedicineHelperContext database,
            IAdditionalVisitRepository visitRepository,
            IRepository<Vaccination> vaccinationRepository)
        {
            _database = database;
            Visits = visitRepository;
            Vaccinations = vaccinationRepository;
        }

        public async Task<int> Commit()
        {
            return await _database.SaveChangesAsync();
        }
    }
}

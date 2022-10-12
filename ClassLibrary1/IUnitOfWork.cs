
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Data.Abstractions.Repository;
using MedicineHelper.Data.Repositories.Repository;
using MedicineHelper.DataBase.Entites;

namespace MedicineHelper.Data.Abstractions
{
    public interface IUnitOfWork
    {
        //Task<int> SaveChanges(); can be named
        Task<int> Commit();
        IAdditionalVisitRepository Visits { get; }
        IRepository<Vaccination> Vaccinations { get; }
    }
}

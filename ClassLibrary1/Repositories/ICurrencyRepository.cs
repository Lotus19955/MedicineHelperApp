using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Data.Abstractions.Repositories;

//For a uniform approach and for future expansions
public interface ICurrencyRepository : IRepository<Currency>
{
    Task<bool> IsCurrencyExistAsync(string name);
}
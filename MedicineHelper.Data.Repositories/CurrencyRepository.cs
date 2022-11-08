using Microsoft.EntityFrameworkCore;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.Data.Abstractions.Repositories;
using MedicineHelper.DataBase;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Data.Repositories;

//For a uniform approach and for future expansions
public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
{
    public CurrencyRepository(MedicineHelperContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<bool> IsCurrencyExistAsync(string name)
    {
        var entity = await Get()
            .AsNoTracking()
            .FirstOrDefaultAsync(currency => currency.Name.Equals(name));
        return entity != null;
    }
}
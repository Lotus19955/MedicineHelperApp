using MedicineHelper.Core;
using MedicineHelper.Data.Abstractions.Repository;
using MedicineHelper.DataBase;
using MedicineHelper.DataBase.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedicineHelper.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IBaceEntity
    {
        protected readonly MedicineHelperContext Database;
        protected readonly DbSet<T> DbSet;

        public Repository(MedicineHelperContext database)
        {
            Database = database;
            DbSet = database.Set<T>();
        }

        //READ
        public virtual IQueryable<T> Get()
        {
            return DbSet;
        }
        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(entities => entities.Id.Equals(id));
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> searchExpression, params Expression<Func<T, object>>[] includes)
        {
            var result = DbSet.Where(searchExpression);
            if (includes.Any())
            {
                result = includes.Aggregate(result, (current, include) => current.Include(include));
            }
            return result;
        }

        //CREATE
        public virtual async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }


        //UPDATE
        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
        }
        public virtual async Task PatchAsync(Guid id, List<PatchModel> patchData)
        {
            var model = await DbSet.FirstOrDefaultAsync(entites => entites.Id.Equals(id));

            var nameValuePropertiesPairs = patchData.ToDictionary(patchModel => patchModel.PropertyName,
                patchModel => patchModel.PropertyValue);

            var dbEntityEntry = Database.Entry(model);
            dbEntityEntry.CurrentValues.SetValues(nameValuePropertiesPairs);
            dbEntityEntry.State = EntityState.Modified;
        }

        //DELETE
        public virtual void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}

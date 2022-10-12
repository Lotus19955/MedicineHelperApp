using MedicineHelper.Data.Abstractions.Repository;
using MedicineHelper.DataBase;
using MedicineHelper.DataBase.Entites;

namespace MedicineHelper.Data.Repositories
{
    public class VisitGenericRepository : Repository<Visits>, IAdditionalVisitRepository
    {
        public VisitGenericRepository(MedicineHelperContext database) : base(database)
        {
        }

        //DO YOU OWN METHOD
        public void DoCumstomMethod()
        {
            throw new NotImplementedException();
        }
    }
}

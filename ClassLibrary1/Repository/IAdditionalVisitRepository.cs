using MedicineHelper.DataBase.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.Data.Abstractions.Repository
{
    public interface IAdditionalVisitRepository : IRepository<Visits>
    {
        void DoCumstomMethod();
    }
}

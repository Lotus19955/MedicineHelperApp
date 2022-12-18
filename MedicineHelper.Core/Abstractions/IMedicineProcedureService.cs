using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IMedicineProcedureService
    {
        Task<int> CreateMedicineProcedureAsync(MedicineProcedureDto dto);
        Task<List<MedicineProcedureDto>> GetAllMedicineProcedureAsync(Guid id);
        Task Delete(Guid id);
        Task<List<MedicineProcedureDto>> GetPeriodMedicineProcedureAsync(DateTime SearchDateStart, DateTime SearchDateEnd, Guid userId);
    }
}
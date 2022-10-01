using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using System.Drawing.Text;

namespace MedicineHelper.Business.ServiceImplemintations
{
    public class VisitsService : IVisitsService
    {

        public VisitsStorage _visitsStorage;

        public VisitsService(VisitsStorage visitsStorage)
        {
            _visitsStorage = visitsStorage;
        }
        public async Task<List<VisitsDto>> GetVisitByNumber(int number, int amount)
        {
            List<VisitsDto> list;
            list = _visitsStorage.VisitsList.Skip(number * amount).Take(amount).ToList();
            return list;

        }

        public async Task<List<VisitsDto>> GetVisitsCost(decimal cost)
        {
            var list = new List<VisitsDto>();
            return list;
        }
    }
}

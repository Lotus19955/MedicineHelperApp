using MediatR;
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Data.CQS.Commands
{
    public class AddMedicineDataFromTabletkaByCommand : IRequest
    {
        public IEnumerable<MedicineDto>? Medicines;
    }
}

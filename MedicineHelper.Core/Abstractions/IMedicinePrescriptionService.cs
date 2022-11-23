using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IMedicinePrescriptionService
    {
        Task<List<MedicinePrescriptionDto>> GetAllMedicinePrescriptionAsync(Guid id);
    }
}
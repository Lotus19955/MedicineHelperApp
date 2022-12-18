using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IMedicinePrescriptionService
    {
        Task<int> CreateMedicinePrescriptionAsync(MedicinePrescriptionDto dto);
        Task DeleteMedicinePrescriptionAsync(Guid id);
        Task<List<MedicinePrescriptionDto>> GetAllMedicinePrescriptionAsync(Guid id);
        Task<List<MedicinePrescriptionDto>> GetPeriodMedicinePrescriptionAsync(DateTime SearchDateStart, DateTime SearchDateEnd, Guid userId);
    }
}
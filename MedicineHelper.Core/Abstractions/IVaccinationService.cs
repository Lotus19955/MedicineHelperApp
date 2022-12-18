using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IVaccinationService
    {
        Task<List<VaccinationDto>> GetAllVaccinationsAsync(Guid userId);
        Task<int> CreateVaccinationAsync(VaccinationDto dto);
        Task<List<VaccinationDto>> GetPeriodVaccinationsAsync(DateTime SearchDateStart, DateTime SearchDateEnd, Guid userId);
        Task Delete(Guid id);
    }
}
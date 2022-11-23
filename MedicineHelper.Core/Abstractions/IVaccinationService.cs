using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IVaccinationService
    {
        Task<List<VaccinationDto>> GetAllVaccinationsAsync(Guid userId);
        Task<int> CreateVaccinationAsync(VaccinationDto dto);
    }
}
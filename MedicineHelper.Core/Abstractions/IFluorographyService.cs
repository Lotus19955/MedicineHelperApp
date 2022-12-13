using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IFluorographyService
    {
        Task<List<FluorographyDto>> GetAllFluorographiesAsync(Guid userId);
        Task<int> CreateFluorographyAsync(FluorographyDto fluorographyDto);
        Task DeleteFluorographyAsync(Guid id);
        Task<FluorographyDto> GetFluorographyByIdAsync(Guid id);
        Task<int> UpdateFluorographyAsync(FluorographyDto dto);
        Task<List<FluorographyDto>> GetFluorographyForPeriodAsync(DateTime SearchDateStart, DateTime SearchDateEnd, Guid userId);
    }
}
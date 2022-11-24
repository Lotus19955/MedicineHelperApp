using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IFluorographyService
    {
        Task<List<FluorographyDto>> GetAllFluorographiesAsync(Guid userId);
        Task<int> CreateFluorographyAsync(FluorographyDto fluorographyDto);
    }
}
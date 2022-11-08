using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions;

public interface IVisitResultService
{
    //READ
    Task<VisitResultDto> GetVisitResultByIdAsync(Guid id);
    Task<List<VisitResultDto>> GetAllVisitResultsByVisitIdAsync(Guid visitId);

    //CREATE
    Task<int> CreateVisitResultAsync(VisitResultDto dto);

    //UPDATE
    Task<int> UpdateAsync(Guid id, VisitResultDto dto);

    //REMOVE
    Task<int> DeleteAsync(VisitResultDto dto);
}
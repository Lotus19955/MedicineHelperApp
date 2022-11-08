using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions;

public interface ISpecializationService
{
    //READ
    Task<SpecializationDto> GetSpecializationByIdAsync(Guid id);
    Task<bool> IsSpecializationExistAsync(string name);
    Task<List<SpecializationDto>> GetAllSpecializationAsync();
    Task<List<SpecializationDto>> GetAvailableSpecializationAsync();

    //CREATE
    Task<int> CreateSpecializationAsync(SpecializationDto dto);

    //UPDATE
    Task<int> UpdateAsync(Guid id, SpecializationDto dto);
    Task<int> ChangeAvailabilityAsync(Guid id, bool newValue);

    //REMOVE

}
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IVisitService
    {
        //READ
        Task<VisitDto> GetVisitByIdAsync(Guid id);
        /// <summary>
        /// Return VisitDto with all inner navigation properties such VisitResult and VisitCost and Prescriptions
        /// </summary>
        /// <param name="id">Visit Id</param>
        /// <returns>VisitDto</returns>
        Task<VisitDto> GetVisitWithAllInnerPropertiesByIdAsync(Guid id);
        Task<bool> IsVisitExistAsync(Guid doctorId, Guid userId, DateTime dateOfVisit);
        Task<List<VisitDto>> GetAllVisitsByUserIdAsync(Guid userId);

        //CREATE
        Task<int> CreateVisitAsync(VisitDto dto);

        //UPDATE
        Task<int> UpdateAsync(Guid id, VisitDto dto);

        //REMOVE
        Task<int> Remove(Guid id);
    }
}

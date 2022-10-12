using MedicineHelper.DataBase.Entites;

namespace MedicineHelper.Data.Repositories.Repository
{
    public interface IVaccinationRepository
    {
        Task AddVaccinationAsync(Vaccination vaccination);
        Task AddVaccinationsAsync(IEnumerable<Vaccination> vaccinations);
        Task<List<Vaccination?>> GetAllVaccinationAsync();
        IQueryable<Vaccination> GetAllVisitsAsQueryable();
        Task<Vaccination?> GetVaccinationByIdAsync(Guid id);
        Task RemoveVaccinationAsync(Vaccination vaccination);
        Task RemoveVaccinationSAsync(IEnumerable<Vaccination> vaccinations);
        Task UpdateVaccinationAsync(Guid id, Vaccination vaccination);
    }
}
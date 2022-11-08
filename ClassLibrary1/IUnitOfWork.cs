using MedicineHelper.Data.Abstractions.Repositories;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Data.Abstractions
{
    public interface IUnitOfWork
    {

        ICurrencyRepository Currencies { get; }
        IRepository<Clinic> Clinics { get; }
        IRepository<ClinicPhone> ClinicPhones { get; }
        IRepository<DoctorPersonalData> DoctorPersonalData { get; }
        IRepository<Doctor> Doctor { get; }
        IRepository<Drug> Drug { get; }
        IRepository<JobStatus> JobStatus { get; }
        IRepository<Visit> Visit { get; }
        IRepository<VaccinationStatus> VaccinationStatus { get; }
        IRepository<Vaccine> Vaccine { get; }
        IRepository<Vaccination> Vaccination { get; }
        IRepository<VisitResult> VisitResult { get; }
        IRepository<DoctorSpecialization> Specialization { get; }

        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }

        Task<int> Commit();
    }
}

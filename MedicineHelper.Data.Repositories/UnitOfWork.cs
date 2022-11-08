using MedicineHelper.Data.Abstractions;
using MedicineHelper.Data.Abstractions.Repositories;
using MedicineHelper.DataBase;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedicineHelperContext _dbContext;
        public ICurrencyRepository Currencies { get; }
        public IRepository<Clinic> Clinics { get; }
        public IRepository<ClinicPhone> ClinicPhones { get; }
        public IRepository<VisitResult> VisitResult { get; }
        public IRepository<DoctorSpecialization> Specialization { get; }
        public IRepository<Drug> Drug { get; }
        public IRepository<JobStatus> JobStatus { get; }
        public IRepository<Visit> Visit { get; }
        public IRepository<DoctorPersonalData> DoctorPersonalData { get; }
        public IRepository<Doctor> Doctor { get; }
        public IRepository<VaccinationStatus> VaccinationStatus { get; }
        public IRepository<Vaccine> Vaccine { get; }
        public IRepository<Vaccination> Vaccination { get; }

        public IRepository<User> Users { get; }
        public IRepository<Role> Roles { get; }

        public UnitOfWork(MedicineHelperContext dbContext,
            ICurrencyRepository currency,
            IRepository<Clinic> clinic,
            IRepository<ClinicPhone> clinicPhone,
            IRepository<DoctorSpecialization> specialization,
            IRepository<User> users,
            IRepository<Role> roles,
            IRepository<JobStatus> jobStatus,
            IRepository<DoctorPersonalData> doctorPersonalData,
            IRepository<Doctor> doctor,
            IRepository<VaccinationStatus> vaccinationStatus,
            IRepository<Vaccine> vaccine,
            IRepository<Vaccination> vaccination,
            IRepository<Visit> visit,
            IRepository<VisitResult> visitResult,
            IRepository<Drug> drug)
        {
            _dbContext = dbContext;
            Currencies = currency;
            Clinics = clinic;
            ClinicPhones = clinicPhone;
            Specialization = specialization;
            Users = users;
            Roles = roles;
            JobStatus = jobStatus;
            DoctorPersonalData = doctorPersonalData;
            Doctor = doctor;
            VaccinationStatus = vaccinationStatus;
            Vaccine = vaccine;
            Vaccination = vaccination;
            Visit = visit;
            VisitResult = visitResult;
            Drug = drug;
        }

        public async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}

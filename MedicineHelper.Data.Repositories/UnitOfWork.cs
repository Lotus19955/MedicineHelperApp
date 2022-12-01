using MedicineHelper.Data.Abstractions;
using MedicineHelper.Data.Abstractions.Repositories;
using MedicineHelper.DataBase;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedicineHelperContext _dbContext;

        public IRepository<Conclusion> Conclusion { get; }
        public IRepository<Appointment> Appointment { get; }
        public IRepository<Disease> Disease { get; }
        public IRepository<Doctor> Doctor { get; }
        public IRepository<DoctorVisit> DoctorVisit { get; }
        public IRepository<Fluorography> Fluorography { get; }
        public IRepository<MedicineСheckup> MedicineСheckup { get; }
        public IRepository<Clinic> Clinic { get; }
        public IRepository<Medicine> Medicine { get; }
        public IRepository<MedicineProcedure> MedicineProcedure { get; }
        public IRepository<MedicinePrescription> MedicinePrescription { get; }
        public IRepository<DiseaseHistory> DiseaseHistory { get; }
        public IRepository<Vaccination> Vaccination { get; }
        public IRepository<User> User { get; }
        public IRepository<Role> Role { get; }

        public UnitOfWork(MedicineHelperContext database, IRepository<Conclusion> conclusion,
            IRepository<Appointment> appointment, IRepository<Disease> disease, IRepository<Doctor> doctor,
            IRepository<DoctorVisit> doctorVisit, IRepository<Fluorography> fluorography,
            IRepository<MedicineСheckup> medicineСheckup, IRepository<Clinic> clinic,
            IRepository<Medicine> medicine, IRepository<MedicineProcedure> medicineProcedure,
            IRepository<MedicinePrescription> medicinePrescription, IRepository<DiseaseHistory> diseaseHistory,
            IRepository<User> user, IRepository<Vaccination> vaccination, IRepository<Role> role)
        {
            _dbContext = database;
            Conclusion = conclusion;
            Appointment = appointment;
            Disease = disease;
            Doctor = doctor;
            DoctorVisit = doctorVisit;
            Fluorography = fluorography;
            MedicineСheckup = medicineСheckup;
            Clinic = clinic;
            Medicine = medicine;
            MedicineProcedure = medicineProcedure;
            MedicinePrescription = medicinePrescription;
            DiseaseHistory = diseaseHistory;
            User = user;
            Vaccination = vaccination;
            Role = role;
        }

        public async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}

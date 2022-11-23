using MedicineHelper.Data.Abstractions.Repositories;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Data.Abstractions
{
    public interface IUnitOfWork
    {

        IRepository<Conclusion> Conclusion { get; }
        IRepository<Appointment> Appointment { get; }
        IRepository<Disease> Disease { get; }
        IRepository<Doctor> Doctor { get; }
        IRepository<DoctorVisit> DoctorVisit { get; }
        IRepository<Fluorography> Fluorography { get; }
        IRepository<MedicineСheckup> MedicineСheckup { get; }
        IRepository<Clinic> Clinic { get; }
        IRepository<Medicine> Medicine { get; }
        IRepository<MedicineProcedure> MedicineProcedure { get; }
        IRepository<MedicinePrescription> MedicinePrescription { get; }
        IRepository<DiseaseHistory> DiseaseHistory { get; }
        IRepository<Vaccination> Vaccination { get; }

        IRepository<User> User { get; }
        IRepository<Role> Role { get; }

        Task<int> Commit();
    }
}

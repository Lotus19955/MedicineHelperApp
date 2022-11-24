using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.DataBase
{
    public class MedicineHelperContext : DbContext
    {
        public DbSet<Conclusion> Conclusions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorVisit> DoctorVisits { get; set; }
        public DbSet<Fluorography> Fluorographies { get; set; }
        public DbSet<MedicineСheckup> MedicineСheckups { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicinePrescription> MedicinePrescriptions { get; set; }
        public DbSet<MedicineProcedure> MedicineProcedures { get; set; }
        public DbSet<DiseaseHistory> DiseaseHistores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<Role> Roles { get; set; }

        public MedicineHelperContext(DbContextOptions<MedicineHelperContext> options) : base(options)
        {

        }
    }
}
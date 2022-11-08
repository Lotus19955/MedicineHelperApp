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
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ClinicPhone> ClinicPhones { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSpecialization> Specializations { get; set; }
        public DbSet<DoctorPersonalData> DoctorPersonalDatas { get; set; }

        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionDrug> PrescriptionDrugs { get; set; }
        public DbSet<PrescriptionDrugCost> PrescriptionDrugCosts { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<VaccinationCost> VaccinationCosts { get; set; }
        public DbSet<VaccinationStatus> VaccinationStatuses { get; set; }

        public DbSet<Visit> Visits { get; set; }
        public DbSet<VisitCost> VisitCosts { get; set; }
        public DbSet<VisitResult> VisitResults { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Currency>()
                .HasIndex(c => c.Name)
                .IsUnique();

            builder.Entity<Clinic>()
                .HasIndex(clinic => new
                {
                    clinic.Name,
                    clinic.Address,
                    clinic.UserId
                })
                .IsUnique();

            builder.Entity<ClinicPhone>()
                .HasIndex(phone => new 
                { 
                    phone.Number,
                    phone.ClinicId 
                })
                .IsUnique();

            builder.Entity<Doctor>()
                .HasIndex(doctor => new
                {
                    doctor.SpecializationId,
                    doctor.DoctorPersonalDataId,
                    doctor.ClinicId,
                    doctor.UserId
                })
                .IsUnique();

            builder.Entity<Drug>()
                .HasIndex(drug => new
                {
                    drug.Name,
                    drug.Unit,
                    drug.Producer,
                    drug.UserId
                })
                .IsUnique();


            builder.Entity<Role>()
                .HasIndex(role => role.Name)
                .IsUnique();

            builder.Entity<DoctorSpecialization>()
                .HasIndex(doctorSpecialization => doctorSpecialization.Name)
                .IsUnique();

            builder.Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();

            builder.Entity<VaccinationStatus>()
                .HasIndex(vaccination => vaccination.Name)
                .IsUnique();

            builder.Entity<Visit>()
                .HasIndex(visit => new
                {
                    visit.VisitDate,
                    visit.DoctorId,
                    visit.UserId
                })
                .IsUnique();

            builder.Entity<Vaccine>()
                .HasIndex(vaccine => vaccine.PharmName)
                .IsUnique();

            builder.Entity<Vaccination>()
                .HasIndex(vaccination => new
                {
                    vaccination.DateOfVaccination,
                    vaccination.ClinicId,
                    vaccination.VaccineId,
                    vaccination.UserId
                })
                .IsUnique();

            var cascadeFKs = builder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership
                         && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(builder);
        }
        public MedicineHelperContext(DbContextOptions<MedicineHelperContext> options)
            : base(options)
        {
        }
    }
}

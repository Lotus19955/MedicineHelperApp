using MedicineHelper.DataBase.Entites;
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
        public DbSet<Currencies> Currencies{ get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<DoctorsClinicsPhones> DoctorsClinicsPhone { get; set; }
        public DbSet<DoctorsSpecializations> DoctorsSpecializations { get; set; }
        public DbSet<Medicines> Medicines { get; set; }
        public DbSet<MedicinesPrescriptionsStatuses> MedicinesPrescriptionsStatuses { get; set; }
        public DbSet<MedicinesPrescriptons> MedicinesPrescriptons { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Vaccinations> Vaccinations { get; set; }
        public DbSet<VaccinationsStatuses> VaccinationsStatuses { get; set; }
        public DbSet<Vaccines> Vaccines { get; set; }
        public DbSet<Visits> Visits { get; set; }
        public DbSet<VisitsConclusions> VisitsConclusions { get; set; }
        public DbSet<VisitsStatuses> VisitsStatuses { get; set; }

        public MedicineHelperContext(DbContextOptions<MedicineHelperContext> options)
            : base(options)
        {
        }
    }
}

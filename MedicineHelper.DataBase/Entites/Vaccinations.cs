using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.DataBase.Entites
{
    public class Vaccinations
    {
        public Guid Id { get; set; }
        public DateTime DateOfVaccination { get; set; }
        public string? Note { get; set; }

        public Guid VaccinesId { get; set; }
        public List<Vaccines> Vaccine { get; set; }

        public Guid VaccinationsStatusId { get; set; }
        public VaccinationsStatuses VaccinationsStatus { get; set; }

        public Guid UserId { get; set; }
        public Users User { get; set; }

        public Guid DoctorsId { get; set; }
        public List<Doctors> Doctor { get; set; }

        public Guid DoctorsClinicId { get; set; }
        public DoctorsClinic DoctorsClinic { get; set; }
    }
}

namespace MedicineHelper.DataBase.Entities;

    public class Vaccination : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateOfVaccination { get; set; }

        public Guid VaccinationStatusId { get; set; }
        public VaccinationStatus VaccinationStatus { get; set; }

        public Guid ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public Guid VaccineId { get; set; }
        public Vaccine Vaccine { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }

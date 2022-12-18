namespace MedicineHelper.DataBase.Entities
{
    public class Vaccination : IBaseEntity
    {
        public Guid Id { get; set; }
        public string? NameOfVaccine { get; set; }
        public DateTime DateOfVaccination { get; set; }
        public DateTime? VaccinationExpirationDate { get; set; }
        public string? ApplicationOfVaccine { get; set; }
        public string? VaccineProducingCountry { get; set; }
        public string? VacineSeria { get; set; }

        public Guid ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
namespace MedicineHelper.Core.DataTransferObjects
{
    public class VaccinationDto
    {
        public Guid Id { get; set; }
        public string? ApplicationOfVaccine { get; set; }
        public string? NameOfVaccine { get; set; }
        public string? VaccineCountry { get; set; }
        public string? VacineSeria { get; set; }
        public DateTime DateOfVaccination { get; set; }
        public DateTime? VaccinationExpirationDate { get; set; }

        public Guid UserId { get; set; }
        public Guid ClinicId { get; set; }
        public ClinicDto? ClinicDto { get; set; }
    }
}
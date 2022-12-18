using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicineHelperApp.Models
{
    public class VaccinationModel
    {
        public Guid Id { get; set; }
        public string? ApplicationOfVaccine { get; set; }
        public string? NameOfVaccine { get; set; }
        public string? VaccineCountry { get; set; }
        public string? VaccineSeria { get; set; }
        public DateTime DateOfVaccination { get; set; }
        public DateTime? VaccinationExpirationDate { get; set; }
        public Guid UserId { get; set; }
        public Guid ClinicId { get; set; }
        public SelectList ClinicList { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
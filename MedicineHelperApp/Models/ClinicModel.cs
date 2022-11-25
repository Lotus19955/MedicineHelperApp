namespace MedicineHelperApp.Models
{
    public class ClinicModel
    {
        public Guid Id { get; set; }
        public string? NameClinic { get; set; }
        public string? Adress { get; set; }
        public string? OperatingMode { get; set; }
        public string? Contact { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
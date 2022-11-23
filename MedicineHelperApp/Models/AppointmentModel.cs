namespace MedicineHelperApp.Models
{
    public class AppointmentModel
    {
        public Guid Id { get; set; }
        public string? DescriptionOfDestination { get; set; }
        public string? ReturnUrl { get; set; }
        public Guid? DoctorVisitId { get; set; }
    }
}
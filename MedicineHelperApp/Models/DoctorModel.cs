namespace MedicineHelperApp.Models
{
    public class DoctorModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public float? Rating { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
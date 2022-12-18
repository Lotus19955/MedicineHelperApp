namespace MedicineHelperApp.Models
{
    public class DiseaseModel
    {
        public Guid Id { get; set; }
        public string NameOfDisease { get; set; }
        public string? ShotDescriptionDisease { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
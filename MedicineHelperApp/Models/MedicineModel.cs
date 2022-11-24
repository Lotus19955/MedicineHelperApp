namespace MedicineHelperApp.Models
{
    public class MedicineModel
    {
        public Guid Id { get; set; }
        public string NameOfMedicine { get; set; }
        public string LinkToInstructions { get; set; }
        public string ReturnUrl { get; set; }
    }
}
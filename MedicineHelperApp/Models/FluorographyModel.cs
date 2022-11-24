using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicineHelperApp.Models
{
    public class FluorographyModel
    {
        public DateTime DataOfExamination { get; set; }
        public DateTime? EndDateOfSurvey { get; set; }
        public string NumberFluorography { get; set; }
        public bool Result { get; set; }
        public Guid UserId { get; set; }
        public Guid ClinicId { get; set; }
        public SelectList ClinicList { get; set; }
    }
}
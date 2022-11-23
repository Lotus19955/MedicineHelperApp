using MedicineHelper.Core.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicineHelperApp.Models
{
    public class DiseaseHistoryModel
    {
        public DateTime DateOfDisease { get; set; }
        public DateTime? DateOfRecovery { get; set; }
        public bool TypeOfTreatment { get; set; }
        public SeverityOfTheIllness SeverityOfTheIllnessList { get; set; }
        public string? NameOfDisease { get; set; }
        public Guid DiseaseId { get; set; }
        public SelectList DiseaseList { get; set; }
        public Guid UserId { get; set; }
        public Guid? AppointmentId { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
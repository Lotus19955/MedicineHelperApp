using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MedicineHelperApp.Models
{
    public class ConclusionModel
    {
        public string NameOfAnalysis { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfAnalysis { get; set; }
        public byte[]? ScanOfAnalysisDocument { get; set; }
        public Guid UserId { get; set; }
        public Guid? AppointmentId { get; set; }
        public Guid ClinicId { get; set; }
        public SelectList ClinicList { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
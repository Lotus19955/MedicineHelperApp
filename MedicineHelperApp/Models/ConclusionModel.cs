using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MedicineHelperApp.Models
{
    public class ConclusionModel
    {
        public Guid Id { get; set; }
        public string NameOfConclusion { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfConclusion { get; set; }
        public byte[]? ScanOfConclusionDocument { get; set; }
        public Guid UserId { get; set; }
        public Guid? AppointmentId { get; set; }
        public Guid? ClinicId { get; set; }
        public SelectList ClinicList { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
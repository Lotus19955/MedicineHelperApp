using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicineHelperApp.Models
{
    public class MedicineСheckupModel
    {
        public string NameOfMedicalCheckUp { get; set; }
        public DateTime DateOfMedicalCheckUp { get; set; }
        public decimal? PriceOfMedicalCheckUp { get; set; }
        public byte[]? ScanOfMedicalCheckUp { get; set; }
        public Guid UserId { get; set; }
        public Guid? AppointmentId { get; set; }
        public Guid ClinicId { get; set; }
        public SelectList ClinicList { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
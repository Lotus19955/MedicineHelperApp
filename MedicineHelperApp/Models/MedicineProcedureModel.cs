using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicineHelperApp.Models
{
    public class MedicineProcedureModel
    {
        public string NameOfProcedure { get; set; }
        public DateTime StartProcedure { get; set; }
        public DateTime EndProcedure { get; set; }
        public Guid UserId { get; set; }
        public Guid ClinicId { get; set; }
        public SelectList ClinicList { get; set; }
        public Guid? AppointmentId { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
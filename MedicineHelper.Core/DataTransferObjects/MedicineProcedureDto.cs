namespace MedicineHelper.Core.DataTransferObjects
{
    public class MedicineProcedureDto
    {
        public Guid Id { get; set; }
        public string? NameOfProcedure { get; set; }
        public DateTime StartProcedure { get; set; }
        public DateTime? EndProcedure { get; set; }

        public Guid UserId { get; set; }
        public Guid? AppointmentId { get; set; }
        public Guid? ClinicId { get; set; }
        public ClinicDto? ClinicDto { get; set; }
    }
}
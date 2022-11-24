namespace MedicineHelper.Core.DataTransferObjects
{
    public class ConclusionDto
    {
        public Guid Id { get; set; }
        public string? NameOfConclusion { get; set; }
        public DateTime DateOfConclusion { get; set; }
        public byte[]? ScanOfConclusionDocument { get; set; }

        public Guid UserId { get; set; }
        public Guid? AppointmentId { get; set; }
        public Guid ClinicDtoId { get; set; }
        public ClinicDto? ClinicDto { get; set; }
    }
}
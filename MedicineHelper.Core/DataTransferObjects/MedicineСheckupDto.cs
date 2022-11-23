namespace MedicineHelper.Core.DataTransferObjects
{
    public class MedicineСheckupDto
    {
        public string Name { get; set; }
        public DateTime DateOfMedicineСheckup { get; set; }
        public decimal? PriceOfMedicineСheckup { get; set; }
        public byte[]? FilesOfMedicineСheckup { get; set; }

        public Guid? UserId { get; set; }
        public Guid? AppointmentId { get; set; }
        public Guid? ClinicId { get; set; }
        public ClinicDto? ClinicDto { get; set; }
    }
}
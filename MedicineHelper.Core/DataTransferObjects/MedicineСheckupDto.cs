using Microsoft.AspNetCore.Http;


namespace MedicineHelper.Core.DataTransferObjects
{
    public class MedicineСheckupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfMedicineСheckup { get; set; }
        public decimal? PriceOfMedicineСheckup { get; set; }
        public string? Note { get; set; }

        public Guid? UserId { get; set; }
        public Guid? AppointmentId { get; set; }
        public Guid? ClinicDtoId { get; set; }
        public ClinicDto? ClinicDto { get; set; }
    }
}
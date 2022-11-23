namespace MedicineHelper.Core.DataTransferObjects
{
    public class DoctorVisitDto
    {
        public Guid Id { get; set; }
        public DateTime DateVisit { get; set; }
        public decimal PriceVisit { get; set; }

        public int DiseaseHistoryId { get; set; }
        public Guid AppointmentDtoId { get; set; }
        public AppointmentDto AppointmentDto { get; set; }
        public ClinicDto ClinicDto { get; set; }
        public Guid ClinicDtoId { get; set; }
        public DoctorDto DoctorDto { get; set; }
        public Guid DoctorDtoId { get; set; }
        public string? NameOfDisease { get; set; }
        public Guid UserDtoId { get; set; } 
    }
}
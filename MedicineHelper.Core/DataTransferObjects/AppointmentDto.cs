namespace MedicineHelper.Core.DataTransferObjects
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public string? DescriptionOfDestination { get; set; }

        public string? ReturnUrl { get; set; }
        public Guid? DoctorVisitId { get; set; }
        public Guid? TransferredDiseaseId { get; set; }
        public List<MedicineСheckupDto>? MedicineСheckupDto { get; set; }
        public List<MedicineProcedureDto>? MedicineProcedureDto { get; set; }
        public List<MedicinePrescriptionDto>? MedicinePrescriptionDto { get; set; }
        public List<ConclusionDto>? ConclusionDto { get; set; }
    }
}
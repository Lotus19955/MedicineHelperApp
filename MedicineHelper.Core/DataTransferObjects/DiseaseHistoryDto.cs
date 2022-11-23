using MedicineHelper.Core.Enums;

namespace MedicineHelper.Core.DataTransferObjects
{
    public class DiseaseHistoryDto
    {
        public int Id { get; set; }
        public DateTime DateOfDisease { get; set; }
        public DateTime? DateOfRecovery { get; set; }
        public bool TypeOfTreatment { get; set; }
        public SeverityOfTheIllness SeverityOfTheIllness { get; set; }
        public string? NameOfDisease { get; set; }
        public DiseaseDto Disease { get; set; }
        public Guid DiseaseId { get; set; }
        public Guid UserId { get; set; }
        public Guid? AppointmentId { get; set; }
    }
}
using MedicineHelper.Core.Enums;

namespace MedicineHelper.Core.DataTransferObjects
{
    public class VisitDto
    {
        public Guid Id { get; set; }
        public DateTime DateOfVisit { get; set; }

        public VisitStatus VisitStatus { get; set; }

        public Guid DoctorId { get; set; }
        public DoctorDto Doctor { get; set; }

        public Guid UserId { get; set; }

        public List<VisitResultDto> VisitResults { get; set; }
        public List<PrescriptionDto> Prescriptions { get; set; }
        public List<VisitCostDto> VisitCosts { get; set; }
    }
}

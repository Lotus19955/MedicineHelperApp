using MedicineHelper.Core.Enums;

namespace MedicineHelper.DataBase.Entities
{
    public class DiseaseHistory : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateOfDisease { get; set; }
        public DateTime? DateOfRecovery { get; set; }
        public bool BoolTypeOfTreatment { get; set; }
        public string TypeOfTreatment { get; set; }
        public SeverityOfTheIllness SeverityOfTheIllness { get; set; }

        public Disease Disease { get; set; }
        public Guid DiseaseId { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
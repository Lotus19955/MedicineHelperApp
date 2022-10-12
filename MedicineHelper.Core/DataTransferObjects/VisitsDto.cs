using MedicineHelper.Core.Enums;

namespace MedicineHelper.Core.DataTransferObjects
{
    public class VisitsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime VisitDate { get; set; }
        public decimal Cost { get; set; }
        public VisitStatusEnum Status { get; set; }
    }
}

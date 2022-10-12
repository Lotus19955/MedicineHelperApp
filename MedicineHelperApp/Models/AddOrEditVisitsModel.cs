using MedicineHelper.Core.Enums;

namespace MedicineHelperApp.Models
{
    public class AddOrEditVisitsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime VisitDate{ get; set; }
        public decimal Cost { get; set; }
        public VisitStatusEnum Status { get; set; }
        public string CreateOrEdit { get; set; }
    }
}

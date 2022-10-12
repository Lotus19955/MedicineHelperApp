using MedicineHelper.Core.Enums;
using Microsoft.Build.Framework;

namespace MedicineHelperApp.Models
{
    public class VisitsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime VisitDate { get; set; }
        public decimal Cost { get; set; }
        public VisitStatusEnum Status { get; set; }
    }
}

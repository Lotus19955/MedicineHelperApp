using  MedicineHelper.Core.Enums;

namespace MedicineHelper.DataBase.Entities;

public class Visit : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime VisitDate { get; set; }
    public VisitStatus Status { get; set; }

    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public Guid UserId { get; set; }

    public List<VisitResult> VisitConclusions { get; set; }
    public List<Prescription> Prescriptions { get; set; }
    public List<VisitCost> VisitCosts { get; set; }
}

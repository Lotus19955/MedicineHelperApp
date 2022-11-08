namespace MedicineHelper.DataBase.Entities;

public class Prescription : IBaseEntity
{
    public Guid Id { get; set; }

    public Guid VisitId { get; set; }
    public Visit Visit { get; set; }

    public List<PrescriptionDrug> PrecPrescriptionDrugs { get; set; }
}
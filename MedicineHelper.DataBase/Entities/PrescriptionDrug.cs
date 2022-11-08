namespace MedicineHelper.DataBase.Entities;

public class PrescriptionDrug : IBaseEntity
{
    public Guid Id { get; set; }
    public int Dose { get; set; }
    public int NumberOfDosesPerDay { get; set; }
    public int NumberOfTreatmentDays { get; set; }

    public Guid PrescriptionId { get; set; }
    public Prescription Prescription { get; set; }

    public Guid DrugId { get; set; }
    public Drug Drug { get; set; }

    public List<PrescriptionDrugCost> PrescriptionDrugCosts { get; set; }
}
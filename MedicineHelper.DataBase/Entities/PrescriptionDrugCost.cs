namespace MedicineHelper.DataBase.Entities;

public class PrescriptionDrugCost : IBaseEntity
{
    public Guid Id { get; set; }
    public decimal Cost { get; set; }
    
    public Guid CurrencyId { get; set; }
    public Currency Currency { get; set; }

    public Guid PrescriptionDrugId { get; set; }
    public PrescriptionDrug PrescriptionDrug { get; set; }
}
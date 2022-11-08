namespace MedicineHelper.Core.DataTransferObjects;

public class PrescriptionDrugCostDto
{
    public Guid Id { get; set; }
    public decimal Cost { get; set; }
    
    public Guid CurrencyId { get; set; }
    public CurrencyDto CurrencyDto { get; set; }

    public Guid PrescriptionDrugId { get; set; }
    public PrescriptionDrugDto PrescriptionDrugDto { get; set; }
}
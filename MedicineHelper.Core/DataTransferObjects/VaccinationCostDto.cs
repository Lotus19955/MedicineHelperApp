namespace MedicineHelper.Core.DataTransferObjects;

public class VaccinationCostDto
{
    public Guid Id { get; set; }
    public decimal Cost { get; set; }
    
    public Guid CurrencyId { get; set; }
    public CurrencyDto CurrencyDto { get; set; }
}
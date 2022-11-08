namespace MedicineHelper.Core.DataTransferObjects;

public class VisitCostDto
{
    public Guid Id { get; set; }
    public decimal Cost { get; set; }

    public Guid CurrencyId { get; set; }
    public CurrencyDto CurrencyDto { get; set; }

    public Guid VisitId { get; set; }
    public VisitDto VisitDto { get; set; }
}
namespace MedicineHelper.DataBase.Entities;

public class VisitCost : IBaseEntity
{
    public Guid Id { get; set; }
    public decimal Cost { get; set; }

    public Guid CurrencyId { get; set; }
    public Currency Currency { get; set; }

    public Guid VisitId { get; set; }
    public Visit Visit { get; set; }
}
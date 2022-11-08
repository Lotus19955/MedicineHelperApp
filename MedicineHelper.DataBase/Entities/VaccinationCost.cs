namespace MedicineHelper.DataBase.Entities;

public class VaccinationCost : IBaseEntity
{
    public Guid Id { get; set; }
    public decimal Cost { get; set; }

    public Guid CurrencyId { get; set; }
    public Currency Currency { get; set; }
}
namespace MedicineHelper.DataBase.Entities;

public class VisitResult : IBaseEntity
{
    public Guid Id { get; set; }
    public string? Note { get; set; }


    public Guid VisitsId { get; set; }
    public Visit Visit { get; set; }
}

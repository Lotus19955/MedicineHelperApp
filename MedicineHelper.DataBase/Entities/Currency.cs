namespace MedicineHelper.DataBase.Entities;

public class Currency : IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

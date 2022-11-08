namespace MedicineHelper.DataBase.Entities;
public class ClinicPhone : IBaseEntity
{
    public Guid Id { get; set; }
    public string Number { get; set; }

    public Guid ClinicId { get; set; }
    public Clinic Clinic { get; set; }
}
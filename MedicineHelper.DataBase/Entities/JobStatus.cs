namespace MedicineHelper.DataBase.Entities;

public class JobStatus : IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsEnable { get; set; }

    public List<Doctor> Doctors { get; set; }
}
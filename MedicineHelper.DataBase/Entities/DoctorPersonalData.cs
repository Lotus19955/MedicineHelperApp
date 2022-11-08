namespace MedicineHelper.DataBase.Entities;

public class DoctorPersonalData : IBaseEntity
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public Guid UserId { get; set; }

    public List<Doctor> Doctors { get; set; }
}
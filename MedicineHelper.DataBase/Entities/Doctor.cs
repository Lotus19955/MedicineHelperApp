namespace MedicineHelper.DataBase.Entities;

public class Doctor : IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public float? Rating { get; set; }

    public List<DoctorVisit> DoctorVisits { get; set; }

}
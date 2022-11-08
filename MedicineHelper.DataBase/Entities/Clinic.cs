namespace MedicineHelper.DataBase.Entities;

public class Clinic : IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public Guid UserId { get; set; }

    public List<ClinicPhone> ClinicPhones { get; set; }
    public List<Doctor> Doctors { get; set; }
    public List<Vaccination> Vaccinations { get; set; }
}
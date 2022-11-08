namespace MedicineHelper.DataBase.Entities;

public class VaccinationStatus : IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsEnable { get; set; }

    public List<Vaccination> Vaccinations { get; set; }
}
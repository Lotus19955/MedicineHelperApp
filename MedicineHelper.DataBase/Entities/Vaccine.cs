namespace MedicineHelper.DataBase.Entities;

public class Vaccine : IBaseEntity
{
    public Guid Id { get; set; }
    public string PharmName { get; set; }
    public int? EffectiveTermInDays { get; set; } // null means indefinite
    public bool IsEnable { get; set; }
    //The IsGlobal property is true when the vaccine is created by an administrator,
    //the property is set to false when it is created by a user
    public bool IsGlobal { get; set; }
    public Guid UserId { get; set; }


    // todo: create a page that contain list with all vaccinations with the current vaccine or delete this navigate property 
    public List<Vaccination> Vaccinations { get; set; }
}

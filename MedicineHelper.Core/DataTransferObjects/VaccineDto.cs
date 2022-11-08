namespace MedicineHelper.Core.DataTransferObjects;

public class VaccineDto
{
    public Guid Id { get; set; }
    public string PharmName { get; set; }
    public int? EffectiveTermInDays { get; set; } // null means indefinite
    public bool IsEnable { get; set; }
    public bool IsGlobal { get; set; }
    public Guid UserId { get; set; }

    public List<VaccinationDto> Vaccinations { get; set; }
}
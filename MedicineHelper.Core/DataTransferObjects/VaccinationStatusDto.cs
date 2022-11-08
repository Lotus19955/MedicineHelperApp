namespace MedicineHelper.Core.DataTransferObjects;

public class VaccinationStatusDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsEnable { get; set; }

    public List<VaccinationDto> Vaccinations { get; set; }
}
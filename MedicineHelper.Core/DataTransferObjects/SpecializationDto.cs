namespace MedicineHelper.Core.DataTransferObjects;

public class SpecializationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsEnable { get; set; }

    public List<DoctorDto> DoctorsDto { get; set; }
}
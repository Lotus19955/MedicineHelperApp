namespace MedicineHelper.Core.DataTransferObjects;

public class DoctorPersonalDataDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public Guid UserId { get; set; }

    public List<DoctorDto> Doctors { get; set; }
}
namespace MedicineHelper.Core.DataTransferObjects;

public class ClinicDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public Guid UserId { get; set; }

    public List<ClinicPhoneDto> ClinicPhones { get; set; }
    public List<DoctorDto> DoctorsDto { get; set; }
    public List<VaccinationDto> VaccinationsDto { get; set; }
}
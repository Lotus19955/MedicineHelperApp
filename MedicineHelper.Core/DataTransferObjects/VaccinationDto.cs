namespace MedicineHelper.Core.DataTransferObjects;

public class VaccinationDto
{
    public Guid Id { get; set; }
    public DateTime DateOfVaccination { get; set; }

    public Guid VaccinationStatusId { get; set; }
    public VaccinationStatusDto VaccinationStatus { get; set; }

    public Guid ClinicId { get; set; }
    public ClinicDto Clinic { get; set; }

    public Guid VaccineId { get; set; }
    public VaccineDto Vaccine { get; set; }

    public Guid UserId { get; set; }
    public UserDto User { get; set; }
}
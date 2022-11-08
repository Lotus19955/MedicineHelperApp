namespace MedicineHelper.Core.DataTransferObjects;

public class DoctorDto
{
    public Guid Id { get; set; }

    public Guid DoctorPersonalDataId { get; set; }
    public DoctorPersonalDataDto DoctorPersonalData { get; set; }

    public Guid SpecializationId { get; set; }
    public SpecializationDto Specialization { get; set; }

    public Guid ClinicId { get; set; }
    public ClinicDto Clinic { get; set; }

    public Guid JobStatusId { get; set; }
    public JobStatusDto JobStatus { get; set; }

    public Guid UserId { get; set; }

    public List<VisitDto> Visits { get; set; }
}
namespace MedicineHelper.DataBase.Entities;

public class Doctor : IBaseEntity
{
    public Guid Id { get; set; }

    public Guid DoctorPersonalDataId { get; set; }
    public DoctorPersonalData DoctorPersonalData { get; set; }

    public Guid SpecializationId { get; set; }
    public DoctorSpecialization Specialization { get; set; }

    public Guid ClinicId { get; set; }
    public Clinic Clinic { get; set; }

    public Guid JobStatusId { get; set; }
    public JobStatus JobStatus { get; set; }

    public Guid UserId { get; set; }

    public List<Visit> Visits { get; set; }

}

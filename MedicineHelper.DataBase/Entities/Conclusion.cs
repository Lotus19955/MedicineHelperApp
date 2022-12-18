namespace MedicineHelper.DataBase.Entities
{
    public class Conclusion : IBaseEntity
    {
        public Guid Id { get; set; }
        public string NameOfConclusion { get; set; }
        public DateTime DateOfConclusion { get; set; }
        public byte[]? ScanOfConclusionDocument { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
        public Clinic? Clinic { get; set; }
        public Guid? ClinicId { get; set; }
        public Appointment? Appointment { get; set; }
        public Guid? AppointmentId { get; set; }
        public List<DoctorVisit> DoctorVisit { get; set; }

    }
}
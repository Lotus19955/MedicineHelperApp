namespace MedicineHelper.DataBase.Entities
{
    public class Conclusion : IBaseEntity
    {
        public Guid Id { get; set; }
        public string NameOfAnalysis { get; set; }
        public DateTime DateOfAnalysis { get; set; }
        public byte[]? ScanOfAnalysisDocument { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
        public Clinic? Clinic { get; set; }
        public Guid? ClinicId { get; set; }
        public Appointment? Appointment { get; set; }
        public Guid? AppointmentId { get; set; }
    }
}
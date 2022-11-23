namespace MedicineHelper.DataBase.Entities
{
    public class MedicineProcedure : IBaseEntity
    {
        public Guid Id { get; set; }
        public string NameOfProcedure { get; set; }
        public DateTime StartProcedure { get; set; }
        public DateTime? EndProcedure { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
        public Appointment? Appointment { get; set; }
        public Guid? AppointmentId { get; set; }
        public Clinic? Clinic { get; set; }
        public Guid? ClinicId { get; set; }
    }
}
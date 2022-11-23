namespace MedicineHelper.DataBase.Entities
{
    public class MedicinePrescription : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime StartOfAdmission { get; set; }
        public DateTime EndOfAdmission { get; set; }
        public string MedicineDose { get; set; }
        public decimal? MedicinePrice { get; set; }

        public Medicine Medicine { get; set; }
        public Guid MedicineId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Appointment? Appointment { get; set; }
        public Guid? AppointmentId { get; set; }
    }
}
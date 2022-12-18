namespace MedicineHelper.DataBase.Entities
{
    public class MedicineСheckup : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfMedicineСheckup { get; set; }
        public decimal? PriceOfMedicineСheckup { get; set; }
        public string? Note { get; set; }


        public Appointment? Appointment { get; set; }
        public Guid? AppointmentId { get; set; }
        public Clinic? Clinic { get; set; }
        public Guid? ClinicId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
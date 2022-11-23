namespace MedicineHelper.DataBase.Entities
{
    public class DoctorVisit : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateVisit { get; set; }
        public decimal? PriceVisit { get; set; }

        public Appointment Appointment { get; set; }
        public Clinic? Clinic { get; set; }
        public Guid? ClinicId { get; set; }
        public Doctor Doctor { get; set; }
        public Guid DoctorId { get; set; }
        public DiseaseHistory? DiseaseHistory { get; set; }
        public Guid? DiseaseHistoryId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
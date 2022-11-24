namespace MedicineHelper.DataBase.Entities
{
    public class Fluorography : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DataOfFluorography { get; set; }
        public DateTime? EndDateOfFluorography { get; set; }
        public string NumberFluorography { get; set; }
        public bool Result { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
        public Clinic? Clinic { get; set; }
        public Guid? ClinicId { get; set; }
    }
}
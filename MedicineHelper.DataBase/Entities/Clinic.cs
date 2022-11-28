namespace MedicineHelper.DataBase.Entities
{
    public class Clinic : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string? OperatingMode { get; set; }
        public string? Contact { get; set; }
        public string? SourceClinicUrl { get; set; }
        public Guid UserId { get; set; }

        public List<DoctorVisit> DoctorVisits { get; set; }
        public List<Vaccination> Vaccinations { get; set; }
        public List<Fluorography>? Fluorographys { get; set; }
        public List<Conclusion> Analyses { get; set; }
        public List<MedicinePrescription> MedicinePrescription { get; set; }
        public List<MedicineProcedure> MedicineProcedure { get; set; }
    }
}
using MedicineHelper.Core.Enums;

namespace MedicineHelper.DataBase.Entities
{
    public class User : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegistrationDate { get; set; }
        public byte[]? Avatar { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public List<Conclusion>? Conclusion { get; set; }
        public List<DoctorVisit>? DoctorVisits { get; set; }
        public List<MedicineСheckup>? MedicineСheckup { get; set; }
        public List<Vaccination>? Vaccinations { get; set; }
        public List<Fluorography>? Fluorographies { get; set; }
        public List<DiseaseHistory>? DiseaseHistory { get; set; }
        public List<MedicinePrescription>? MedicinePrescription { get; set; }
        public List<MedicineProcedure>? MedicineProcedure { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }
    }
}

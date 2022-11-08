using MedicineHelper.Core.Enums;

namespace MedicineHelper.DataBase.Entities
{
    public class User : IBaseEntity
    {
        public Guid Id { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public List<Vaccination> Vaccinations { get; set; }
        public List<Visit> Visits { get; set; }
    }
}
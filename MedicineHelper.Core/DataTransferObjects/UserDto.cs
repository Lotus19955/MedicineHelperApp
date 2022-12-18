namespace MedicineHelper.Core.DataTransferObjects
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[]? Avatar { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public Guid RoleId { get; set; }
    }
}
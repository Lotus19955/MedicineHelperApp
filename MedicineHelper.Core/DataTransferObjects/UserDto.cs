namespace MedicineHelper.Core.DataTransferObjects;

public class UserDto
{
    public Guid Id { get; set; }

    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime RegistrationDate { get; set; }

    public Guid RoleId { get; set; }
    public string RoleName { get; set; }

}
namespace MedicineHelper.Core.DataTransferObjects;

public class RoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<UserDto> UserDtos { get; set; }
}
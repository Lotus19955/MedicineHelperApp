namespace MedicineHelperWebAPI.Models.Requests;

public class AddOrUpdateUserRequestModel
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime RegistrationDate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? FulFirst { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime? DateOfBirth { get; set; }
}
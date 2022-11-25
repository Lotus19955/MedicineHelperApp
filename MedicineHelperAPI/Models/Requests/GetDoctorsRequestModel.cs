namespace MedicineHelperWebAPI.Models.Requests;

/// <summary>
/// 
/// </summary>
public class GetDoctorsRequestModel
{
    /// <summary>
    /// 
    /// </summary>
    public Guid DoctorId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? DoctorName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? DoctorSpecialization { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public float? DoctorRating { get; set; }
}
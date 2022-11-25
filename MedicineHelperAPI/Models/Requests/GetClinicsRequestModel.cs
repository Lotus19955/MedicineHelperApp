namespace MedicineHelperWebAPI.Models.Requests;
/// <summary>
/// 
/// </summary>
public class GetClinicsRequestModel
{
    /// <summary>
    /// 
    /// </summary>
    public Guid? ClinicId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? ClinicName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Adress { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? OperatingMode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Contact { get; set; }
}
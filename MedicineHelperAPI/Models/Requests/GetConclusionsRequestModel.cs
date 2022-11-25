namespace MedicineHelperWebAPI.Models.Requests;
/// <summary>
/// 
/// </summary>
public class GetConclusionsRequestModel
{
    /// <summary>
/// 
/// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? NameOfAnalysis { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime DateOfAnalysis { get; set; }
}
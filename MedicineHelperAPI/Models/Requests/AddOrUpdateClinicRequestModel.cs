namespace MedicineHelperWebAPI.Models.Requests;

public class AddOrUpdateClinicRequestModel
{
    public Guid? ClinicId { get; set; }
    public string? ClinicName { get; set; }
    public string? Adress { get; set; }
    public string? OperatingMode { get; set; }
    public string? Contact { get; set; }
}
namespace MedicineHelperWebAPI.Models.Requests;

public class AddOrUpdateMedicineRequestModel
{
    public Guid Id { get; set; }
    public string NameOfMedicine { get; set; }
    public string? Instructions { get; set; }
}
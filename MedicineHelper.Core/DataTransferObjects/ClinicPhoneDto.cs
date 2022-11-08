namespace MedicineHelper.Core.DataTransferObjects;

public class ClinicPhoneDto
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public Guid ClinicId { get; set; }
}
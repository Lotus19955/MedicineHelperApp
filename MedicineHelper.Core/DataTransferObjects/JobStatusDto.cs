namespace MedicineHelper.Core.DataTransferObjects;

public class JobStatusDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsEnable { get; set; }
}
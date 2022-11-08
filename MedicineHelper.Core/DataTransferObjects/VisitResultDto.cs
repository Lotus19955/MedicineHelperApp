namespace MedicineHelper.Core.DataTransferObjects;

public class VisitResultDto
{
    public Guid Id { get; set; }
    public string? Note { get; set; }

    public Guid VisitId { get; set; }
}
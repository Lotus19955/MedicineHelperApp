namespace MedicineHelper.Core.DataTransferObjects;

public class PrescriptionDto
{
    public Guid Id { get; set; }

    public Guid VisitId { get; set; }
    public VisitDto VisitDto { get; set; }

    public List<PrescriptionDrugDto> PrecPrescriptionDrugDtos { get; set; }
}
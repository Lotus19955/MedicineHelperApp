namespace MedicineHelper.Core.DataTransferObjects;

public class PrescriptionDrugDto
{
    public Guid Id { get; set; }
    public int Dose { get; set; }
    public int NumberOfDosesPerDay { get; set; }
    public int NumberOfTreatmentDays { get; set; }

    public Guid PrescriptionId { get; set; }
    public PrescriptionDto PrescriptionDto { get; set; }

    public Guid DrugId { get; set; }
    public DrugDto DrugDto { get; set; }

    public List<PrescriptionDrugCostDto> PrescriptionDrugCostDtos { get; set; }
}
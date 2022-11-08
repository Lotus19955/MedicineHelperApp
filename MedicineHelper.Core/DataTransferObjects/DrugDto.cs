using MedicineHelper.Core.Enums;

namespace MedicineHelper.Core.DataTransferObjects;

public class DrugDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Producer { get; set; }
    public string Unit { get; set; }
    public string? Description { get; set; }
    //The IsGlobal property is true when the drug is created by an administrator,
    //the property is set to false when it is created by a user
    public bool IsGlobal { get; set; }
    public DrugStatus Status { get; set; }
    public Guid UserId { get; set; }
}
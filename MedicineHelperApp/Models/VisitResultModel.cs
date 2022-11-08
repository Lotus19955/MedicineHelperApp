using TheHypochondriac.Core.DataTransferObjects;

namespace TheHypochondriac.Models;

public class VisitResultModel
{
    public Guid Id { get; set; }
    public string? Note { get; set; }

    public Guid VisitId { get; set; }
}
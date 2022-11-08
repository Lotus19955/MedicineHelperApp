using TheHypochondriac.Core;
using TheHypochondriac.Core.DataTransferObjects;

namespace TheHypochondriac.Models;

public class VisitHumanReadableModel
{
    public Guid Id { get; set; }
    public DateTime DateOfVisit { get; set; }
    public VisitStatus VisitStatus { get; set; }
    public string Doctor { get; set; }
    public Guid UserId { get; set; }
}
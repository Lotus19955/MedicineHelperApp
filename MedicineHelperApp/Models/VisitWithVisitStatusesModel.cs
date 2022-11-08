using TheHypochondriac.Core;
using TheHypochondriac.Core.DataTransferObjects;

namespace TheHypochondriac.Models;

public class VisitWithVisitStatusesModel
{
    public List<VisitHumanReadableModel> Visits { get; set; }
    public VisitStatus[] VisitStatuses { get; set; }
}
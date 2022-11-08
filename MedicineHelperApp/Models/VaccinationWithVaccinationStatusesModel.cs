using TheHypochondriac.Core.DataTransferObjects;

namespace TheHypochondriac.Models;

public class VaccinationWithVaccinationStatusesModel
{
    public List<VaccinationHumanReadableModel> Vaccination { get; set; }
    public List<VaccinationStatusDto> VaccinationStatuses { get; set; }
}
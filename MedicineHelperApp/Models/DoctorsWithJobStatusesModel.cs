using TheHypochondriac.Core.DataTransferObjects;

namespace TheHypochondriac.Models;

public class DoctorsWithJobStatusesModel
{
    public List<DoctorHumanReadableModel> Doctors { get; set; }
    public List<JobStatusDto> JobStatuses { get; set; }
}
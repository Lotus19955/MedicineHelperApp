using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions;

public interface IJobStatusService
{
    //READ
    Task<JobStatusDto> GetJobStatusByIdAsync(Guid id);
    Task<bool> IsJobStatusExistAsync(string name);
    Task<List<JobStatusDto>> GetAllJobStatusesAsync();

    //CREATE
    Task<int> CreateJobStatusAsync(JobStatusDto dto);

    //UPDATE
    Task<int> UpdateAsync(Guid id, JobStatusDto dto);
    Task<int> ChangeAvailabilityAsync(Guid id, bool newValue);

    //REMOVE

}
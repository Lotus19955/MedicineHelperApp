using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Business.ServicesImplementations;

public class JobStatusService : IJobStatusService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public JobStatusService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<JobStatusDto> GetJobStatusByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.JobStatus.GetByIdAsync(id);

        if (entity != null)
        {
            var dto = _mapper.Map<JobStatusDto>(entity);
            return dto;
        }
        else
        {
            throw new ArgumentException(nameof(id));
        }
    }

    public async Task<bool> IsJobStatusExistAsync(string name)
    {
        var entity = await _unitOfWork.JobStatus
            .Get()
            .AsNoTracking()
            .FirstOrDefaultAsync(entity =>
                entity.Name.Equals(name));
        return entity != null;
    }

    public async Task<List<JobStatusDto>> GetAllJobStatusesAsync()
    {
        var list = await _unitOfWork.JobStatus
            .Get()
            .Select(entity => _mapper.Map<JobStatusDto>(entity))
            .ToListAsync();
        return list;
    }

    public async Task<int> CreateJobStatusAsync(JobStatusDto dto)
    {
        var entity = _mapper.Map<JobStatus>(dto);

        if (entity != null)
        {
            await _unitOfWork.JobStatus.AddAsync(entity);
            var addingResult = await _unitOfWork.Commit();
            return addingResult;
        }
        else
        {
            throw new ArgumentException(nameof(dto));
        }
    }

    public async Task<int> UpdateAsync(Guid id, JobStatusDto dto)
    {
        var sourceDto = await GetJobStatusByIdAsync(id);

        //should be sure that dto property naming is the same with entity property naming
        var patchList = new List<PatchModel>();
        if (dto != null)
        {
            if (!dto.Name.Equals(sourceDto.Name))
            {
                patchList.Add(new PatchModel() { PropertyName = nameof(dto.Name), PropertyValue = dto.Name });
            }
        }

        await _unitOfWork.JobStatus.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }

    public async Task<int> ChangeAvailabilityAsync(Guid id, bool newValue)
    {
        var dto = await GetJobStatusByIdAsync(id);
        var patchList = new List<PatchModel>();
        if (dto != null)
        {
            if (!dto.IsEnable.Equals(newValue))
            {
                patchList.Add(new PatchModel() { PropertyName = nameof(dto.IsEnable), PropertyValue = newValue });
            }
        }

        await _unitOfWork.JobStatus.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }
}
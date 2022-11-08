using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.CustomException;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Business.ServicesImplementations;

public class DoctorPersonalDataService : IDoctorPersonalDataService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DoctorPersonalDataService(IMapper mapper, 
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<DoctorPersonalDataDto> GetDoctorPersonalDataByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.DoctorPersonalData
            .Get()
            .Where(entity => entity.Id.Equals(id))
            .Include(entity => entity.Doctors)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (entity != null)
        {
            var dto = _mapper.Map<DoctorPersonalDataDto>(entity);
            return dto;
        }

        throw new ArgumentException(nameof(id));
    }

    public async Task<bool> IsDoctorPersonalDataExistAsync(string fullName)
    {
        var entity = await _unitOfWork.DoctorPersonalData
            .Get()
            .AsNoTracking()
            .FirstOrDefaultAsync(entity =>
                entity.FullName.Equals(fullName));
        return entity != null;
    }

    public async Task<bool> IsDoctorPersonalDataExistAsync(Guid id)
    {
        var entity = await _unitOfWork.DoctorPersonalData.GetByIdAsync(id);
        return entity != null;
    }

    public async Task<List<DoctorPersonalDataDto>> GetAllDoctorPersonalDataAsync()
    {
        var list = await _unitOfWork.DoctorPersonalData
            .Get()
            .Select(entity => _mapper.Map<DoctorPersonalDataDto>(entity))
            .ToListAsync();
        return list;
    }

    public async Task<List<DoctorPersonalDataDto>> GetAllDoctorPersonalDataByUserIdAsync(Guid userId)
    {
        var list = await _unitOfWork.DoctorPersonalData
            .Get()
            .Where(data => data.UserId.Equals(userId))
            .AsNoTracking()
            .Select(entity => _mapper.Map<DoctorPersonalDataDto>(entity))
            .ToListAsync();
        return list;
    }

    public async Task<DoctorPersonalDataDto> GetDoctorPersonalDataSummaryByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.DoctorPersonalData.GetByIdAsync(id);

        if (entity != null)
        {
            var dto = _mapper.Map<DoctorPersonalDataDto>(entity);
            return dto;
        }

        throw new ArgumentException(nameof(id));
    }

    public async Task<int> CreateDoctorPersonalDataAsync(DoctorPersonalDataDto dto)
    {
        var entity = _mapper.Map<DoctorPersonalData>(dto);

        if (entity == null) throw new ArgumentException(nameof(dto));
        await _unitOfWork.DoctorPersonalData.AddAsync(entity);
        var addingResult = await _unitOfWork.Commit();
        return addingResult;
    }

    public async Task<int> UpdateAsync(Guid id, DoctorPersonalDataDto dto)
    {
        var sourceDto = await GetDoctorPersonalDataByIdAsync(id);

        //should be sure that dto property naming is the same with entity property naming
        var patchList = new List<PatchModel>();
        if (dto != null)
        {
            if (!dto.FullName.Equals(sourceDto.FullName))
            {
                patchList.Add(new PatchModel() { PropertyName = nameof(dto.FullName), PropertyValue = dto.FullName });
            }
        }

        await _unitOfWork.DoctorPersonalData.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }

    public async Task<int> RemoveAsync(Guid id)
    {
        var dto = await GetDoctorPersonalDataByIdAsync(id);
        if (dto.Equals(null))
        {
            throw new ArgumentException(nameof(id));
        }

        if (dto.Doctors.Any())
        {
            throw new DatabaseDisruptionException();
        }

        var entity = _mapper.Map<DoctorPersonalData>(dto);
        _unitOfWork.DoctorPersonalData.Remove(entity);

        return await _unitOfWork.Commit();
    }
}
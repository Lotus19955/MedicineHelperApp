using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Business.ServicesImplementations;

public class SpecializationService : ISpecializationService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public SpecializationService(IMapper mapper, 
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<SpecializationDto> GetSpecializationByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Specialization.GetByIdAsync(id);

        if (entity != null)
        {
            var dto = _mapper.Map<SpecializationDto>(entity);
            return dto;
        }
        else
        {
            throw new ArgumentException(nameof(id));
        }
    }

    public async Task<bool> IsSpecializationExistAsync(string name)
    {
        var entity = await _unitOfWork.Specialization
            .Get()
            .AsNoTracking()
            .FirstOrDefaultAsync(entity =>
                entity.Name.Equals(name));
        return entity != null;
    }

    public async Task<List<SpecializationDto>> GetAllSpecializationAsync()
    {
        var list = await _unitOfWork.Specialization
            .Get()
            .Select(entity => _mapper.Map<SpecializationDto>(entity))
            .ToListAsync();
        return list;
    }

    public async Task<List<SpecializationDto>> GetAvailableSpecializationAsync()
    {
        var list = await _unitOfWork.Specialization
            .Get()
            .Where(entity => entity.IsEnable.Equals(true))
            .Select(entity => _mapper.Map<SpecializationDto>(entity))
            .ToListAsync();
        return list;
    }

    public async Task<int> CreateSpecializationAsync(SpecializationDto dto)
    {
        var entity = _mapper.Map<DoctorSpecialization>(dto);

        if (entity != null)
        {
            await _unitOfWork.Specialization.AddAsync(entity);
            var addingResult = await _unitOfWork.Commit();
            return addingResult;
        }
        else
        {
            throw new ArgumentException(nameof(dto));
        }
    }

    public async Task<int> UpdateAsync(Guid id, SpecializationDto dto)
    {
        var sourceDto = await GetSpecializationByIdAsync(id);

        //should be sure that dto property naming is the same with entity property naming
        var patchList = new List<PatchModel>();
        if (dto != null)
        {
            if (!dto.Name.Equals(sourceDto.Name))
            {
                patchList.Add(new PatchModel() { PropertyName = nameof(dto.Name), PropertyValue = dto.Name });
            }
        }

        await _unitOfWork.Specialization.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }

    public async Task<int> ChangeAvailabilityAsync(Guid id, bool newValue)
    {
        var dto = await GetSpecializationByIdAsync(id);
        var patchList = new List<PatchModel>();
        if (dto != null)
        {
            if (!dto.IsEnable.Equals(newValue))
            {
                patchList.Add(new PatchModel() { PropertyName = nameof(dto.IsEnable), PropertyValue = newValue });
            }
        }

        await _unitOfWork.Specialization.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }
}
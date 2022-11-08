using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using MedicineHelper.Core.Enums;

namespace MedicineHelper.Business.ServicesImplementations;

public class DrugService : IDrugService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DrugService(IMapper mapper, 
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<DrugDto> GetDrugByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Drug.GetByIdAsync(id);

        if (entity != null)
        {
            var dto = _mapper.Map<DrugDto>(entity);
            return dto;
        }
        else
        {
            throw new ArgumentException("No record of the drug was found in the database.", nameof(id));
        }
    }

    public async Task<bool> IsDrugExistAsync(string name, string unit, string producer, Guid userId)
    {
        var entity = await _unitOfWork.Drug
                         .Get()
                         .AsNoTracking()
                         .FirstOrDefaultAsync(entity =>
                             entity.Name.Equals(name)
                             && entity.Unit.Equals(unit)
                             && entity.Producer.Equals(producer)
                             && entity.UserId.Equals(userId))
                     ?? await _unitOfWork.Drug
                         .Get()
                         .AsNoTracking()
                         .FirstOrDefaultAsync(entity =>
                             entity.Name.Equals(name)
                             && entity.Unit.Equals(unit)
                             && entity.Producer.Equals(producer)
                             && entity.IsGlobal.Equals(true));

        return entity != null;
    }

    public async Task<List<DrugDto>> GetAllGlobalDrugsAsync(bool isOnlyEnabled=false)
    {
        var query = _unitOfWork.Drug
            .Get()
            .Where(entity => entity.IsGlobal.Equals(true));

        if (isOnlyEnabled)
        {
            query = query.Where(entity => entity.Status.Equals(DrugStatus.Enable));
        }

        var list = await query
            .AsNoTracking()
            .Select(entity => _mapper.Map<DrugDto>(entity))
            .ToListAsync();
        
        return list;
    }

    public async Task<List<DrugDto>> GetAllDrugsByUserIdAsync(Guid userId, bool isOnlyEnabled = false)
    {
        var query = _unitOfWork.Drug
            .Get()
            .Where(entity => entity.UserId.Equals(userId));

        if (isOnlyEnabled)
        {
            query = query.Where(entity => entity.Status.Equals(DrugStatus.Enable));
        }

        var list = await query
            .AsNoTracking()
            .Select(entity => _mapper.Map<DrugDto>(entity))
            .ToListAsync();
        return list;
    }

    public async Task<int> CreateDrugAsync(DrugDto dto)
    {
        var entity = _mapper.Map<Drug>(dto);

        if (entity != null)
        {
            await _unitOfWork.Drug.AddAsync(entity);
            var addingResult = await _unitOfWork.Commit();
            return addingResult;
        }
        else
        {
            throw new ArgumentException("Mapping DrugDto to Drug was not possible.", nameof(dto));
        }
    }

    public async Task<int> UpdateAsync(Guid id, DrugDto dto)
    {
        var sourceDto = await GetDrugByIdAsync(id);

        var patchList = new List<PatchModel>();

        if (!dto.Name.Equals(sourceDto.Name))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.Name),
                PropertyValue = dto.Name
            });
        }

        if (!dto.Producer.Equals(sourceDto.Producer))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.Producer),
                PropertyValue = dto.Producer
            });
        }

        if (!dto.Unit.Equals(sourceDto.Unit))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.Unit),
                PropertyValue = dto.Unit
            });
        }

        if (dto.Description != null 
            && !dto.Description.Equals(sourceDto.Description))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.Description),
                PropertyValue = dto.Description
            });
        }

        if (!dto.Status.Equals(sourceDto.Status))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.Status),
                PropertyValue = dto.Status
            });
        }

        await _unitOfWork.Drug.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }

    public async Task<int> ChangeStatusAsync(Guid id, DrugStatus status)
    {
        var dto = await GetDrugByIdAsync(id);
        var patchList = new List<PatchModel>();

        if (!dto.Status.Equals(status))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.Status),
                PropertyValue = status
            });
        }

        await _unitOfWork.Drug.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }
}

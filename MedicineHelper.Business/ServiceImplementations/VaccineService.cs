using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Business.ServicesImplementations;

public class VaccineService : IVaccineService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public VaccineService(IMapper mapper, 
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<VaccineDto> GetVaccineByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Vaccine.GetByIdAsync(id);

        if (entity != null)
        {
            var dto = _mapper.Map<VaccineDto>(entity);
            return dto;
        }
        else
        {
            throw new ArgumentException("No record of the vaccine was found in the database.", nameof(id));
        }
    }

    public async Task<bool> IsVaccineExistAsync(string name)
    {
        var entity = await _unitOfWork.Vaccine
            .Get()
            .AsNoTracking()
            .FirstOrDefaultAsync(entity =>
                entity.PharmName.Equals(name));
        return entity != null;
    }

    public async Task<List<VaccineDto>> GetAllGlobalVaccinesAsync(bool isOnlyEnabled)
    {
        var query = _unitOfWork.Vaccine
            .Get()
            .Where(entity => entity.IsGlobal.Equals(true));

        if (isOnlyEnabled)
        {
            query = query.Where(entity => entity.IsEnable.Equals(true));
        }

        var list = await query
            .AsNoTracking()
            .Select(entity => _mapper.Map<VaccineDto>(entity))
            .ToListAsync();
        
        return list;
    }

    public async Task<List<VaccineDto>> GetAllVaccinesByUserIdAsync(Guid userId, bool isOnlyEnabled = false)
    {
        var query = _unitOfWork.Vaccine
            .Get()
            .Where(entity => entity.UserId.Equals(userId));
        
        if (isOnlyEnabled)
        {
            query = query.Where(entity => entity.IsEnable.Equals(true));
        }

        var list = await query
            .AsNoTracking()
            .Select(entity => _mapper.Map<VaccineDto>(entity))
            .ToListAsync();
        return list;
    }

    public async Task<int> CreateVaccineAsync(VaccineDto dto)
    {
        var entity = _mapper.Map<Vaccine>(dto);

        if (entity != null)
        {
            await _unitOfWork.Vaccine.AddAsync(entity);
            var addingResult = await _unitOfWork.Commit();
            return addingResult;
        }
        else
        {
            throw new ArgumentException("Mapping VaccineDto to Vaccine was not possible.", nameof(dto));
        }
    }

    public async Task<int> UpdateAsync(Guid id, VaccineDto dto)
    {
        var sourceDto = await GetVaccineByIdAsync(id);

        var patchList = new List<PatchModel>();

        if (!dto.PharmName.Equals(sourceDto.PharmName))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.PharmName), 
                PropertyValue = dto.PharmName
            });
        }

        if (!dto.EffectiveTermInDays.Equals(sourceDto.EffectiveTermInDays))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.EffectiveTermInDays), 
                PropertyValue = dto.EffectiveTermInDays
            });
        }

        if (!dto.IsEnable.Equals(sourceDto.IsEnable))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.IsEnable),
                PropertyValue = dto.IsEnable
            });
        }

        await _unitOfWork.Vaccine.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }

    public async Task<int> ChangeAvailabilityAsync(Guid id, bool newValue)
    {
        var dto = await GetVaccineByIdAsync(id);
        var patchList = new List<PatchModel>();

        if (!dto.IsEnable.Equals(newValue))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.IsEnable), 
                PropertyValue = newValue
            });
        }

        await _unitOfWork.Vaccine.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }

}

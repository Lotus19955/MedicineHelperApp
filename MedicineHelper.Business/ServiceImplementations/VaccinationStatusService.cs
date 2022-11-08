using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Business.ServicesImplementations;

public class VaccinationStatusService : IVaccinationStatusService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public VaccinationStatusService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<VaccinationStatusDto> GetVaccinationStatusByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.VaccinationStatus.GetByIdAsync(id);

        if (entity != null)
        {
            var dto = _mapper.Map<VaccinationStatusDto>(entity);
            return dto;
        }
        else
        {
            throw new ArgumentException(nameof(id));
        }
    }

    public async Task<bool> IsVaccinationStatusExistAsync(string name)
    {
        var entity = await _unitOfWork.VaccinationStatus
            .Get()
            .AsNoTracking()
            .FirstOrDefaultAsync(entity =>
                entity.Name.Equals(name));
        return entity != null;
    }

    public async Task<List<VaccinationStatusDto>> GetAllVaccinationStatusesAsync()
    {
        var list = await _unitOfWork.VaccinationStatus
            .Get()
            .Select(entity => _mapper.Map<VaccinationStatusDto>(entity))
            .ToListAsync();
        return list;
    }

    public async Task<int> CreateVaccinationStatusAsync(VaccinationStatusDto dto)
    {
        var entity = _mapper.Map<VaccinationStatus>(dto);

        if (entity != null)
        {
            await _unitOfWork.VaccinationStatus.AddAsync(entity);
            var addingResult = await _unitOfWork.Commit();
            return addingResult;
        }
        else
        {
            throw new ArgumentException(nameof(dto));
        }
    }

    public async Task<int> UpdateAsync(Guid id, VaccinationStatusDto dto)
    {
        var sourceDto = await GetVaccinationStatusByIdAsync(id);

        //should be sure that dto property naming is the same with entity property naming
        var patchList = new List<PatchModel>();
        if (dto != null)
        {
            if (!dto.Name.Equals(sourceDto.Name))
            {
                patchList.Add(new PatchModel() { PropertyName = nameof(dto.Name), PropertyValue = dto.Name });
            }
        }

        await _unitOfWork.VaccinationStatus.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }

    public async Task<int> ChangeAvailabilityAsync(Guid id, bool newValue)
    {
        var dto = await GetVaccinationStatusByIdAsync(id);
        var patchList = new List<PatchModel>();
        if (dto != null)
        {
            if (!dto.IsEnable.Equals(newValue))
            {
                patchList.Add(new PatchModel() { PropertyName = nameof(dto.IsEnable), PropertyValue = newValue });
            }
        }

        await _unitOfWork.VaccinationStatus.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }
}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Business.ServicesImplementations;

public class ClinicService : IClinicService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ClinicService(IMapper mapper, 
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ClinicDto> GetClinicByIdAsync(Guid id)
    {
        //var entity = await _unitOfWork.Clinics.GetByIdAsync(id);
        var entity = await _unitOfWork.Clinics.Get()
            .Where(clinic => clinic.Id.Equals(id))
            .Include(clinic => clinic.ClinicPhones).FirstAsync();
        
        if (entity != null)
        {
            var dto = _mapper.Map<ClinicDto>(entity);
            return dto;
        }
        else
        {
            throw new ArgumentException(nameof(id));
        }
    }

    public async Task<bool> IsClinicExistAsync(string name, string address, Guid userId)
    {
        var entity = await _unitOfWork.Clinics
            .Get()
            .AsNoTracking()
            .FirstOrDefaultAsync(entity => 
                entity.Name.Equals(name)
                && entity.Address.Equals(address)
                && entity.UserId.Equals(userId));
        return entity != null;
    }

    public async Task<bool> IsClinicExistAsync(Guid id)
    {
        var entity = await _unitOfWork.Clinics
            .Get()
            .AsNoTracking()
            .FirstOrDefaultAsync(entity =>
                entity.Id.Equals(id));
        return entity != null;
    }

    public async Task<List<ClinicDto>> GetAllClinicsAsync()
    {
        var list = await _unitOfWork.Clinics
            .Get()
            .Select(entity => _mapper.Map<ClinicDto>(entity))
            .ToListAsync();
        return list;
    }

    public async Task<List<ClinicDto>> GetAllClinicsByUserIdAsync(Guid userId)
    {
        var list = await _unitOfWork.Clinics
            .Get()
            .Where(clinic => clinic.UserId.Equals(userId))
            .AsNoTracking()
            .Select(entity => _mapper.Map<ClinicDto>(entity))
            .ToListAsync();

        return list;
    }

    public async Task<List<ClinicDto>> GetAvailableClinicsAsync()
    {
        var list = await _unitOfWork.Clinics
            .Get()
            .Select(entity => _mapper.Map<ClinicDto>(entity))
            .ToListAsync();
        return list;
    }

    public async Task<(string, string)> GetClinicSummaryByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Clinics.GetByIdAsync(id);

        if (entity != null)
        {
            return (entity.Name, entity.Address);
        }
        else
        {
            throw new ArgumentException(nameof(id));
        }
    }

    public async Task<int> CreateClinicAsync(ClinicDto dto)
    {
        var entity = _mapper.Map<Clinic>(dto);

        if (entity != null)
        {
            await _unitOfWork.Clinics.AddAsync(entity);
            var addingResult = await _unitOfWork.Commit();
            return addingResult;
        }
        else
        {
            throw new ArgumentException(nameof(dto));
        }
    }

    public async Task<int> UpdateAsync(Guid id, ClinicDto dto)
    {
        var sourceDto = await GetClinicByIdAsync(id);

        var patchList = new List<PatchModel>();

        if (!dto.Name.Equals(sourceDto.Name))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.Name),
                PropertyValue = dto.Name
            });
        }

        if (!dto.Address.Equals(sourceDto.Address))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.Address),
                PropertyValue = dto.Address
            });
        }

        await _unitOfWork.Clinics.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }
}
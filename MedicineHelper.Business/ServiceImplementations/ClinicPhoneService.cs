using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Business.ServicesImplementations;

public class ClinicPhoneService : IClinicPhoneService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ClinicPhoneService(IMapper mapper, 
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ClinicPhoneDto> GetClinicPhoneByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.ClinicPhones.GetByIdAsync(id);

        if (entity != null)
        {
            var dto = _mapper.Map<ClinicPhoneDto>(entity);
            return dto;
        }
        else
        {
            throw new ArgumentException(nameof(id));
        }
    }

    public async Task<bool> IsClinicPhoneExistAsync(string name, Guid clinicId)
    {
        var entity = await _unitOfWork.ClinicPhones
            .Get()
            .AsNoTracking()
            .FirstOrDefaultAsync(entity =>
                entity.Number.Equals(name)
                && entity.ClinicId.Equals(clinicId));
        return entity != null;
    }

    public async Task<List<ClinicPhoneDto>> GetAllClinicPhonesByClinicIdAsync(Guid clinicId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateClinicPhoneAsync(ClinicPhoneDto dto)
    {
        var entity = _mapper.Map<ClinicPhone>(dto);

        if (entity != null)
        {
            await _unitOfWork.ClinicPhones.AddAsync(entity);
            var addingResult = await _unitOfWork.Commit();
            return addingResult;
        }
        else
        {
            throw new ArgumentException(nameof(dto));
        }
    }

    public async Task<int> UpdateClinicPhoneAsync(ClinicPhoneDto clinicPhoneDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> PatchAsync(Guid id, List<PatchModel> patchList)
    {
        await _unitOfWork.ClinicPhones.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }

    public async Task<int> DeleteAsync(ClinicPhoneDto dto)
    {
        var entity = _mapper.Map<ClinicPhone>(dto);

        if (entity != null)
        {
            _unitOfWork.ClinicPhones.Remove(entity);
            return await _unitOfWork.Commit();
        }
        else
        {
            throw new ArgumentException(nameof(dto));
        }
    }
}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Business.ServicesImplementations;

public class VaccinationService : IVaccinationService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public VaccinationService(IMapper mapper, 
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<VaccinationDto> GetVaccinationByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Vaccination.GetByIdAsync(id);

        if (entity != null)
        {
            var dto = _mapper.Map<VaccinationDto>(entity);
            return dto;
        }
        else
        {
            throw new ArgumentException("No record of the vaccination was found in the database.", nameof(id));
        }
    }

    public async Task<bool> IsVaccinationExistAsync(Guid clinicId, 
        Guid vaccineId, 
        Guid userId,
        DateTime dateOfVaccination)
    {
        var entity = await _unitOfWork.Vaccination
            .Get()
            .AsNoTracking()
            .FirstOrDefaultAsync(entity =>
                entity.DateOfVaccination.Equals(dateOfVaccination)
                && entity.ClinicId.Equals(clinicId)
                && entity.VaccineId.Equals(vaccineId)
                && entity.UserId.Equals(userId));
        return entity != null;
    }

    public async Task<List<VaccinationDto>> GetAllVaccinationsByUserIdAsync(Guid userId)
    {
        var list = await _unitOfWork.Vaccination
            .FindBy(vaccination => vaccination.UserId.Equals(userId),
                vaccination => vaccination.Clinic,
                vaccination => vaccination.Vaccine)
            .AsNoTracking()
            .Select(entity => _mapper.Map<VaccinationDto>(entity))
            .ToListAsync();

        return list;
    }

    public async Task<int> CreateVaccinationAsync(VaccinationDto dto)
    {
        var entity = _mapper.Map<Vaccination>(dto);

        if (entity != null)
        {
            await _unitOfWork.Vaccination.AddAsync(entity);
            var addingResult = await _unitOfWork.Commit();
            return addingResult;
        }

        throw new ArgumentException("Mapping VaccinationDto to Vaccinate was not possible.", nameof(dto));
    }

    public async Task<int> UpdateAsync(Guid id, VaccinationDto dto)
    {
        var sourceDto = await GetVaccinationByIdAsync(id);

        var patchList = new List<PatchModel>();

        if (!dto.DateOfVaccination.Equals(sourceDto.DateOfVaccination))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.DateOfVaccination),
                PropertyValue = dto.DateOfVaccination
            });
        }

        if (!dto.VaccinationStatusId.Equals(sourceDto.VaccinationStatusId))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.VaccinationStatusId),
                PropertyValue = dto.VaccinationStatusId
            });
        }

        if (!dto.ClinicId.Equals(sourceDto.ClinicId))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.ClinicId),
                PropertyValue = dto.ClinicId
            });
        }

        if (!dto.VaccineId.Equals(sourceDto.VaccineId))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.VaccineId),
                PropertyValue = dto.VaccineId
            });
        }

        await _unitOfWork.Vaccination.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }
}
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.CustomException;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Business.ServicesImplementations;

public class DoctorService : IDoctorService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DoctorService(IMapper mapper, 
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<DoctorDto> GetDoctorByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Doctor.GetByIdAsync(id);

        if (entity != null)
        {
            var dto = _mapper.Map<DoctorDto>(entity);
            return dto;
        }

        throw new ArgumentException(nameof(id));
    }

    public async Task<bool> IsDoctorExistAsync(Guid id)
    {
        var entity = await _unitOfWork.Doctor.GetByIdAsync(id);
        return entity != null;
    }

    public async Task<bool> IsDoctorExistAsync(Guid doctorPersonalDataId,
        Guid specializationId, Guid clinicId, Guid userId)
    {
        var entity = await _unitOfWork.Doctor
            .Get()
            .Where(d => d.DoctorPersonalDataId.Equals(doctorPersonalDataId)
            && d.SpecializationId.Equals(specializationId)
            && d.ClinicId.Equals(clinicId)
            && d.UserId.Equals(userId))
            .FirstOrDefaultAsync();

        return entity != null;
    }

    public async Task<bool> IsDoctorExistAsync(DoctorDto dto)
    {
        return await IsDoctorExistAsync(dto.DoctorPersonalDataId, 
            dto.SpecializationId, dto.ClinicId, dto.UserId);
    }

    public async Task<List<DoctorDto>> GetAllDoctorsAsync()
    {
        //todo: when add userId to Doctor to rewrite it with FindBy
        var list = await _unitOfWork.Doctor
            .Get()
            .Include(doc => doc.Clinic)
            .Include(doc => doc.Specialization)
            .Include(doc => doc.JobStatus)
            .AsNoTracking()
            .Select(entity => _mapper.Map<DoctorDto>(entity))
            .ToListAsync();

        return list;
    }

    public async Task<List<DoctorDto>> GetAllDoctorsByUserIdAsync(Guid userId, Guid clinicId = default,
        Guid specializationId = default)
    {
        Expression<Func<Doctor, bool>> searchExpression =  d => d.UserId.Equals(userId);
        if (!clinicId.Equals(Guid.Empty))
        {
            if (!specializationId.Equals(Guid.Empty))
            {
                searchExpression = d => d.UserId.Equals(userId) 
                                        && d.ClinicId.Equals(clinicId)
                                        && d.SpecializationId.Equals(specializationId);
            }
            else
            {
                searchExpression = d => d.UserId.Equals(userId) 
                                        && d.ClinicId.Equals(clinicId);
            }
        }
        //var list = await _unitOfWork.Doctor
        //    .FindBy(doctor => doctor.UserId.Equals(userId),
        //        doctor => doctor.DoctorPersonalData,
        //        doctor => doctor.Clinic,
        //        doctor => doctor.Specialization,
        //        doctor => doctor.JobStatus)
        //    .AsNoTracking()
        //    .Select(entity => _mapper.Map<DoctorDto>(entity))
        //    .ToListAsync();

        var list = await _unitOfWork.Doctor
            .FindBy(searchExpression,
                doctor => doctor.DoctorPersonalData,
                doctor => doctor.Clinic,
                doctor => doctor.Specialization,
                doctor => doctor.JobStatus)
            .AsNoTracking()
            .Select(entity => _mapper.Map<DoctorDto>(entity))
            .ToListAsync();

        return list;
    }

    public async Task<int> CreateDoctorAsync(DoctorDto dto)
    {
        var entity = _mapper.Map<Doctor>(dto);

        if (entity == null) throw new ArgumentException(nameof(dto));
        await _unitOfWork.Doctor.AddAsync(entity);
        var addingResult = await _unitOfWork.Commit();
        return addingResult;
    }

    public async Task<int> UpdateAsync(Guid id, DoctorDto dto)
    {
        var sourceDto = await GetDoctorByIdAsync(id);

        //should be sure that dto property naming is the same with entity property naming
        var patchList = new List<PatchModel>();
        if (dto != null)
        {
            if (!dto.ClinicId.Equals(sourceDto.ClinicId))
            {
                patchList.Add(new PatchModel()
                {
                    PropertyName = nameof(dto.ClinicId), 
                    PropertyValue = dto.ClinicId
                });
            }
            if (!dto.SpecializationId.Equals(sourceDto.SpecializationId))
            {
                patchList.Add(new PatchModel()
                {
                    PropertyName = nameof(dto.SpecializationId), 
                    PropertyValue = dto.SpecializationId
                });
            }
            if (!dto.JobStatusId.Equals(sourceDto.JobStatusId))
            {
                patchList.Add(new PatchModel()
                {
                    PropertyName = nameof(dto.JobStatusId), 
                    PropertyValue = dto.JobStatusId
                });
            }
        }

        await _unitOfWork.Doctor.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }

    public async Task<int> RemoveAsync(Guid id)
    {
        var dto = await GetDoctorByIdAsync(id);
        if (dto.Equals(null))
        {
            throw new ArgumentException(nameof(id));
        }

        if (dto.Visits.Any())
        {
            throw new DatabaseDisruptionException();
        }

        var entity = _mapper.Map<Doctor>(dto);
        _unitOfWork.Doctor.Remove(entity);

        return await _unitOfWork.Commit();
    }
}
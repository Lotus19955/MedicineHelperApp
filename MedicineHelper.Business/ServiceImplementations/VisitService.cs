using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Business.ServicesImplementations;

public class VisitService : IVisitService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public VisitService(IMapper mapper, 
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<VisitDto> GetVisitByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Visit.GetByIdAsync(id);

        if (entity != null)
        {
            var dto = _mapper.Map<VisitDto>(entity);
            return dto;
        }
        else
        {
            throw new ArgumentException("No record of the visit was found in the database.", nameof(id));
        }
    }

    public async Task<VisitDto> GetVisitWithAllInnerPropertiesByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Visit
            .Get()
            .Where(visit => visit.Id.Equals(id))
            .Include(visit => visit.Doctor.DoctorPersonalData)
            .Include(visit => visit.Doctor.Specialization)
            .Include(visit => visit.Doctor.Clinic)
            .Include(visit => visit.VisitResults)
            .Include(visit => visit.Prescriptions)
            .Include(visit => visit.VisitCosts)
            .AsNoTracking()
            .FirstAsync();


        if (entity != null)
        {
            var dto = _mapper.Map<VisitDto>(entity);
            return dto;
        }
        else
        {
            throw new ArgumentException("No record of the visit was found in the database.", nameof(id));
        }
    }

    public async Task<bool> IsVisitExistAsync(Guid doctorId, 
        Guid userId, DateTime dateOfVisit)
    {
        var entity = await _unitOfWork.Visit
            .Get()
            .AsNoTracking()
            .FirstOrDefaultAsync(entity =>
                entity.VisitDate.Equals(dateOfVisit)
            && entity.DoctorId.Equals(doctorId)
                && entity.UserId.Equals(userId));
        return entity != null;
    }

    public async Task<List<VisitDto>> GetAllVisitsByUserIdAsync(Guid userId)
    {
        var list = await _unitOfWork.Visit
            .FindBy(visit => visit.UserId.Equals(userId),
                visit => visit.Doctor.DoctorPersonalData,
                visit => visit.Doctor.Specialization,
                visit => visit.Doctor.Clinic)
            .AsNoTracking()
            .Select(entity => _mapper.Map<VisitDto>(entity))
            .ToListAsync();

        return list;
    }

    public async Task<int> CreateVisitAsync(VisitDto dto)
    {
        var entity = _mapper.Map<Visit>(dto);

        if (entity != null)
        {
            await _unitOfWork.Visit.AddAsync(entity);
            var addingResult = await _unitOfWork.Commit();
            return addingResult;
        }

        throw new ArgumentException("Mapping VisitDto to Visit was not possible.", nameof(dto));
    }

    public async Task<int> UpdateAsync(Guid id, VisitDto dto)
    {
        var sourceDto = await GetVisitByIdAsync(id);

        var patchList = new List<PatchModel>();

        if (!dto.DateOfVisit.Equals(sourceDto.DateOfVisit))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.DateOfVisit),
                PropertyValue = dto.DateOfVisit
            });
        }

        if (!dto.VisitStatus.Equals(sourceDto.VisitStatus))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.VisitStatus),
                PropertyValue = dto.VisitStatus
            });
        }

        if (!dto.DoctorId.Equals(sourceDto.DoctorId))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.DoctorId),
                PropertyValue = dto.DoctorId
            });
        }

        await _unitOfWork.Visit.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }

    public Task<int> Remove(Guid id)
    {
        throw new NotImplementedException();
    }
}
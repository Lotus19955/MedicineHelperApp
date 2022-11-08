using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Business.ServicesImplementations;

public class VisitResultService : IVisitResultService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public VisitResultService(IMapper mapper, 
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<VisitResultDto> GetVisitResultByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.VisitResult.GetByIdAsync(id);

        if (entity != null)
        {
            var dto = _mapper.Map<VisitResultDto>(entity);
            return dto;
        }
        else
        {
            throw new ArgumentException("No record of the visit result was found in the database.", nameof(id));
        }
    }

    public async Task<List<VisitResultDto>> GetAllVisitResultsByVisitIdAsync(Guid visitId)
    {
        var list = await _unitOfWork.VisitResult
            .Get()
            .Where(result => result.Visit.Id.Equals(visitId))
            .AsNoTracking()
            .Select(entity => _mapper.Map<VisitResultDto>(entity))
            .ToListAsync();

        return list;
    }

    public async Task<int> CreateVisitResultAsync(VisitResultDto dto)
    {
        var entity = _mapper.Map<VisitResult>(dto);

        if (entity != null)
        {
            await _unitOfWork.VisitResult.AddAsync(entity);
            var addingResult = await _unitOfWork.Commit();
            return addingResult;
        }

        throw new ArgumentException("Mapping VisitResultDto to VisitResult was not possible.", nameof(dto));
    }

    public async Task<int> UpdateAsync(Guid id, VisitResultDto dto)
    {
        var sourceDto = await GetVisitResultByIdAsync(id);

        var patchList = new List<PatchModel>();

        if (!dto.Note.Equals(sourceDto.Note))
        {
            patchList.Add(new PatchModel()
            {
                PropertyName = nameof(dto.Note),
                PropertyValue = dto.Note
            });
        }
        
        await _unitOfWork.VisitResult.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }

    public async Task<int> DeleteAsync(VisitResultDto dto)
    {
        var entity = _mapper.Map<VisitResult>(dto);

        if (entity != null)
        {
            _unitOfWork.VisitResult.Remove(entity);
            return await _unitOfWork.Commit();
        }
        else
        {
            throw new ArgumentException(nameof(dto));
        }
    }
}
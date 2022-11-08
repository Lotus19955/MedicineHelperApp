using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.Data.Abstractions.Repositories;
using MedicineHelper.DataBase;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Business.ServicesImplementations;

public class CurrencyService : ICurrencyService
{
    private readonly IMapper _mapper;
    private readonly MedicineHelperContext _databaseContext;
    private readonly IUnitOfWork _unitOfWork;

    public CurrencyService(IMapper mapper,
        MedicineHelperContext databaseContext, 
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _databaseContext = databaseContext;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<CurrencyDto>> GetAllCurrenciesAsync()
    {
        try
        {
            //This approach used for a separate repository for each entity
            var Entities = await _unitOfWork.Currencies.GetAllAsync();
            var list = Entities
                .Select(entity => _mapper.Map<CurrencyDto>(entity)).ToList();
            
            
            return list;

            //This approach used for generic repository
            //var list = await _unitOfWork.Currencies
            //    .Get()
            //    .Select(currency => _mapper.Map<CurrencyDto>(currency))
            //    .ToListAsync();
            //return list;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<int> CreateCurrencyAsync(CurrencyDto dto)
    {
        var entity = _mapper.Map<Currency>(dto);

        if (entity != null)
        {
            await _unitOfWork.Currencies.AddAsync(entity);
            var addingResult = await _unitOfWork.Commit();
            return addingResult;
        }
        else
        {
            throw new ArgumentException(nameof(dto));
        }
    }

    public async Task<CurrencyDto> GetCurrencyByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Currencies.GetByIdAsync(id);
        var dto = _mapper.Map<CurrencyDto>(entity);

        return dto;
    }

    public async Task<bool> IsCurrencyNameExistAsync(string name)
    {
        return await _unitOfWork.Currencies.IsCurrencyExistAsync(name);
    }

    //todo: delete this method
    //Better to use PatchAsync 
    public async Task<int> UpdateCurrencyAsync(CurrencyDto currencyDto)
    {
        var entity = await _unitOfWork.Currencies.GetByIdAsync(currencyDto.Id);
        if (entity != null)
        {
            entity.Name = currencyDto.Name;
            _unitOfWork.Currencies.Update(entity);
            var updatingResult = await _unitOfWork.Commit();
            return updatingResult;
        }
        else
        {
            throw new ArgumentException(nameof(currencyDto));
        }
    }

    public async Task<int> PatchAsync(Guid id, List<PatchModel> patchList)
    {
        await _unitOfWork.Currencies.PatchAsync(id, patchList);
        return await _unitOfWork.Commit();
    }
}
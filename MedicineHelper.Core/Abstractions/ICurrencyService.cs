using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions;

public interface ICurrencyService
{
    //READ
    Task<CurrencyDto> GetCurrencyByIdAsync(Guid id);
    Task<bool> IsCurrencyNameExistAsync(string name);
    Task<List<CurrencyDto>> GetAllCurrenciesAsync();

    //CREATE
    Task<int> CreateCurrencyAsync(CurrencyDto dto);

    //UPDATE
    Task<int> UpdateCurrencyAsync(CurrencyDto currencyDto);
    Task<int> PatchAsync(Guid id, List<PatchModel> patchList);
}
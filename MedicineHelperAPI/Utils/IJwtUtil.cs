using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperWebAPI.Models.Responses;

namespace MedicineHelperWebAPI.Utils
{
    public interface IJwtUtil
    {
        Task<TokenResponse> GenerateTokenAsync(UserDto dto);
        //Task RemoveRefreshTokenAsync(Guid requestRefreshToken);
    }
}

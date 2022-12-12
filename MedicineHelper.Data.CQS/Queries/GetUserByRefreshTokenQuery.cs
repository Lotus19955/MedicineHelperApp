using MediatR;
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Data.CQS.Queries
{
    public class GetUserByRefreshTokenQuery : IRequest<UserDto?>
    {
        public Guid RefreshToken { get; set; }
    }
}

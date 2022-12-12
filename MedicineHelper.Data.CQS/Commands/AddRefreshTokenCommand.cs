using MediatR;
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Data.CQS.Commands
{
    public class AddRefreshTokenCommand : IRequest
    {
        public Guid TokenValue;
        public Guid UserId;
    }
}

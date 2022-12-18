using MedicineHelper.Core.DataTransferObjects;
using MediatR;

namespace AspNetSample.Data.CQS.Commands;

public class RemoveRefreshTokenCommand : IRequest
{
    public Guid TokenValue;
}
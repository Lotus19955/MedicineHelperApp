using AutoMapper;
using MediatR;
using MedicineHelper.Data.CQS.Commands;
using MedicineHelper.DataBase;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Data.CQS.Handlers.CommandHandlers
{
    public class AddRefreshTokenCommandHandler 
        : IRequestHandler<AddRefreshTokenCommand, Unit>
    {
        private readonly MedicineHelperContext _context;
        private readonly IMapper _mapper;

        public AddRefreshTokenCommandHandler(MedicineHelperContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddRefreshTokenCommand command, CancellationToken token)
        {
            var rt = new RefreshToken()
            {
                Id = Guid.NewGuid(),
                Token = command.TokenValue,
                UserId = command.UserId
            };
            await _context.RefreshTokens.AddAsync(rt, token);
            await _context.SaveChangesAsync(token);
            return Unit.Value;
        }
    }
}

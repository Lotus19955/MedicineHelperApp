using AutoMapper;
using MediatR;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.CQS.Queries;
using MedicineHelper.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.Data.CQS.Handlers.QueryHandlers
{
    public class GetUserByRefreshTokenQueryHandler : IRequestHandler<GetUserByRefreshTokenQuery, UserDto?>
    {
        private readonly MedicineHelperContext _context;
        private readonly IMapper _mapper;

        public GetUserByRefreshTokenQueryHandler(MedicineHelperContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto?> Handle(GetUserByRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var user = (await _context.RefreshTokens
                .Include(token => token.User)
                .ThenInclude(user => user.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync(token => token.Token == request.RefreshToken,
                    cancellationToken))?.User;

            return _mapper.Map<UserDto>(user);
        }
    }
}

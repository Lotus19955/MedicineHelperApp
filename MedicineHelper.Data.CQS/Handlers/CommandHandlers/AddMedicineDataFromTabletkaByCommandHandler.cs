using AutoMapper;
using MediatR;
using MedicineHelper.Data.CQS.Commands;
using MedicineHelper.DataBase;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Data.CQS.Handlers.CommandHandlers
{
    public class AddMedicineDataFromTabletkaByCommandHandler
        : IRequestHandler<AddMedicineDataFromTabletkaByCommand, Unit>
    {
        private readonly MedicineHelperContext _context;
        private readonly IMapper _mapper;

        public AddMedicineDataFromTabletkaByCommandHandler(MedicineHelperContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddMedicineDataFromTabletkaByCommand command, CancellationToken token)
        {
            var oldMedicineeUrls = await _context.Medicines
                .Select(medicine => medicine.NameOfMedicine)
                .ToArrayAsync(token);

            var med = command.Medicines
                .Where(dto => !oldMedicineeUrls.Contains(dto.NameOfMedicine))
                .Select(dto => _mapper.Map<Medicine>(dto)).ToArray();

            await _context.Medicines.AddRangeAsync(med);
            await _context.SaveChangesAsync(token);
            return Unit.Value;
        }
    }
}

using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase;
using AutoMapper;
using MedicineHelper.DataBase.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.Core;

namespace MedicineHelper.Business.ServiceImplemintations
{
    public class VisitsService : IVisitsService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public VisitsService(IMapper mapper, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateVisitAsync(VisitsDto dto)
        {
            var entity = _mapper.Map<Visits>(dto);
            if (entity != null)
            {
                await _unitOfWork.Visits.AddAsync(entity);
                var addingResult = await _unitOfWork.Commit();
                return addingResult;
            }
            else
            {
                throw new ArgumentException(nameof(dto));
            }
        }

        public async Task<List<VisitsDto>> GetAllVisitsAsync()
        {

            //var myApiKey = _configuration.GetSection("UserSecrets")["MyApiKey"];
            return (await _unitOfWork.Visits.Get().Select(visits 
                => _mapper.Map<VisitsDto>(visits)).ToListAsync());
        }

        public async Task<VisitsDto> GetVisitsByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.Visits.GetByIdAsync(id);
            var dto = _mapper.Map<VisitsDto>(entity);

            return dto;
        }

        //TODO implement
        public Task<List<VisitsDto>> GetVisitsForPeriodAsync(DateTime firstDate, DateTime secondDate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> PatchAsync(Guid id, List<PatchModel> patchList)
        {
            await _unitOfWork.Visits.PatchAsync(id, patchList);
            return await _unitOfWork.Commit();
        }
    }
}
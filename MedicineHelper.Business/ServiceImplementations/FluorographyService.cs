using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class FluorographyService : IFluorographyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FluorographyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> CreateFluorographyAsync(FluorographyDto fluorographyDto)
        {
            try
            {
                var entity = _mapper.Map<Fluorography>(fluorographyDto);
                await _unitOfWork.Fluorography.AddAsync(entity);
                var result = await _unitOfWork.Commit();

                return result;
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }

        public async Task<List<FluorographyDto>> GetAllFluorographiesAsync(Guid userId) 
        {
            try
            {
                var listFlyorographies = await _unitOfWork.Fluorography
                    .Get().Where(entity => entity.UserId.Equals(userId))
                    .Include(dto => dto.Clinic)
                    .Select(flyoragraphies => _mapper.Map<FluorographyDto>(flyoragraphies))
                    .ToListAsync();

                
                return listFlyorographies;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

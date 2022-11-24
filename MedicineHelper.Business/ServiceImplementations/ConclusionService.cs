using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class ConclusionService : IConclusionService
    {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ConclusionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IOrderedQueryable<ConclusionDto>> GetAllConclusionAsync(Guid userId)
        {
            try
            {
                var listAnalysis = await _unitOfWork.Conclusion
                    .FindBy(entity => entity.UserId.Equals(userId))
                    .AsNoTracking()
                    .Include(include => include.Clinic)
                    .Select(conclusion => _mapper.Map<ConclusionDto>(conclusion))
                    .ToListAsync();
                var queryList = listAnalysis.AsQueryable().OrderBy(x => x.DateOfConclusion);

                return queryList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ConclusionDto>> GetPeriodConclusionAsync(DateTime SearchDateStart, DateTime SearchDateEnd, Guid userId)
        {
            try
            {
                var listAnalysis = await _unitOfWork.Conclusion
                    .FindBy(entity => entity.UserId.Equals(userId))
                    .Where(entityData => entityData.DateOfAnalysis >= SearchDateStart && entityData.DateOfAnalysis <=SearchDateEnd)
                    .Include(include => include.Clinic)
                    .OrderBy(entity => entity.DateOfAnalysis)
                    .Select(conclusion => _mapper.Map<ConclusionDto>(conclusion))
                    .ToListAsync();

                return listAnalysis;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<int> CreateConclusionAsync(ConclusionDto conclusionDto)
        {
            try
            {
                var conclusion = _mapper.Map<Conclusion>(conclusionDto);
                await _unitOfWork.Conclusion.AddAsync(conclusion);
                var resultAdd = await _unitOfWork.Commit();

                return resultAdd;
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }
    }
}

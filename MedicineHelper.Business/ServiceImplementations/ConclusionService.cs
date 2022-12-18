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

        public async Task<List<ConclusionDto>> GetAllConclusionAsync(Guid id)
        {
            try
            {
                var conclusionList = await _unitOfWork.Conclusion
                    .FindBy(entity => entity.UserId.Equals(id))
                    .Include(entity => entity.Clinic)
                    .Select(entity => _mapper.Map<ConclusionDto>(entity))
                    .ToListAsync();

                return conclusionList;
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
                    .Where(entityData => entityData.DateOfConclusion >= SearchDateStart && entityData.DateOfConclusion <=SearchDateEnd)
                    .Include(include => include.Clinic)
                    .OrderBy(entity => entity.DateOfConclusion)
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
                conclusion.Id = Guid.NewGuid();
                await _unitOfWork.Conclusion.AddAsync(conclusion);
                var resultAdd = await _unitOfWork.Commit();

                return resultAdd;
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }
        public async Task DeleteConclusion(Guid id)
        {
            try
            {
                var entity = await _unitOfWork.Conclusion
                    .FindBy(entity => entity.Id.Equals(id))
                    .FirstOrDefaultAsync();

                _unitOfWork.Conclusion.Remove(entity);
                await _unitOfWork.Commit();
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}

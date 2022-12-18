using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class DiseaseHistoryService : IDiseaseHistoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DiseaseHistoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateDiseaseAsync(DiseaseDto dto)
        {
            try
            {
                var entity = _mapper.Map<Disease>(dto);
                entity.Id = Guid.NewGuid();
                await _unitOfWork.Disease.AddAsync(entity);
                var result = await _unitOfWork.Commit();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> CreateDiseaseHistoryAsync(DiseaseHistoryDto dto)
        {
            try
            {
                var entity = _mapper.Map<DiseaseHistory>(dto);
                entity.Id = Guid.NewGuid();
                if (dto.BoolTypeOfTreatment)
                {
                    entity.TypeOfTreatment = "Stationary";
                }
                else
                {
                    entity.TypeOfTreatment = "Outpatient";
                }
                await _unitOfWork.DiseaseHistory.AddAsync(entity);
                var result = await _unitOfWork.Commit();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<DiseaseDto>> GetAllDiseaseAsync()
        {
            try
            {
                var dto = await _unitOfWork.Disease.Get()
                    .Select(entity => _mapper.Map<DiseaseDto>(entity))
                    .ToListAsync();

                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<DiseaseHistoryDto>> GetAllDiseaseHistoryForUserAsync(Guid id)
        {
            try
            {
                var listDiseaseHistory = await _unitOfWork.DiseaseHistory
                    .FindBy(entity => entity.UserId.Equals(id))
                    .Include(include => include.Disease)
                    .OrderBy(entity => entity.DateOfDisease)
                    .Select(diseaseHistory => _mapper.Map<DiseaseHistoryDto>(diseaseHistory))
                    .ToListAsync();
                return listDiseaseHistory;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<DiseaseHistoryDto>> GetAllDiseaseHistoryForUserAsyncForPeriod(DateTime SearchDateStart, DateTime SearchDateEnd, Guid userId)
        {
            try
            {
                var listDiseaseHistory = await _unitOfWork.DiseaseHistory
                    .FindBy(entity => entity.UserId.Equals(userId))
                    .Where(entityData => entityData.DateOfDisease >= SearchDateStart && entityData.DateOfDisease <= SearchDateEnd)
                    .Include(include => include.Disease)
                    .OrderBy(entity => entity.DateOfDisease)
                    .Select(diseaseHistory => _mapper.Map<DiseaseHistoryDto>(diseaseHistory))
                    .ToListAsync();
                return listDiseaseHistory;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task DeleteDiseaseHistory(Guid id)
        {
            try
            {
                var entity = await _unitOfWork.DiseaseHistory
                    .FindBy(entity => entity.Id.Equals(id))
                    .FirstOrDefaultAsync();

                _unitOfWork.DiseaseHistory.Remove(entity);
                await _unitOfWork.Commit();
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}

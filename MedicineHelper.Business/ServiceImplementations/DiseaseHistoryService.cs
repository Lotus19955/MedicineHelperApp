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
                await _unitOfWork.DiseaseHistory.AddAsync(entity);
                var lastId = entity.Id;
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

        public async Task<List<DiseaseHistoryDto>> GetAllDiseaseHistoryAsync(Guid id)
        {
            try
            {
                var listDiseaseHistory = await _unitOfWork.DiseaseHistory
                    .FindBy(entity => entity.UserId.Equals(id))
                    .Include(include => include.Disease)
                    .Select(diseaseHistory => _mapper.Map<DiseaseHistoryDto>(diseaseHistory))
                    .ToListAsync();
                return listDiseaseHistory;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

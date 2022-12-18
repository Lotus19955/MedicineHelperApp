using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class VaccinationService : IVaccinationService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public VaccinationService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateVaccinationAsync(VaccinationDto dto)
        {
            try
            {
                var entity = _mapper.Map<Vaccination>(dto);
                entity.Id = Guid.NewGuid();
                await _unitOfWork.Vaccination.AddAsync(entity);
                var result = await _unitOfWork.Commit();

                return result;
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }

        public async Task<List<VaccinationDto>> GetAllVaccinationsAsync(Guid id)
        {
            try
            {
                var listVaccination = await _unitOfWork.Vaccination
                    .FindBy(entity=>entity.UserId.Equals(id))
                    .Include(dto => dto.Clinic)
                    .Select(vaccination => _mapper.Map<VaccinationDto>(vaccination))
                    .AsNoTracking()
                    .ToListAsync();
                return listVaccination;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<VaccinationDto>> GetPeriodVaccinationsAsync(DateTime SearchDateStart, DateTime SearchDateEnd, Guid userId)
        {
            try
            {
                var listVaccination = await _unitOfWork.Vaccination
                    .FindBy(entity => entity.UserId.Equals(userId))
                    .Where(entityData => entityData.DateOfVaccination >= SearchDateStart && entityData.DateOfVaccination <= SearchDateEnd)
                    .Include(dto => dto.Clinic)
                    .OrderBy(entity => entity.DateOfVaccination)
                    .Select(vaccination => _mapper.Map<VaccinationDto>(vaccination))
                    .AsNoTracking()
                    .ToListAsync();
                return listVaccination;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task Delete(Guid id)
        {
            try
            {
                var entity = await _unitOfWork.Vaccination
                    .FindBy(entity => entity.Id.Equals(id))
                    .FirstOrDefaultAsync();

                _unitOfWork.Vaccination.Remove(entity);
                await _unitOfWork.Commit();
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}

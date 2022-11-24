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
                    .ToListAsync();
                return listVaccination;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

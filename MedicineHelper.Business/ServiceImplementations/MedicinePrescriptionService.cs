using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class MedicinePrescriptionService : IMedicinePrescriptionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MedicinePrescriptionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MedicinePrescriptionDto>> GetAllMedicinePrescriptionAsync(Guid id)
        {
            try
            {
                var prescribedMedication = await _unitOfWork.MedicinePrescription
                    .Get().Where(entity => entity.UserId.Equals(id))
                    .Include(include => include.Medicine)
                    .Select(entity => _mapper.Map<MedicinePrescriptionDto>(entity))
                    .ToListAsync();

                return prescribedMedication;
            }
            catch (Exception)
            {

                throw new ArgumentException();
            }
        }
        public async Task<int> CreateMedicinePrescriptionAsync(MedicinePrescriptionDto dto)
        {
            try
            {
                var entity = _mapper.Map<MedicinePrescription>(dto);
                entity.Id = Guid.NewGuid();
                await _unitOfWork.MedicinePrescription.AddAsync(entity);
                var result = await _unitOfWork.Commit();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteMedicinePrescriptionAsync(Guid id)
        {
            try
            {
                var entity = await _unitOfWork.MedicinePrescription
                    .FindBy(entity => entity.Id.Equals(id))
                    .FirstOrDefaultAsync();

                _unitOfWork.MedicinePrescription.Remove(entity);
                await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

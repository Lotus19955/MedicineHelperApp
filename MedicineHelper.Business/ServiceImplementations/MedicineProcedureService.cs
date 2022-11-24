using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class MedicineProcedureService : IMedicineProcedureService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MedicineProcedureService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateMedicineProcedureAsync(MedicineProcedureDto dto)
        {
            try
            {
                var entity = _mapper.Map<MedicineProcedure>(dto);
                await _unitOfWork.MedicineProcedure.AddAsync(entity);
                var result = await _unitOfWork.Commit();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<MedicineProcedureDto>> GetAllMedicineProcedureAsync(Guid id)
        {
            try
            {
                var listPhysicalTherapy = await _unitOfWork.MedicineProcedure
                    .FindBy(entity => entity.UserId.Equals(id))
                    .Include(include => include.Clinic)
                    .Select(entity => _mapper.Map<MedicineProcedureDto>(entity))
                    .ToListAsync();

                return listPhysicalTherapy;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

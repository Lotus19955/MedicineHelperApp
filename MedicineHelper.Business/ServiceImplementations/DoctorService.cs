using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateDoctorAsync(DoctorDto dto)
        {
            try
            {
                var entity = _mapper.Map<Doctor>(dto);
                await _unitOfWork.Doctor.AddAsync(entity);
                var result = await _unitOfWork.Commit();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<DoctorDto>> GetAllDoctorAsync()
        {
            try
            {
                var doctorsList = await _unitOfWork.Doctor.Get()
                    .Select(entity => _mapper.Map<DoctorDto>(entity))
                    .ToListAsync();

                return doctorsList;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

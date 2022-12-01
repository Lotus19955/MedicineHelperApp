using AutoMapper;
using MedicineHelper.Core;
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
        public async Task<DoctorDto> GetByIdDoctorAsync(Guid id)
        {
            try
            {
                var dto = await _unitOfWork.Doctor
                    .FindBy(entity => entity.Id.Equals(id))
                    .Select(entity => _mapper.Map<DoctorDto>(entity))
                    .FirstOrDefaultAsync();

                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> UpdateDoctorAsync(DoctorDto dto, Guid id)
        {
            try
            {
                var sourceDto = await GetByIdDoctorAsync(id);
                var patchList = new List<PatchModel>();

                if (dto.Name != sourceDto.Name)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Name),
                        PropertyValue = dto.Name
                    });
                }
                if (dto.Specializacion != sourceDto.Specializacion)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Specializacion),
                        PropertyValue = dto.Specializacion
                    });
                }
                if (dto.Rating != sourceDto.Rating)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Rating),
                        PropertyValue = dto.Rating
                    });
                }
                await _unitOfWork.Medicine.PatchAsync(id, patchList);
                return await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteDoctorAsync(Guid id)
        {
            try
            {
                var entity = await _unitOfWork.Doctor
                    .FindBy(entity => entity.Id.Equals(id))
                    .FirstOrDefaultAsync();

                _unitOfWork.Doctor.Remove(entity);
                await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

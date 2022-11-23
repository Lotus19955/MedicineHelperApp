using AutoMapper;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class ClinicService : IClinicService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClinicService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateClinicAsync(ClinicDto dto)
        {
            try
            {
                var entity = _mapper.Map<Clinic>(dto);
                await _unitOfWork.Clinic.AddAsync(entity);
                var result = await _unitOfWork.Commit();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteClinicAsync(Guid id)
        {
            try
            {
                var entity = await _unitOfWork.Clinic.FindBy(entity => entity.Id.Equals(id))
                    .Include(include => include.DoctorVisits)
                    .Include(include => include.Analyses)
                    .Include(include => include.Vaccinations)
                    .Include(include => include.Fluorographys)
                    .Include(include => include.MedicinePrescription)
                    .Include(include => include.MedicineProcedure)
                    .FirstOrDefaultAsync();

                _unitOfWork.Clinic.Remove(entity);
                await _unitOfWork.Commit();
            }

            catch (Exception)
            {
                throw new ArgumentException("", nameof(id));
            }
        }

        public async Task<ClinicDto> GetByIdClinicAsync(Guid id)
        {
            try
            {
                var dto = await _unitOfWork.Clinic
                    .FindBy(entity => entity.Id.Equals(id))
                    .Select(entity => _mapper.Map<ClinicDto>(entity))
                    .FirstOrDefaultAsync();

                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ClinicDto>> GetClinicAsync()
        {
            try
            {
                var listMedicalInstitution = await _unitOfWork.Clinic
                    .Get()
                    .Select(entity => _mapper.Map<ClinicDto>(entity))
                    .ToListAsync();

                return listMedicalInstitution;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateClinicAsync(ClinicDto dto, Guid id)
        {
            try
            {
                var sourceDto = await GetByIdClinicAsync(id);
                var patchList = new List<PatchModel>();
                if (dto != null)
                {
                    if (!dto.Name.Equals(sourceDto.Name))
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.Name),
                            PropertyValue = dto.Name
                        });
                    }
                    if (!dto.Adress.Equals(sourceDto.Adress))
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.Adress),
                            PropertyValue = dto.Adress
                        });
                    }
                    if (!dto.OperatingMode.Equals(sourceDto.OperatingMode))
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.OperatingMode),
                            PropertyValue = dto.OperatingMode
                        });
                    }
                    if (!dto.Contact.Equals(sourceDto.Contact))
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.Contact),
                            PropertyValue = dto.Contact
                        });
                    }
                }

                await _unitOfWork.Clinic.PatchAsync(id, patchList);

                return await _unitOfWork.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

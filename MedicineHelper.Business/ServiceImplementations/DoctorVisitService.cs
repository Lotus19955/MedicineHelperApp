using AutoMapper;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class DoctorVisitService : IDoctorVisitService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorVisitService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateDoctorVisitAsync(DoctorVisitDto doctorVisitDto)
        {
            try
            {
                var entity = _mapper.Map<DoctorVisit>(doctorVisitDto);
                entity.Id = Guid.NewGuid();
                await _unitOfWork.DoctorVisit.AddAsync(entity);
                var result = await _unitOfWork.Commit();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<DoctorVisitDto>> GetAllDoctorVisitAsync(Guid userId)
        {
            try
            {
                var listDoctorVisit = await _unitOfWork.DoctorVisit.Get()
                    .Where(user => user.UserId.Equals(userId))
                    .Include(entity => entity.Clinic)
                    .Include(entity => entity.Doctor)
                    .Include(entity => entity.DiseaseHistory.Disease)
                    .Include(entity => entity.Appointment)
                    .Select(doctorVisit => _mapper.Map<DoctorVisitDto>(doctorVisit))
                    .AsNoTracking()
                    .ToListAsync();

                return listDoctorVisit;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AppointmentDto> GetAppointmentAsync(Guid doctorVisitId)
        {
            try
            {

                var appointmentDto = await _unitOfWork.Appointment
                    .FindBy(entity => entity.Id.Equals(doctorVisitId))
                    .Include(entity => entity.MedicinePrescription).ThenInclude(presMed => presMed.Medicine)
                    .Include(entity => entity.Conclusion)
                    .Include(entity => entity.MedicineСheckup)
                    .Include(entity => entity.MedicineProcedure)
                    .Select(entity => _mapper.Map<AppointmentDto>(entity))
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return appointmentDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> CreateAppointment(Guid id)
        {
            try
            {
                await _unitOfWork.Appointment.AddAsync(new Appointment { Id = id });
                var result = await _unitOfWork.Commit();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DoctorVisitDto> GetDoctorVisitByIdAsync(Guid? appontmentId)
        {
            try
            {
                var doctorVisit = await _unitOfWork.DoctorVisit
                    .FindBy(entity => entity.Id.Equals(appontmentId))
                    .Select(entity =>_mapper.Map<DoctorVisitDto>(entity))
                    .FirstOrDefaultAsync();

                return doctorVisit;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateDoctorVisitAsync(DoctorVisitDto dto, Guid dtoId)
        {
            try
            {
                var sourceDto = await GetDoctorVisitByIdAsync(dtoId);
                var patchList = new List<PatchModel>();
                if(dto != null)
                {
                    if (!dto.DiseaseHistoryId.Equals(sourceDto.DiseaseHistoryId))
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.DiseaseHistoryId),
                            PropertyValue = dto.DiseaseHistoryId
                        });
                    }
                    if (!dto.DateVisit.Equals(sourceDto.DateVisit))
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.DateVisit),
                            PropertyValue = dto.DateVisit
                        });
                    }
                    if (!dto.ClinicDtoId.Equals(sourceDto.ClinicDtoId))
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.ClinicDtoId),
                            PropertyValue = dto.ClinicDtoId
                        });
                    }
                    if (!dto.DoctorDtoId.Equals(sourceDto.DoctorDtoId))
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.DoctorDtoId),
                            PropertyValue = dto.DoctorDtoId
                        });
                    }
                    if (!dto.PriceVisit.Equals(sourceDto.PriceVisit))
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.PriceVisit),
                            PropertyValue = dto.PriceVisit
                        });
                    }
                }

                await _unitOfWork.DoctorVisit.PatchAsync(dtoId, patchList);

                return await _unitOfWork.Commit();
            }
            catch (Exception)
            {

                throw;
            }      
        }

        public async Task<int> UpdateAppointmentAsync(AppointmentDto dto, Guid dtoId)
        {
            try
            {
                var sourceDto = await GetAppointmentAsync(dtoId);
                var patchList = new List<PatchModel>();
                if (dto != null)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.DescriptionOfDestination),
                        PropertyValue = dto.DescriptionOfDestination
                    });
                }

                await _unitOfWork.Appointment.PatchAsync(dtoId, patchList);

                return await _unitOfWork.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

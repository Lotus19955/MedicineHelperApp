using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelper.Core.Abstractions
{
    public interface IDoctorVisitService
    {
        Task<List<DoctorVisitDto>> GetAllDoctorVisitAsync(Guid userId);
        Task<int> CreateDoctorVisitAsync(DoctorVisitDto doctorVisitDto);
        Task<AppointmentDto> GetAppointmentAsync(Guid doctorVisitId);
        Task<int> CreateAppointment(Guid id);
        Task<DoctorVisitDto> GetDoctorVisitByIdAsync(Guid? appontmentId);
        Task<int> UpdateDoctorVisitAsync(DoctorVisitDto dto, Guid dtoId);
        Task<int> UpdateAppointmentAsync(AppointmentDto dto, Guid dtoId);
    }
}
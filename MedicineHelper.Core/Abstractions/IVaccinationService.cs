using MedicineHelper.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.Core.Abstractions
{
    public interface IVaccinationService
    {
        Task<List<VaccinationDto>> GetAllVaccinationAsync();
        Task<int> CreateVaccinationAsync(VaccinationDto dto);
        Task<VaccinationDto> GetVaccinationByIdAsync(Guid id);
    }
}

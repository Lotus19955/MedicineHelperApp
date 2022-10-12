using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase;
using System.Drawing.Text;
using AutoMapper;
using MedicineHelper.DataBase.Entites;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MedicineHelper.Data.Abstractions;

namespace MedicineHelper.Business.ServiceImplemintations
{
    public class VaccinationService : IVaccinationService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public VaccinationService(IMapper mapper, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }


        public async Task<int> CreateVaccinationAsync(VaccinationDto dto)
        {
            var entity = _mapper.Map<Vaccination>(dto);
            if (entity != null)
            {
                await _unitOfWork.Vaccinations.AddAsync(entity);
                var addingResult = await _unitOfWork.Commit();
                return addingResult;
            }
            else
            {
                throw new ArgumentException(nameof(dto));
            }
        }

        public async Task<List<VaccinationDto>> GetAllVaccinationAsync()
        {
            return (await _unitOfWork.Vaccinations.Get().Select(vaccination
                => _mapper.Map<VaccinationDto>(vaccination)).ToListAsync());
        }

        public async Task<VaccinationDto> GetVaccinationByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.Vaccinations.GetByIdAsync(id);
            var dto = _mapper.Map<VaccinationDto>(entity);

            return dto;
        }
    }
}
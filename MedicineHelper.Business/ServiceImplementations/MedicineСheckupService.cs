using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class MedicineСheckupService : IMedicineСheckupService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MedicineСheckupService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateMedicineСheckupAsync(MedicineСheckupDto dto)
        {
            try
            {
                var entity = _mapper.Map<MedicineСheckup>(dto);
                await _unitOfWork.MedicineСheckup.AddAsync(entity);
                var result = await _unitOfWork.Commit();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<MedicineСheckupDto>> GetAllMedicineСheckupAsync(Guid id)
        {
            try
            {
                var listMedicineСheckup = await _unitOfWork.MedicineСheckup
                    .FindBy(entity=>entity.UserId.Equals(id))
                    .Select(medicineСheckup => _mapper.Map<MedicineСheckupDto>(medicineСheckup))
                    .ToListAsync();
                return listMedicineСheckup;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

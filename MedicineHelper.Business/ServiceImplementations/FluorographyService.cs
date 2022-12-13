using AutoMapper;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class FluorographyService : IFluorographyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FluorographyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> CreateFluorographyAsync(FluorographyDto fluorographyDto)
        {
            try
            {
                var entity = _mapper.Map<Fluorography>(fluorographyDto);
                await _unitOfWork.Fluorography.AddAsync(entity);
                var result = await _unitOfWork.Commit();

                return result;
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }
        public async Task<List<FluorographyDto>> GetAllFluorographiesAsync(Guid userId)
        {
            try
            {
                var listFlyorographies = await _unitOfWork.Fluorography
                    .Get().Where(entity => entity.UserId.Equals(userId))
                    .Include(dto => dto.Clinic)
                    .Select(flyoragraphies => _mapper.Map<FluorographyDto>(flyoragraphies))
                    .ToListAsync();


                return listFlyorographies;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<FluorographyDto> GetFluorographyByIdAsync(Guid id)
        {
            try
            {
                var dto = await _unitOfWork.Fluorography
                    .FindBy(entity => entity.Id.Equals(id))
                    .Select(entity => _mapper.Map<FluorographyDto>(entity))
                    .FirstOrDefaultAsync();
                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteFluorographyAsync(Guid id)
        {
            try
            {
                var entity = await _unitOfWork.Fluorography
                    .FindBy(entity => entity.Id.Equals(id))
                    .FirstOrDefaultAsync();

                _unitOfWork.Fluorography.Remove(entity);
                await _unitOfWork.Commit();
            }

            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> UpdateFluorographyAsync(FluorographyDto dto)
        {
            try
            {
                var sourceDto = await GetFluorographyByIdAsync(dto.Id);
                var patchList = new List<PatchModel>();
                if (dto != null)
                {
                    if (dto.DataOfFluorography != sourceDto.DataOfFluorography)
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.DataOfFluorography),
                            PropertyValue = dto.DataOfFluorography
                        });
                    }
                    if (dto.EndDateOfFluorography != sourceDto.EndDateOfFluorography)
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.EndDateOfFluorography),
                            PropertyValue = dto.EndDateOfFluorography
                        });
                    }
                    if (dto.ClinicDtoId != sourceDto.ClinicDtoId)
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.ClinicDtoId),
                            PropertyValue = dto.ClinicDtoId
                        });
                    }
                    if (dto.NumberFluorography != sourceDto.NumberFluorography)
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.NumberFluorography),
                            PropertyValue = dto.NumberFluorography
                        });
                    }
                    if (dto.Result != sourceDto.Result)
                    {
                        patchList.Add(new PatchModel()
                        {
                            PropertyName = nameof(dto.Result),
                            PropertyValue = dto.Result
                        });
                    }

                }
                await _unitOfWork.Fluorography.PatchAsync(dto.Id, patchList);

                return await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FluorographyDto>> GetFluorographyForPeriodAsync(DateTime SearchDateStart, DateTime SearchDateEnd, Guid userId)
        {
            try
            {
                var dto = await _unitOfWork.Fluorography
                    .FindBy(entity => entity.UserId.Equals(userId))
                    .AsNoTracking()
                    .Where(entity => entity.DataOfFluorography >= SearchDateStart && entity.DataOfFluorography <= SearchDateEnd)
                    .Include(include => include.Clinic)
                    .OrderBy(entity => entity.DataOfFluorography)
                    .Select(entity => _mapper.Map<FluorographyDto>(entity))
                    .ToListAsync();

                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

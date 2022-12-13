using AutoMapper;
using HtmlAgilityPack;
using MediatR;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Data.CQS.Commands;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class MedicineService : IMedicineService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public MedicineService(IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<int> AddMedicineAsync(MedicineDto dto)
        {
            try
            {
                var entity = _mapper.Map<Medicine>(dto);
                entity.Id = Guid.NewGuid();
                await _unitOfWork.Medicine.AddAsync(entity);
                var result = await _unitOfWork.Commit();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<MedicineDto>> GetAllMedicineAsync()
        {
            try
            {
                var listDto = (await _unitOfWork.Medicine.GetAllAsync())
                    .OrderBy(entity => entity.NameOfMedicine)
                    .Select(entity => _mapper.Map<MedicineDto>(entity))
                    .ToList();

                return listDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MedicineDto> GetByIdMedicineAsync(Guid id)
        {
            try
            {
                var dto = await _unitOfWork.Medicine
                    .FindBy(entity => entity.Id.Equals(id))
                    .Select(entity => _mapper.Map<MedicineDto>(entity))
                    .FirstOrDefaultAsync();
                        
                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateMedicineAsync(MedicineDto dto, Guid id)
        {
            try
            {
                var sourceDto = await GetByIdMedicineAsync(id);
                var patchList = new List<PatchModel>();
               
                if (dto.NameOfMedicine != sourceDto.NameOfMedicine)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.NameOfMedicine),
                        PropertyValue = dto.NameOfMedicine
                    });
                }
                if (dto.Instructions != sourceDto.Instructions)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Instructions),
                        PropertyValue = dto.Instructions
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

        public async Task DeleteMedicineAsync(Guid id)
        {
            try
            {
                var entity = await _unitOfWork.Medicine
                    .FindBy(entity => entity.Id.Equals(id))
                    .FirstOrDefaultAsync();

                _unitOfWork.Medicine.Remove(entity);
                await _unitOfWork.Commit();
            }

            catch (Exception)
            {
                throw;
            }
        }
        public async Task AddMedicineInfoTablekaByAsync()
        {
            List<MedicineDto> list = new List<MedicineDto>();
            var web = new HtmlWeb();
            var htmlDoc = web.Load("https://tabletka.by/drugs");
            var alphabetSearch = htmlDoc.DocumentNode.SelectNodes("//div[@class='box inner-page']/div/a/div");
            foreach (var letter in alphabetSearch)
            {
                var htmlMedicine = web.Load($"https://tabletka.by/drugs?search={letter.InnerText.Trim()}");
                var medNod = htmlMedicine.DocumentNode.SelectNodes("//li[@class='search-result__item']");
                if (medNod != null)
                {
                    foreach (var medicine in medNod)
                    {
                        list.Add(
                        new MedicineDto
                        {
                            Id = Guid.NewGuid(),
                            NameOfMedicine = medicine.InnerText.Trim(),
                            Instructions = "https://tabletka.by" + medicine.ChildNodes[0].GetAttributeValue("href", string.Empty)
                        });
                    }
                }
            }
            await _mediator.Send(new AddMedicineDataFromTabletkaByCommand() { Medicines = list });
        }
    }
}

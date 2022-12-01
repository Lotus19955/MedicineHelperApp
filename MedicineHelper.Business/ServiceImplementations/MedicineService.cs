using AutoMapper;
using HtmlAgilityPack;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class MedicineService : IMedicineService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MedicineService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public List<string>? SearchMedicineInTabletkaBy(string nameOfMedicine)
        {
            try
            {
                var urlSearchSite = $"https://tabletka.by/search?request={nameOfMedicine}";

                var web = new HtmlWeb();
                var htmlDoc = web.Load(urlSearchSite);

                var table = htmlDoc.DocumentNode.Descendants(0)
                    .Where(node => node.Id == "base-select")
                    .FirstOrDefault();

                var links = table?.Descendants()
                    .Where(x => x.Name == "a" && x.GetAttributeValue("href", string.Empty).StartsWith("/result"))
                    .Select(x => x.GetAttributeValue("href", string.Empty))
                    .Distinct()
                    .ToList();

                return links;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> AddMedicineAsync(List<string>? listLinkMedicine)
        {
            try
            {
                var listMedicineDto = new List<MedicineDto>();
                var urlTabletkaBy = $"https://tabletka.by";
                var web = new HtmlWeb();
                foreach (var link in listLinkMedicine)
                {
                    var htmlDoc = web.Load(urlTabletkaBy + link);

                    var nameMedicine = htmlDoc.DocumentNode.Descendants()
                        .Where(x => x.Name == "h1")
                        .Select(x => x.FirstChild.InnerText)
                        .FirstOrDefault()?
                        .Replace(Environment.NewLine, string.Empty);

                    var linkToInstruction = htmlDoc.DocumentNode.Descendants()
                        .Where(x => x.Name == "a" && x.GetAttributeValue("href", string.Empty).StartsWith("/instructions"))
                        .Select(x => x.GetAttributeValue("href", string.Empty))
                        .FirstOrDefault();

                    var medicineDto = new MedicineDto()
                    {
                        NameOfMedicine = nameMedicine,
                        Instructions = urlTabletkaBy + linkToInstruction
                    };

                    listMedicineDto.Add(medicineDto);
                }

                var existsMedicines = await _unitOfWork.Medicine.Get()
                    .Select(medicine => medicine.NameOfMedicine)
                    .Distinct()
                    .ToArrayAsync();

                var entities = listMedicineDto.Where(dto => !existsMedicines.Contains(dto.NameOfMedicine))
                    .Select(dto => _mapper.Map<Medicine>(dto)).ToList();

                await _unitOfWork.Medicine.AddRangeAsync(entities);

                return await _unitOfWork.Commit();
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
            List<MedicineDto> dtoList = new List<MedicineDto>();
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
                        dtoList.Add(
                        new MedicineDto
                        {
                            Id = Guid.NewGuid(),
                            NameOfMedicine = medicine.InnerText.Trim(),
                            Instructions = "https://tabletka.by" + medicine.ChildNodes[0].GetAttributeValue("href", string.Empty)
                        });
                    }
                }
            }
            var entities = dtoList.Select(dto => _mapper.Map<Medicine>(dto));
            await _unitOfWork.Medicine.AddRangeAsync(entities);
            await _unitOfWork.Commit();
        }
    }
}

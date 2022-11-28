using AutoMapper;
using HtmlAgilityPack;
using MediatR;
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
        private readonly IMediator _mediator;

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
                throw new ArgumentException("Clinic doen't exist", nameof(id));
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

        //public async Task AddClinicInfoFromExternalSourcesAsync()
        //{
        //    var sources = await _unitOfWork.Clinic.GetAllAsync();

        //    foreach (var source in sources)
        //    {
        //        await AddClinicInfoSite103ByAsync();
        //    }
        //}

        public async Task AddClinicInfoSite103ByAsync(ClinicDto clinicDto)
        {
            try
            {
                //var clinic = await _mediator.Send(new GetByIdClinicAsync { Id = clinicId });

                //if (clinic == null)
                //{
                //    throw new ArgumentException($"Clinic with id: {clinicId} doesn't exists",
                //        nameof(clinicId));
                //}

                //TODO NEED REFACTOR
                //var web = new HtmlWeb();
                //var htmlDoc = web.Load("https://www.103.by/cat/med/bolnitsy");
                //var nodes = htmlDoc.DocumentNode.Descendants(0).Where(n => n.HasClass("PlaceList__itemWrapper"));


                //List<ClinicDto> ClinicList = new List<ClinicDto>();
                //foreach (var node in nodes) 
                //{
                //    var name = node.Descendants(0).Where(n => n.SelectNodes("//a[Place__mainTitle")));
                //}
                //////.Descendants("div")
                //.Where(n => n.HasClass("PlaceList__itemWrapper--content"));
                //var res = nodes.SelectSingleNode("[contains(@class='Place__mainTitle']").InnerHtml;
                //if (nodes.Any())
                //{

                //        //nodes.DocumentNode.Descendants("div").SelectSingleNode("[contains(@class='Place__mainTitle']").InnerHtml;
                //        //.ChildNodes
                //        //.Where(node => (node.Name.Equals("a") || node.Name.Equals("div"))
                //        //                && node.HasClass("Place__mainTitle")
                //        //                && node.Attributes["style"] == null)
                //        //.Select(node => node.OuterHtml)
                //        //.Aggregate((i, j) => i + Environment.NewLine + j);

                //    var clinicAdress = nodes.FirstOrDefault()?
                //        .ChildNodes
                //        .Where(node => (node.Name.Equals("a") || node.Name.Equals("div") || node.Name.Equals("span"))
                //                        && node.HasClass("ContactsPopup__metaMain")
                //                        && node.Attributes["style"] == null)
                //        .Select(node => node.InnerHtml)
                //        .Aggregate((i, j) => i + Environment.NewLine + j);

                //    var clinicOperatingMode = nodes.FirstOrDefault()?
                //        .ChildNodes
                //        .Where(node => (node.Name.Equals("a") || node.Name.Equals("div") || node.Name.Equals("span"))
                //                        && node.HasClass("ContactsPopupOpening__rowDayInner") //days
                //                        && node.HasClass("ContactsPopupOpening__subMain") //time
                //                        && node.Attributes["style"] == null)
                //        .Select(node => node.OuterHtml)
                //        .Aggregate((i, j) => i + Environment.NewLine + j);

                //    var clinicContact = nodes.FirstOrDefault()?
                //        .ChildNodes
                //        .Where(node => (node.Name.Equals("a") || node.Name.Equals("div") || node.Name.Equals("span"))
                //                        && node.HasClass("PhoneLink__number")
                //                        && node.Attributes["style"] == null)
                //        .Select(node => node.OuterHtml)
                //        .Aggregate((i, j) => i + Environment.NewLine + j);

                //    var clinicUrl = nodes.FirstOrDefault()?
                //        .ChildNodes
                //        .Where(node => (node.Name.Equals("a") || node.Name.Equals("div") || node.Name.Equals("span"))
                //                        && node.HasClass("Link")
                //                        && node.Attributes["style"] == null)
                //        .Select(node => node.OuterHtml)
                //        .Aggregate((i, j) => i + Environment.NewLine + j);

                //clinicDto.Name = nodes.Where(n => n.HasClass("Place__mainTitle"));
                //    clinicDto.Adress = clinicAdress;
                //    clinicDto.Contact = clinicContact;
                //    clinicDto.OperatingMode= clinicOperatingMode;
                //    clinicDto.SourceClinicUrl = clinicUrl;
                //    //await _mediator.Send(new UpdateArticleTextCommand() { Id = articleId, Text = articleText });
                //}
            }
                catch (Exception ex)
                {
                    throw;
                }
}
    }
}

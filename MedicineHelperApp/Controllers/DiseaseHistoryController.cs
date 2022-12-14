using AutoMapper;
using MedicineHelper.Business.ServicesImplementations;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Core.Enums;
using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicineHelper.Controllers
{
    [Authorize(Roles = "User")]
    public class DiseaseHistoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDiseaseHistoryService _diseaseHistoryService;
        private readonly IUserService _userService;
        private readonly IDoctorVisitService _doctorVisitService;
        public DiseaseHistoryController(IMapper mapper, IDiseaseHistoryService diseaseHistoryService,
            IUserService userService, IDoctorVisitService doctorVisitService)
        {
            _mapper = mapper;
            _diseaseHistoryService = diseaseHistoryService;
            _userService = userService;
            _doctorVisitService = doctorVisitService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var emailUser = HttpContext.User.Identity.Name;
                var userDto = _userService.GetUserByEmailAsync(emailUser);
                var listDiseaseHistory = await _diseaseHistoryService.GetAllDiseaseHistoryAsync(userDto.Id);

                return View(listDiseaseHistory);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid id)
        {
            try
            {
                var diseaseDto = await _diseaseHistoryService.GetAllDiseaseAsync();

                var model = new DiseaseHistoryModel();
                model.AppointmentId = id;
                var severityOfTheIllness = new SeverityOfTheIllness();
                model.DiseaseList = new SelectList(diseaseDto, "Id", "NameOfDisease");
                model.SeverityOfTheIllnessList = severityOfTheIllness;

                model.ReturnUrl = Request.Headers["Referer"].ToString();
                if (model.ReturnUrl == "https://localhost:7226/DiseaseHistory/CreateDisease")
                {
                    model.ReturnUrl = "https://localhost:7226/DiseaseHistory/Index";
                }

                return View(model);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(DiseaseHistoryModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var emailUser = HttpContext.User.Identity.Name;
                    var userDto =  _userService.GetUserByEmailAsync(emailUser);
                    model.UserId = userDto.Id;

                    var dto = _mapper.Map<DiseaseHistoryDto>(model);
                    var diseaseHistoryLastId = await _diseaseHistoryService.CreateDiseaseHistoryAsync(dto);

                    if (model.AppointmentId != null)
                    {
                        var dtoDoctorVisit = await _doctorVisitService.GetDoctorVisitByIdAsync(model.AppointmentId);
                        //dtoDoctorVisit.DiseaseHistoryId = diseaseHistoryLastId;
                        await _doctorVisitService.UpdateDoctorVisitAsync(dtoDoctorVisit, dtoDoctorVisit.Id);
                    }
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult CreateDisease()
        {
            try
            {
                var model = new DiseaseModel();
                model.ReturnUrl = Request.Headers["Referer"].ToString();

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDisease(DiseaseModel model)
        {
            try
            {
                var dto = _mapper.Map<DiseaseDto>(model);
                await _diseaseHistoryService.CreateDiseaseAsync(dto);

                return Redirect(model.ReturnUrl);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
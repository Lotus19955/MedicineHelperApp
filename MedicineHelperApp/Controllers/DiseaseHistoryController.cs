using AutoMapper;
using MedicineHelper.Business.ServicesImplementations;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Core.Enums;
using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReflectionIT.Mvc.Paging;
using Serilog;

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
        public async Task<IActionResult> Index(DateTime SearchDateStart, DateTime SearchDateEnd, int pageIndex = 1)
        {
            try
            {
                var emailUser = HttpContext.User.Identity.Name;
                var userDto = _userService.GetUserByEmailAsync(emailUser);
                if (SearchDateStart == DateTime.MinValue && SearchDateEnd == DateTime.MinValue)
                {
                    var listDiseaseHistory = await _diseaseHistoryService.GetAllDiseaseHistoryForUserAsync(userDto.Id);
                    var model = PagingList.Create(listDiseaseHistory, 5, pageIndex);
                    return View(model);
                }
                else
                {
                    var listDiseaseHistory = await _diseaseHistoryService.GetAllDiseaseHistoryForUserAsyncForPeriod(SearchDateStart, SearchDateEnd, userDto.Id);
                    var model = PagingList.Create(listDiseaseHistory, 5, pageIndex);

                    return View(model);
                }
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
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
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
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

                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
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
            catch (Exception e) { Log.Error($"{e.Message}"); return StatusCode(500); }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDisease(DiseaseModel model)
        {
            try
            {
                var dto = _mapper.Map<DiseaseDto>(model);
                await _diseaseHistoryService.CreateDiseaseAsync(dto);

                return RedirectToAction("Create", "DiseaseHistory");
            }
            catch (Exception e) { Log.Error($"{e.Message}"); return StatusCode(500); }
        }

        [HttpGet]
        public IActionResult DeleteDiseaseHistory(Guid id, string name)
        {
            try
            {
                var model = new DiseaseModel();
                model.NameOfDisease = name;
                model.Id = id;
                return View(model);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDiseaseHistory(Guid id)
        {
            try
            {
                await _diseaseHistoryService.DeleteDiseaseHistory(id);

                return RedirectToAction("Index", "DiseaseHistory");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }
    }
}
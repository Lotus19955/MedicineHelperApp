using AutoMapper;
using MedicineHelper.Business.ServicesImplementations;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReflectionIT.Mvc.Paging;
using Serilog;

namespace MedicineHelper.Controllers
{
    [Authorize(Roles = "User")]
    public class MedicineСheckupController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMedicineСheckupService _medicineСheckupService;
        private readonly IUserService _userService;
        private readonly IClinicService _clinicService;

        public MedicineСheckupController(IMapper mapper, IMedicineСheckupService medicineCheckupService,
            IUserService userService, IClinicService clinicService)
        {
            _mapper = mapper;
            _medicineСheckupService = medicineCheckupService;
            _userService = userService;
            _clinicService = clinicService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(DateTime SearchDateStart, DateTime SearchDateEnd, int pageIndex = 1)
        {
            try
            {
                var emailUser = HttpContext.User.Identity?.Name;
                var userDto = _userService.GetUserByEmailAsync(emailUser);
                if (SearchDateStart == DateTime.MinValue && SearchDateEnd == DateTime.MinValue)
                {
                    var listMedicineCheckup = await _medicineСheckupService.GetAllMedicineСheckupAsync(userDto.Id);

                    var model = PagingList.Create(listMedicineCheckup, 5, pageIndex);
                    return View(model);
                }
                else
                {
                    var listMedicineCheckup = await _medicineСheckupService.GetPeriodMedicineСheckupAsync(SearchDateStart, SearchDateEnd, userDto.Id);
                    var model = PagingList.Create(listMedicineCheckup, 5, pageIndex);

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
        public async Task<IActionResult> Create(Guid? id)
        {
            try
            {
                var clinicDto = await _clinicService.GetClinicAsync();
                var model = new MedicineСheckupModel();
                model.AppointmentId = id;
                model.ClinicList = new SelectList(clinicDto, "Id", "Name");
                model.ReturnUrl = Request.Headers["Referer"].ToString();
                if (model.ReturnUrl == "https://localhost:7226/Clinic/Create")
                {
                    model.ReturnUrl = "https://localhost:7226/MedicineCheckup/Index";
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
        public async Task<IActionResult> Create(MedicineСheckupModel model)
        {
            try
            {
                var userEmail = HttpContext.User.Identity.Name;
                var userDto = _userService.GetUserByEmailAsync(userEmail);
                model.UserId = userDto.Id;
                var dto = _mapper.Map<MedicineСheckupDto>(model);
                await _medicineСheckupService.CreateMedicineСheckupAsync(dto);

                return Redirect(model.ReturnUrl);
            }
            catch (Exception e) { Log.Error($"{e.Message}"); return StatusCode(500); }
        }
        [HttpGet]
        public IActionResult Delete(Guid id, string name)
        {
            try
            {
                var model = new MedicineСheckupModel();
                model.NameOfMedicalCheckUp = name;
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
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _medicineСheckupService.DeleteMedicineСheckup(id);

                return RedirectToAction("Index", "MedicineСheckup");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }
    }
}

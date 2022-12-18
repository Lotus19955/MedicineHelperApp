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
    public class DoctorVisitController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDoctorVisitService _doctorVisitService;
        private readonly IUserService _userService;
        private readonly IDoctorService _doctorService;
        private readonly IClinicService _clinicService;
        private readonly IConclusionService _conclusionService;

        public DoctorVisitController(IMapper mapper, IDoctorVisitService doctorVisitService,
            IUserService userService, IDoctorService doctorService, IClinicService clinicService, IConclusionService conclusionService)
        {
            _mapper = mapper;
            _doctorVisitService = doctorVisitService;
            _userService = userService;
            _doctorService = doctorService;
            _clinicService = clinicService;
            _conclusionService = conclusionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index( DateTime SearchDateStart, DateTime SearchDateEnd, int pageIndex = 1)
        {
            try
            {
                var emailUser = HttpContext.User.Identity.Name;
                var userDto = _userService.GetUserByEmailAsync(emailUser);

                if (SearchDateStart == DateTime.MinValue && SearchDateEnd == DateTime.MinValue)
                {
                    var listDoctorVisits = await _doctorVisitService.GetAllDoctorVisitAsync(userDto.Id);

                    var pages = PagingList.Create(listDoctorVisits, 5, pageIndex);
                    return View(pages);
                }
                else
                {
                    var listDoctorVisits = await _doctorVisitService.GetPeriodDoctorVisitAsync(SearchDateStart, SearchDateEnd, userDto.Id);
                    var pages = PagingList.Create(listDoctorVisits, 5, pageIndex);

                    return View(pages);
                }
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var doctorsDto = await _doctorService.GetAllDoctorAsync();
                var clinicDto = await _clinicService.GetClinicAsync();

                var model = new DoctorVisitModel();
                model.ClinicList = new SelectList(clinicDto, "Id", "Name");
                model.DoctorList = new SelectList(doctorsDto, "Id", "Name");
                if (model.ReturnUrl == "https://localhost:7226/DoctorVisit/CreateDoctor")
                {
                    model.ReturnUrl = "https://localhost:7226/DoctorVisit/Index";
                }
                if (model.ReturnUrl == "https://localhost:7226/Clinic/Create")
                {
                    model.ReturnUrl = "https://localhost:7226/DoctorVisit/Index";
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
        public async Task<IActionResult> Create(DoctorVisitModel doctorVisitModel)
        {
            try
            {
                var emailUser = HttpContext.User.Identity.Name;
                var userDto = _userService.GetUserByEmailAsync(emailUser);
                doctorVisitModel.UserId = userDto.Id;

                var doctorVisitDto = _mapper.Map<DoctorVisitDto>(doctorVisitModel);
                await _doctorVisitService.CreateDoctorVisitAsync(doctorVisitDto);

                return RedirectToAction("Index");

            }
            catch (Exception e) { Log.Error($"{e.Message}"); return StatusCode(500); }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var doctorsDto = await _doctorService.GetAllDoctorAsync();
                var clinicDto = await _clinicService.GetClinicAsync();

                var model = new DoctorVisitModel();
                model.Id = id;
                model.ClinicList = new SelectList(clinicDto, "Id", "Name");
                model.DoctorList = new SelectList(doctorsDto, "Id", "Name");
                model.ReturnUrl = Request.Headers["Referer"].ToString();
                if (model.ReturnUrl == "https://localhost:7226/DoctorVisit/CreateDoctor")
                {
                    model.ReturnUrl = "https://localhost:7226/DoctorVisit/Index";
                }
                if (model.ReturnUrl == "https://localhost:7226/Clinic/Create")
                {
                    model.ReturnUrl = "https://localhost:7226/DoctorVisit/Index";
                }

                return View(model);

            }
            catch (Exception e) { Log.Error($"{e.Message}"); return StatusCode(500); }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DoctorVisitModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    var dto = await _doctorVisitService.GetDoctorVisitByIdAsync(model.Id);
                    dto.DateVisit = model.DateVisit;
                    dto.ClinicDtoId = model.ClinicId;
                    dto.DoctorDtoId = model.DoctorId;
                    dto.PriceVisit = model.PriceVisit;
                    await _doctorVisitService.UpdateDoctorVisitAsync(dto, dto.Id);

                    return Redirect(model.ReturnUrl);
                }

                return View(model);
            }
            catch (Exception e) { Log.Error($"{e.Message}"); return StatusCode(500); }
        }

        [HttpGet]
        public IActionResult AddOrEditDescriptionAppointment(Guid id)
        {
            try
            {
                var model = new AppointmentModel();
                model.Id = id;
                model.ReturnUrl = Request.Headers["Referer"].ToString();

                return View(model);
            }
            catch (Exception e) { Log.Error($"{e.Message}"); return StatusCode(500); }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEditDescriptionAppointment(AppointmentModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dto = await _doctorVisitService.GetAppointmentAsync(model.Id);
                    dto.DescriptionOfDestination = model.DescriptionOfDestination;
                    await _doctorVisitService.UpdateAppointmentAsync(dto, dto.Id);

                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e) { Log.Error($"{e.Message}"); return StatusCode(500); }
        }

        [HttpGet] 
        public async Task<IActionResult> Appointment(Guid id, string? nameOfDisease)
        {
            try
            {
                var appointmentDto = await _doctorVisitService.GetAppointmentAsync(id);
                ViewBag.NameOfDisease = nameOfDisease;

                return View(appointmentDto);
            }
            catch (Exception e) { Log.Error($"{e.Message}"); return StatusCode(500); }
        }

        [HttpGet]
        public async Task<IActionResult> CreateAppointment(Guid id, string? nameOfDisease)
        {
            try
            {
                await _doctorVisitService.CreateAppointment(id);

                return RedirectToAction("Appointment", new {id, nameOfDisease});
            }
            catch (Exception e) { Log.Error($"{e.Message}"); return StatusCode(500); }
        }

        [HttpGet]
        public IActionResult CreateDoctor()
        {
            try
            {
                var model = new DoctorModel();
                model.ReturnUrl = Request.Headers["Referer"].ToString();

                return View(model);
            }
            catch (Exception e) { Log.Error($"{e.Message}"); return StatusCode(500); }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(DoctorModel model)
        {
            try
            {
                var dto = _mapper.Map<DoctorDto>(model);
                await _doctorService.CreateDoctorAsync(dto);

                return Redirect(model.ReturnUrl);
            }
            catch (Exception e) { Log.Error($"{e.Message}"); return StatusCode(500); }
        }

        [HttpGet]
        public IActionResult Delete(Guid id, string name)
        {
            try
            {
                var model = new DoctorVisitModel();
                model.DoctorName = name;
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
                await _doctorService.Delete(id);

                return RedirectToAction("Index", "DoctorVisit");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }
    }
}

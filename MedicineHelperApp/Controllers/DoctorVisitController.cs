using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public DoctorVisitController(IMapper mapper, IDoctorVisitService doctorVisitService,
            IUserService userService, IDoctorService doctorService, IClinicService clinicService)
        {
            _mapper = mapper;
            _doctorVisitService = doctorVisitService;
            _userService = userService;
            _doctorService = doctorService;
            _clinicService = clinicService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var emailUser = HttpContext.User.Identity.Name;
                var userDto = await _userService.GetUserByEmailAsync(emailUser);
                var listDoctorVisits = await _doctorVisitService.GetAllDoctorVisitAsync(userDto.Id);
                
                return View(listDoctorVisits);
            }
            catch (Exception)
            {

                throw;
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
                model.ClinicList = new SelectList(clinicDto, "Id", "NameClinic");
                model.DoctorList = new SelectList(doctorsDto, "Id", "FullNameDoctor");
                //TODO fix
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
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorVisitModel doctorVisitModel)
        {
            try
            {
                var emailUser = HttpContext.User.Identity.Name;
                var userDto = await _userService.GetUserByEmailAsync(emailUser);
                doctorVisitModel.UserId = userDto.Id;

                var doctorVisitDto = _mapper.Map<DoctorVisitDto>(doctorVisitModel);
                await _doctorVisitService.CreateDoctorVisitAsync(doctorVisitDto);

                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
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
                model.ClinicList = new SelectList(clinicDto, "Id", "NameClinic");
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
            catch (Exception)
            {

                throw;
            }
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
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult AddOrEditDescriptionAppointment(Guid id)
        {
            try
            {
                var model = new AppointmentModel();
                model.Id = id;
                model.ReturnUrl = Request.Headers["Referer"].ToString();
                //if (model.ReturnUrl == "https://localhost:7226/DoctorVisit/AddOrEditDescriptionAppointment")
                //{
                //    model.ReturnUrl = "https://localhost:7226/DoctorVisit/Appointment";
                //}

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
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
            catch (Exception)
            {

                throw;
            }
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
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateAppointment(Guid id, string? nameOfDisease)
        {
            try
            {
                await _doctorVisitService.CreateAppointment(id);

                return RedirectToAction("Appointment", new {id, nameOfDisease});
            }
            catch (Exception)
            {
                throw;
            }
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
            catch (Exception)
            {

                throw;
            }
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
            catch (Exception)
            {

                throw;
            }
        }

    }
}

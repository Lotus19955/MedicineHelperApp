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
        public async Task<IActionResult> Index()
        {
            try
            {
                var emailUser = HttpContext.User.Identity.Name;
                var userDto = _userService.GetUserByEmailAsync(emailUser);
                var listMedicineCheckup = await _medicineСheckupService.GetAllMedicineСheckupAsync(userDto.Id);

                return View(listMedicineCheckup);
            }
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}

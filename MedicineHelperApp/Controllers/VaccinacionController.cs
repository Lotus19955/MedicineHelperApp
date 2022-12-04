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
    public class VaccinacionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVaccinationService _vaccinationService;
        private readonly IUserService _userService;
        private readonly IClinicService _clinicService;

        public VaccinacionController(IMapper mapper, IVaccinationService vaccinationService,
            IUserService userService, IClinicService clinicService)
        {
            _mapper = mapper;
            _vaccinationService = vaccinationService;
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
                var listVaccinations = await _vaccinationService.GetAllVaccinationsAsync(userDto.Id);

                return View(listVaccinations);
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
                var medicalInstitutionsDto = await _clinicService.GetClinicAsync();

                var model = new VaccinationModel();
                model.ClinicList = new SelectList(medicalInstitutionsDto, "Id", "NameClinic");
                model.ReturnUrl = Request.Headers["Referer"].ToString();
                if (model.ReturnUrl == "https://localhost:7226/Clinic/Create")
                {
                    model.ReturnUrl = "https://localhost:7226/Vaccination/Index";
                }

                return View(model);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(VaccinationModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var emailUser = HttpContext.User.Identity.Name;
                    var userDto = _userService.GetUserByEmailAsync(emailUser);
                    model.UserId = userDto.Id;

                    var dto = _mapper.Map<VaccinationDto>(model);
                    await _vaccinationService.CreateVaccinationAsync(dto);

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

    }
}

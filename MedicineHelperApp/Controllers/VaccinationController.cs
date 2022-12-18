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
    public class VaccinationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVaccinationService _vaccinationService;
        private readonly IUserService _userService;
        private readonly IClinicService _clinicService;

        public VaccinationController(IMapper mapper, IVaccinationService vaccinationService,
            IUserService userService, IClinicService clinicService)
        {
            _mapper = mapper;
            _vaccinationService = vaccinationService;
            _userService = userService;
            _clinicService = clinicService;
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
                    var listVaccinations = await _vaccinationService.GetAllVaccinationsAsync(userDto.Id);

                    var model = PagingList.Create(listVaccinations, 5, pageIndex);
                    return View(model);
                }
                else
                {
                    var listVaccinations = await _vaccinationService.GetPeriodVaccinationsAsync(SearchDateStart, SearchDateEnd, userDto.Id);
                    var model = PagingList.Create(listVaccinations, 5, pageIndex);

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
        public async Task<IActionResult> Create()
        {
            try
            {
                var medicalInstitutionsDto = await _clinicService.GetClinicAsync();

                var model = new VaccinationModel();
                model.ClinicList = new SelectList(medicalInstitutionsDto, "Id", "Name");
                model.ReturnUrl = Request.Headers["Referer"].ToString();
                if (model.ReturnUrl == "https://localhost:7226/Clinic/Create")
                {
                    model.ReturnUrl = "https://localhost:7226/Vaccination/Index";
                }

                return View(model);

            }
            catch(Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
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
            catch (Exception e) { Log.Error($"{e.Message}"); return StatusCode(500); }
        }

        [HttpGet]
        public IActionResult Delete(Guid id, string name)
        {
            try
            {
                var model = new VaccinationModel();
                model.NameOfVaccine = name;
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
                await _vaccinationService.Delete(id);

                return RedirectToAction("Index", "Vaccination");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }
    }
}

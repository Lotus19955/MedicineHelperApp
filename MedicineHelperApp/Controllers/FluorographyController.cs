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
    public class FluorographyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFluorographyService _fluorographyService;
        private readonly IUserService _userService;
        private readonly IClinicService _clinicService;
        public FluorographyController(IFluorographyService fluorographyService, IMapper mapper,
            IUserService userService, IClinicService clinicService)
        {
            _fluorographyService = fluorographyService;
            _mapper = mapper;
            _userService = userService;
            _clinicService = clinicService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var emailUser = HttpContext.User.Identity?.Name;
                var dtoUser = _userService.GetUserByEmailAsync(emailUser);
                var fluorographies = await _fluorographyService.GetAllFluorographiesAsync(dtoUser.Id);

                return View(fluorographies);
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
                var clinic = await _clinicService.GetClinicAsync();

                var fluorographyModel = new FluorographyModel();
                fluorographyModel.ClinicList = new SelectList(clinic, "Id", "NameClinic");

                return View(fluorographyModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(FluorographyModel fluorographyModel)
        {
            try
            {
                var userEmail = HttpContext.User.Identity.Name;
                var dtoUser = _userService.GetUserByEmailAsync(userEmail);
                fluorographyModel.UserId = dtoUser.Id;
                var fluorographyDto = _mapper.Map<FluorographyDto>(fluorographyModel);
                await _fluorographyService.CreateFluorographyAsync(fluorographyDto);

                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

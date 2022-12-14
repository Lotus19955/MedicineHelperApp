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
    public class MedicineProcedureController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMedicineProcedureService _medicineProcedureService;
        private readonly IClinicService _clinicService;
        private readonly IUserService _userService;

        public MedicineProcedureController(IMapper mapper, IMedicineProcedureService medicineProcedureService,
            IUserService userService, IClinicService clinicService)
        {
            _mapper = mapper;
            _medicineProcedureService = medicineProcedureService;
            _userService = userService;
            _clinicService = clinicService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var userEmail = HttpContext.User.Identity.Name;
                var userDto = _userService.GetUserByEmailAsync(userEmail);
                var dto = await _medicineProcedureService.GetAllMedicineProcedureAsync(userDto.Id);

                return View(dto);
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

                var medicineProcedureModel = new MedicineProcedureModel();
                medicineProcedureModel.AppointmentId = id;
                medicineProcedureModel.ClinicList = new SelectList(clinicDto, "Id", "Name");
                medicineProcedureModel.ReturnUrl = Request.Headers["Referer"].ToString();

                return View(medicineProcedureModel);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicineProcedureModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var emailUser = HttpContext.User.Identity.Name;
                    var userDto = _userService.GetUserByEmailAsync(emailUser);
                    model.UserId = userDto.Id;

                    var dto = _mapper.Map<MedicineProcedureDto>(model);
                    await _medicineProcedureService.CreateMedicineProcedureAsync(dto);

                    var returnUrl = model.ReturnUrl;

                    return Redirect(returnUrl);
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

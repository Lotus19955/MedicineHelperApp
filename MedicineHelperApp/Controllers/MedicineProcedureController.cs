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
        public async Task<IActionResult> Index(DateTime SearchDateStart, DateTime SearchDateEnd, int pageIndex = 1)
        {
            try
            {
                var emailUser = HttpContext.User.Identity?.Name;
                var userDto = _userService.GetUserByEmailAsync(emailUser);
                if (SearchDateStart == DateTime.MinValue && SearchDateEnd == DateTime.MinValue)
                {
                    var listMedicineProcedure = await _medicineProcedureService.GetAllMedicineProcedureAsync(userDto.Id);

                    var model = PagingList.Create(listMedicineProcedure, 5, pageIndex);
                    return View(model);
                }
                else
                {
                    var listMedicineProcedure = await _medicineProcedureService.GetPeriodMedicineProcedureAsync(SearchDateStart, SearchDateEnd, userDto.Id);
                    var model = PagingList.Create(listMedicineProcedure, 5, pageIndex);

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

                var medicineProcedureModel = new MedicineProcedureModel();
                medicineProcedureModel.AppointmentId = id;
                medicineProcedureModel.ClinicList = new SelectList(clinicDto, "Id", "Name");
                medicineProcedureModel.ReturnUrl = Request.Headers["Referer"].ToString();

                return View(medicineProcedureModel);

            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
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
            catch (Exception e) { Log.Error($"{e.Message}"); return StatusCode(500); }
        }
        [HttpGet]
        public IActionResult Delete(Guid id, string name)
        {
            try
            {
                var model = new MedicineProcedureModel();
                model.NameOfProcedure = name;
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
                await _medicineProcedureService.Delete(id);

                return RedirectToAction("Index", "MedicineProcedure");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

    }
}

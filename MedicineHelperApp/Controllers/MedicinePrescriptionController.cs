using AutoMapper;
using MedicineHelper.Business.ServicesImplementations;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;

namespace MedicineHelper.Controllers
{
    //[Authorize(Roles = "user")]
    [Authorize]
    public class MedicinePrescriptionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMedicinePrescriptionService _medicinePrescriptionService;
        private readonly IUserService _userService;
        private readonly IMedicineService _medicineService;

        public MedicinePrescriptionController(IMapper mapper, IMedicinePrescriptionService medicinePrescriptionService,
            IUserService userService, IMedicineService medicineService)
        {
            _mapper = mapper;
            _medicinePrescriptionService = medicinePrescriptionService;
            _userService = userService;
            _medicineService = medicineService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var emailUser = HttpContext.User.Identity?.Name;
                var userDto = _userService.GetUserByEmailAsync(emailUser);
                var listMedicinePrescription = await _medicinePrescriptionService.GetAllMedicinePrescriptionAsync(userDto.Id);

                return View(listMedicinePrescription);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync(Guid id)
        {
            try
            {
                var medicines = await _medicineService.GetAllMedicineAsync();
                var model = new MedicinePrescriptionModel();
                model.AppointmentId = id;
                model.MedicineList = new SelectList(medicines, "NameOfMedicine", "NameOfMedicine");
                model.ReturnUrl = Request.Headers["Referer"].ToString();

                return View(model);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicinePrescriptionModel model)
        {
            try
            {
                var userEmail = HttpContext.User.Identity.Name;
                var userDto = _userService.GetUserByEmailAsync(userEmail);
                var dto = _mapper.Map<MedicinePrescriptionDto>(model);
                dto.UserId = userDto.Id;
                await _medicinePrescriptionService.CreateMedicinePrescriptionAsync(dto);

                return Redirect(model.ReturnUrl);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }
        [HttpGet]
        public IActionResult Delete(MedicinePrescriptionModel model)
        {
            try
            {
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
                await _medicinePrescriptionService.DeleteMedicinePrescriptionAsync(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }
    }
}

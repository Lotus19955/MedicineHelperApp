using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MedicineHelper.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IClinicService _clinicService;
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;

        public AdminController(IMapper mapper, IUserService userService, IClinicService clinicService, IMedicineService medicineService)
        {
            _mapper = mapper;
            _userService = userService;
            _clinicService = clinicService;
            _medicineService = medicineService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var usersDto = await _userService.GetAllUserAsync();

                return View(usersDto);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetClinic()
        {
            try
            {
                var clinicDto = await _clinicService.GetClinicAsync();

                return View(clinicDto);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMedicines()
        {
            try
            {
                var listDto = await _medicineService.GetAllMedicineAsync();

                return View(listDto);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult DeleteMedicine(Guid id, string nameOfMedicine)
        {
            try
            {
                var model = new MedicineModel();
                model.NameOfMedicine = nameOfMedicine;
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
        public async Task<IActionResult> DeleteMedicine(Guid id)
        {
            try
            {
                await _medicineService.DeleteMedicineAsync(id);

                return RedirectToAction("GetMedicines");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

       

        [HttpGet]
        public IActionResult DeleteUser(Guid id, string userEmail)
        {
            try
            {
                var model = new UserModel();
                model.Email = userEmail;
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
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);

                return RedirectToAction("GetUsers");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult DeleteClinic(Guid id, string nameClinic)
        {
            try
            {
                var model = new ClinicModel();
                model.NameClinic = nameClinic;
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
        public async Task<IActionResult> DeleteClinic(Guid id)
        {
            try
            {
                await _clinicService.DeleteClinicAsync(id);

                return RedirectToAction("GetClinic");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        
        

        [HttpGet]
        public IActionResult EditClinic(Guid id, string nameClinic, string adress, string? operatingMode, string? contact)
        {
            try
            {
                var model = new ClinicModel();
                model.NameClinic = nameClinic;
                model.Adress = adress;
                model.OperatingMode = operatingMode;
                model.Contact = contact;
                model.Id = id;

                return View(model);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult AddClinic()
        {
            try
            {
                var model = new ClinicModel();

                return View();
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddClinic(ClinicModel model)
        {
            try
            {
                var result = await _clinicService.CreateClinicAsync(_mapper.Map<ClinicDto>(model));

                return RedirectToAction("GetMedicines");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditClinic(ClinicModel model)
        {
            try
            {
                var dto = await _clinicService.GetByIdClinicAsync(model.Id);
                dto.Name = model.NameClinic;
                dto.Adress = model.Adress;
                dto.OperatingMode = model.OperatingMode;
                dto.Contact = model.Contact;

                await _clinicService.UpdateClinicAsync(dto, dto.Id);

                return RedirectToAction("GetClinic");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditMedicine(MedicineModel model)
        {
            try
            {
                var dto = await _medicineService.GetByIdMedicineAsync(model.Id);
                dto.NameOfMedicine = model.NameOfMedicine;
                dto.Instructions = model.LinkToInstructions;

                await _medicineService.UpdateMedicineAsync(dto, dto.Id);

                return RedirectToAction("GetMedicines");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult AddMedicine()
        {
            try
            {
                var model = new MedicineModel();

                return View();
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMedicine(MedicineModel model)
        {
            try
            {
                    var result = await _medicineService.AddMedicineAsync(_mapper.Map<MedicineDto>(model));

                    return RedirectToAction("GetMedicines");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }
    }
}
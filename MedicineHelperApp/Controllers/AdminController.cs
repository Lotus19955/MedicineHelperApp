using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }
        
        [HttpGet]
        public IActionResult ShowDeleteUser(Guid id, string userEmail)
        {
            try
            {
                var model = new UserModel();
                model.Email = userEmail;
                model.Id = id;

                return View(model);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public IActionResult ShowDeleteClinic(Guid id, string nameClinic)
        {
            try
            {
                var model = new ClinicModel();
                model.NameClinic = nameClinic;
                model.Id = id;

                return View(model);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ShowDeleteMedicine(Guid id, string nameOfMedicine)
        {
            try
            {
                var model = new MedicineModel();
                model.NameOfMedicine = nameOfMedicine;
                model.Id = id;

                return View(model);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ShowEditClinic(Guid id, string nameClinic, string adress, string? operatingMode, string? contact)
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
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ShowEditMedicine(Guid id, string nameMedicine, string? linkToInstructions)
        {
            try
            {
                var model = new MedicineModel();
                model.NameOfMedicine = nameMedicine;
                model.LinkToInstructions = linkToInstructions;
                model.Id = id;

                return View(model);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
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
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
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
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
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
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditMedicalInstitution(ClinicModel model)
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
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
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
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
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
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
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
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMedicine(MedicineModel model)
        {
            try
            {
                var listLinkMedicine = _medicineService.SearchMedicineInTabletkaBy(model.NameOfMedicine);
                if(listLinkMedicine != null)
                {
                    var result = await _medicineService.AddMedicineAsync(listLinkMedicine);

                    return RedirectToAction("GetMedicines");
                }

                return View();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
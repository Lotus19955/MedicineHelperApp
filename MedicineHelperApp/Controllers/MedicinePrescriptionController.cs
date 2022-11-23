using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicineHelper.Controllers
{
    //[Authorize(Roles = "user")]
    [Authorize]
    public class MedicinePrescriptionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMedicinePrescriptionService _medicinePrescriptionService;
        private readonly IUserService _userService;

        public MedicinePrescriptionController(IMapper mapper, IMedicinePrescriptionService medicinePrescriptionService,
            IUserService userService)
        {
            _mapper = mapper;
            _medicinePrescriptionService = medicinePrescriptionService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var emailUser = HttpContext.User.Identity?.Name;
                var userDto = await _userService.GetUserByEmailAsync(emailUser);
                var listMedicinePrescription = await _medicinePrescriptionService.GetAllMedicinePrescriptionAsync(userDto.Id);

                return View(listMedicinePrescription);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Create(Guid id)
        {
            try
            {
                var model = new MedicinePrescriptionModel();
                model.AppointmentId = id;
                model.ReturnUrl = Request.Headers["Referer"].ToString();

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicinePrescriptionModel model)
        {
            try
            {
                var userEmail = HttpContext.User.Identity.Name;
                var userDto = await _userService.GetUserByEmailAsync(userEmail);
                var dto = _mapper.Map<MedicinePrescriptionDto>(model);

                return Redirect(model.ReturnUrl);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

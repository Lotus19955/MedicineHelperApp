using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MedicineHelper.Controllers
{
    [Authorize(Roles = "User")]
    public class ClinicController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IClinicService _clinicService;

        public ClinicController(IMapper mapper, IClinicService clinicService)
        {
            _mapper = mapper;
            _clinicService = clinicService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                var model = new ClinicModel();
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
        public async Task<IActionResult> Create(ClinicModel model)
        {
            try
            {
                var dto = _mapper.Map<ClinicDto>(model);
                await _clinicService.CreateClinicAsync(dto);

                return Redirect(model.ReturnUrl);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DetailsClinic(Guid id)
        {
            try
            {
                var dto = await _clinicService.GetByIdClinicAsync(id);

                return View(dto);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }
    }
}
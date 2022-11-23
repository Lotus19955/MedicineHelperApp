using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicineHelper.Controllers
{
    [Authorize]
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicineHelperApp.Controllers
{
    public class VaccinationController : Controller
    {
        private readonly IVaccinationService _vaccinationService;
        private readonly IMapper _mapper;

        public VaccinationController(IVaccinationService vaccinationService, IMapper mapper)
        {
            _vaccinationService = vaccinationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var vaccination = (await _vaccinationService.GetAllVaccinationAsync())
                .Select(dto => _mapper.Map<VaccinationModel>(dto)).ToList();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddVaccinationModel model)
        {
            return Ok();
        }

    }
}

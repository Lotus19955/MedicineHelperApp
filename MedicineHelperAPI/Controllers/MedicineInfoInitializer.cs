using AutoMapper;
using Hangfire;
using MedicineHelper.Business.ServicesImplementations;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperWebAPI.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicineHelperWebAPI.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class MedicineInfoInitializer : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clinicService"></param>
        /// <param name="mapper"></param>
        public MedicineInfoInitializer(IMedicineService medicineService,
            IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddMedicineInfo()
        {
            try
            {
                //can be used cron calculator
                RecurringJob.AddOrUpdate(() => _medicineService.AddMedicineInfoTablekaByAsync(),Cron.Weekly);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel() { Message = ex.Message });
            }
        }

    }
}

using AutoMapper;
using Hangfire;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperWebAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MedicineHelperWebAPI.Controllers
{
    [Route ("[controller]")]
    [ApiController]
    public class ClinicsInfoInitializer : ControllerBase
    {
        private readonly IClinicService _clinicService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clinicService"></param>
        /// <param name="mapper"></param>
        public ClinicsInfoInitializer(IClinicService clinicService,
            IMapper mapper)
        {
            _clinicService = clinicService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddClinicInfo()
        {
            try
            {
                var dto = new ClinicDto();
                //RecurringJob.RemoveIfExists(nameof(_articleService.AggregateArticlesFromExternalSourcesAsync));
                var result = _clinicService.AddClinicInfoSite103ByAsync(dto);
                //RecurringJob.AddOrUpdate(() => _clinicService.AddClinicInfoSite103ByAsync(dto),
                //    "*/30 * * * *");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel() { Message = ex.Message });
            }
        }

    }
}

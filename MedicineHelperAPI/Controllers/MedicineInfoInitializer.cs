﻿using AutoMapper;
using Hangfire;
using MedicineHelper.Business.ServicesImplementations;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperWebAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MedicineHelperWebAPI.Controllers
{
    [Route ("[controller]")]
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
        public async Task<IActionResult> AddMedicineInfo()
        {
            try
            {
                //RecurringJob.RemoveIfExists(nameof(_articleService.AggregateArticlesFromExternalSourcesAsync));
                var result = _medicineService.AddMedicineInfoTablekraByAsync();
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

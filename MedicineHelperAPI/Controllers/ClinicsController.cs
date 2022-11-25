using MedicineHelperWebAPI.Models.Requests;
using MedicineHelperWebAPI.Models.Responses;
using AutoMapper;
using Hangfire;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace MedicineHelperWebAPI.Controllers
{
    /// <summary>
    /// Controller for work with clinic
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private readonly IClinicService _clinicService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clinicService"></param>
        /// <param name="mapper"></param>
        public ClinicsController(IClinicService clinicService,
            IMapper mapper)
        {
            _clinicService = clinicService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get clinic from storage with specified id
        /// </summary>
        /// <param name="id">Id of clinic</param>
        /// <returns></returns>
        [HttpGet ("{id}")]
        [ProducesResponseType(typeof(ClinicDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClinicById(Guid id)
        {
            var clinic = await _clinicService.GetByIdClinicAsync(id);
            if (clinic == null)
            {
                return NotFound();
            }
            return Ok(clinic);
        }

        /// <summary>
        /// Get all clinics
        /// </summary>
        /// <returns>Return all clinics</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ClinicDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllClinic()
        {
            IEnumerable<ClinicDto> articles = await _clinicService
                .GetClinicAsync();

            //var jobId = BackgroundJob.Enqueue(() => Console.WriteLine(HttpContext.Request.Method));
            //var jobId2 = BackgroundJob.Schedule(() => Console.WriteLine(HttpContext.Request.Method),
            //    TimeSpan.FromMinutes(1));


            return Ok(articles.ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        //[HttpPut("{id}")]
        //public IActionResult UpdateClinic(Guid id, [FromBody] AddOrUpdateClinicRequestModel? model)
        //{
        //    if (model != null)
        //    {
        //        var oldValue = _clinicService.GetByIdClinicAsync(id);

        //        if (oldValue == null)
        //        {
        //            return NotFound();
        //        }
        //        var dto = _mapper.Map<ClinicDto>(oldValue);
        //        _clinicService.UpdateClinicAsync(dto, id);

        //        return Ok();
        //    }

        //    return BadRequest();
        //}

        //[HttpPatch("{id}")]
        //public IActionResult UpdateArticles(Guid id, [FromBody] PatchRequestModel? model)
        //{
        //    //if (model != null)
        //    //{
        //    //    var oldValue = Articles.FirstOrDefault(dto => dto.Id.Equals(id));

        //    //    if (oldValue == null)
        //    //    {
        //    //        return NotFound();
        //    //    }

        //    //    //todo add patch implementation(change only fields from request

        //    //    return Ok();
        //    //}

        //    return BadRequest();
        //}

        /// <summary>
        /// Delete clinic
        /// </summary>
        /// <param name="id">Id of clinic</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteClinic(Guid id)
        {
            try
            {
                await _clinicService.DeleteClinicAsync(id);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorModel { Message = ex.Message });
            }
        }
    }
}

using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperWebAPI.Models.Requests;
using MedicineHelperWebAPI.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicineHelperWebAPI.Controllers
{

    /// <summary>
    /// Controller for work with doctor
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService,
            IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get doctor from storage with specified id
        /// </summary>
        /// <param name="id">Id of doctor</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DoctorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var clinic = await _doctorService.GetByIdDoctorAsync(id);
            if (clinic == null)
            {
                return NotFound();
            }
            return Ok(clinic);
        }

       /// <summary>
       /// Get all doctors
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(DoctorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllDoctors()
        {
            IEnumerable<DoctorDto> doctors = await _doctorService.GetAllDoctorAsync();

            return Ok(doctors.ToList());
        }

        /// <summary>
        /// Update doctor information
        /// </summary>
        /// <param name="id">Id of doctor</param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult UpdateDocotor(Guid id, [FromBody] AddOrUpdateDoctorRequestModel? model)
        {
            if (model != null)
            {
                var oldValue = _doctorService.GetByIdDoctorAsync(id);

                if (oldValue == null)
                {
                    return NotFound();
                }
                var dto = _mapper.Map<DoctorDto>(oldValue);
                _doctorService.UpdateDoctorAsync(dto, id);

                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Delete doctor
        /// </summary>
        /// <param name="id">Id of doctor</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteClinic(Guid id)
        {
            try
            {
                await _doctorService.DeleteDoctorAsync(id);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorModel { Message = ex.Message });
            }
        }
    } 
}
    



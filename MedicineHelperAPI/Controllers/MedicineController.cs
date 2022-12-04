using MedicineHelperWebAPI.Models.Requests;
using MedicineHelperWebAPI.Models.Responses;
using AutoMapper;
using Hangfire;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.DataBase.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Authorization;

namespace MedicineHelperWebAPI.Controllers
{
    /// <summary>
    /// Controller for work with clinic
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;

        public MedicineController(IMedicineService medicineService,
            IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Medicine from storage with specified id
        /// </summary>
        /// <param name="id">Id of Medicine</param>
        /// <returns></returns>
        [HttpGet ("{id}")]
        [ProducesResponseType(typeof(MedicineDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMedicineById(Guid id)
        {
            var clinic = await _medicineService.GetByIdMedicineAsync(id);
            if (clinic == null)
            {
                return NotFound();
            }
            return Ok(clinic);
        }

        /// <summary>
        /// Get all medicines
        /// </summary>
        /// <returns>Return all medicines</returns>
        [HttpGet]
        [ProducesResponseType(typeof(MedicineDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllMedicines()
        {
            IEnumerable<MedicineDto> medicines = await _medicineService.GetAllMedicineAsync();

            return Ok(medicines.ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult UpdateMedicine(Guid id, [FromBody] AddOrUpdateClinicRequestModel? model)
        {
            if (model != null)
            {
                var oldValue = _medicineService.GetByIdMedicineAsync(id);

                if (oldValue == null)
                {
                    return NotFound();
                }
                var dto = _mapper.Map<MedicineDto>(oldValue);
                _medicineService.UpdateMedicineAsync(dto, id);

                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Delete medicine
        /// </summary>
        /// <param name="id">Id of medicine</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteMedicine(Guid id)
        {
            try
            {
                await _medicineService.DeleteMedicineAsync(id);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorModel { Message = ex.Message });
            }
        }
    }
}

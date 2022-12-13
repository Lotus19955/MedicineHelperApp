using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReflectionIT.Mvc.Paging;
using Serilog;

namespace MedicineHelper.Controllers
{
    [Authorize(Roles = "User")]
    public class FluorographyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFluorographyService _fluorographyService;
        private readonly IUserService _userService;
        private readonly IClinicService _clinicService;
        public FluorographyController(IFluorographyService fluorographyService, IMapper mapper,
            IUserService userService, IClinicService clinicService)
        {
            _fluorographyService = fluorographyService;
            _mapper = mapper;
            _userService = userService;
            _clinicService = clinicService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageIndex, DateTime SearchDateStart, DateTime SearchDateEnd)
        {
            try
            {
                var emailUser = HttpContext.User.Identity?.Name;
                var userDto = _userService.GetUserByEmailAsync(emailUser);
                var fluorographies = await _fluorographyService.GetAllFluorographiesAsync(userDto.Id);
                if (SearchDateStart != DateTime.MinValue && SearchDateEnd != DateTime.MinValue)
                {
                    var dto = await _fluorographyService.GetAllFluorographiesAsync(userDto.Id);
                    if (pageIndex == 0)
                    {
                        pageIndex = 1;
                    }
                    var model = PagingList.Create(dto, 5, pageIndex);

                    return View(model);
                }
                else
                {
                    var dto = await _fluorographyService.GetFluorographyForPeriodAsync(SearchDateStart, SearchDateEnd, userDto.Id);
                    var model = PagingList.Create(dto, 5, pageIndex);

                    return View(model);
                }
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var clinic = await _clinicService.GetClinicAsync();

                var fluorographyModel = new FluorographyModel();
                fluorographyModel.ClinicList = new SelectList(clinic, "Id", "NameClinic");

                return View(fluorographyModel);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(FluorographyModel fluorographyModel)
        {
            try
            {
                var userEmail = HttpContext.User.Identity.Name;
                var dtoUser = _userService.GetUserByEmailAsync(userEmail);
                fluorographyModel.UserId = dtoUser.Id;
                var fluorographyDto = _mapper.Map<FluorographyDto>(fluorographyModel);
                await _fluorographyService.CreateFluorographyAsync(fluorographyDto);

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                return View(id);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FluorographyModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var dto = await _fluorographyService.GetFluorographyByIdAsync(model.Id);
                    dto.DataOfFluorography = model.DataOfFluorography;
                    dto.EndDateOfFluorography = model.EndDateOfFluorography;
                    dto.NumberFluorography = model.NumberFluorography;
                    dto.ClinicDtoId = model.ClinicId;

                    await _fluorographyService.UpdateFluorographyAsync(dto);

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult Delete(FluorographyModel model)
        {
            try
            {
               return View(model.Id);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _fluorographyService.DeleteFluorographyAsync(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }
    }
}

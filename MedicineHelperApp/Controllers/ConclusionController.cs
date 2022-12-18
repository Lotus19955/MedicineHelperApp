using AutoMapper;
using MedicineHelper.Business.ServicesImplementations;
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
    public class ConclusionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IConclusionService _conclusionService;
        private readonly IUserService _userService;
        private readonly IClinicService _clinicService;

        public ConclusionController(IMapper mapper, IConclusionService conclusionService,
            IUserService userService, IClinicService clinicService)
        {
            _mapper = mapper;
            _conclusionService = conclusionService;
            _userService = userService;
            _clinicService = clinicService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(DateTime SearchDateStart,DateTime SearchDateEnd, int pageIndex = 1)
        {
            try
            {
                var emailUser = HttpContext.User.Identity?.Name;
                var userDto = _userService.GetUserByEmailAsync(emailUser);

                if (SearchDateStart == DateTime.MinValue && SearchDateEnd == DateTime.MinValue)
                {
                    var listConclusions = await _conclusionService.GetAllConclusionAsync(userDto.Id);
                    var model =  PagingList.Create(listConclusions, 5, pageIndex);
                    return View(model);
                }
                else
                {
                    var listConclusions = await _conclusionService.GetPeriodConclusionAsync(SearchDateStart, SearchDateEnd, userDto.Id);
                    var model = PagingList.Create(listConclusions, 5, pageIndex);

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
        public async Task<IActionResult> Create(Guid? id)
        {
            try
            {
                var clinicDto = await _clinicService.GetClinicAsync();

                var conclusionModel = new ConclusionModel();
                conclusionModel.AppointmentId = id;
                conclusionModel.ClinicList = new SelectList(clinicDto, "Id", "Name");
                conclusionModel.ReturnUrl = Request.Headers["Referer"].ToString();
                if (conclusionModel.ReturnUrl == "https://localhost:7226/Clinic/Create")
                {
                    conclusionModel.ReturnUrl = "https://localhost:7226/Conclusion/Index";
                }

                return View(conclusionModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConclusionModel conclusionModel)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    var emailUser = HttpContext.User.Identity.Name;
                    var userDto = _userService.GetUserByEmailAsync(emailUser);
                    conclusionModel.UserId = userDto.Id;
                     
                    var analysisDto = _mapper.Map<ConclusionDto>(conclusionModel);
                    await _conclusionService.CreateConclusionAsync(analysisDto);

                    return RedirectToAction("Index", "Conclusion");
                }
                else
                {
                    return View(conclusionModel);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Delete(Guid id, string name)
        {
            try
            {
                var model = new ConclusionModel();
                model.NameOfConclusion = name;
                model.Id = id;
                return View(model);
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
                await _conclusionService.DeleteConclusion(id);

                return RedirectToAction("Index", "Conclusion");
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}");
                return StatusCode(500);
            }
        }
    }
}
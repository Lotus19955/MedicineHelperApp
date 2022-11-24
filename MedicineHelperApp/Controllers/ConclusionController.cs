using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReflectionIT.Mvc.Paging;

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
        public async Task<IActionResult> Index(int pageIndex, DateTime SearchDateStart,
            DateTime SearchDateEnd, bool AllDates)
        {
            try
            {
                var emailUser = HttpContext.User.Identity?.Name;
                var userDto = await _userService.GetUserByEmailAsync(emailUser);

                if (!AllDates)
                {
                    var listConclusions = await _conclusionService.GetAllConclusionAsync(userDto.Id);
                    if (pageIndex == 0)
                    {
                        pageIndex = 1;
                    }
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
            catch (Exception)
            {
                throw;
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
                conclusionModel.ClinicList = new SelectList(clinicDto, "Id", "NameClinc");
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
                    var userDto = await _userService.GetUserByEmailAsync(emailUser);
                    conclusionModel.UserId = userDto.Id;
                     
                    var analysisDto = _mapper.Map<ConclusionDto>(conclusionModel);
                    await _conclusionService.CreateConclusionAsync(analysisDto);
                    
                    var returnUrl = conclusionModel.ReturnUrl;

                    return Redirect(returnUrl);
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
    }
}
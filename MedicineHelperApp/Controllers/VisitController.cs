using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using Serilog;
using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using MedicineHelper.Business.ServicesImplementations;
using MedicineHelper.Core.Enums;

namespace MedicineHelperApp.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class VisitController : Controller

    {
        private readonly IMapper _mapper;
        private readonly IVisitService _visitService;
        private readonly IUserManager _userManager;


        public VisitController(IMapper mapper,
            IVisitService visitService,
            IUserManager userManager)
        {
            _mapper = mapper;
            _visitService = visitService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int page)
        {
            try
            {
                var userId = (await _userManager.GetUserAsync()).Id;
                var dto = await _visitService
                    .GetAllVisitsByUserIdAsync(userId);
                var visits = _mapper.Map<List<VisitHumanReadableModel>>(dto)
                .OrderByDescending(visit => visit.DateOfVisit)
                    .ToList();

                var visitStatuses = (VisitStatus[])Enum.GetValues(typeof(VisitStatus));
                var model = new VisitWithVisitStatusesModel()
                {
                    Visits = visits,
                    VisitStatuses = visitStatuses
                };

                return View(model);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}. {Environment.NewLine} {e.StackTrace}");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddOrEditVisitsModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (model.Name.ToUpperInvariant().Contains("123"))
                    {
                        ModelState.AddModelError("Name", "Article contains 123");
                        return View(model);
                    }

                    model.Id = Guid.NewGuid();

                    var dto = _mapper.Map<VisitDto>(model);
                    var resule = await _visitService.CreateVisitAsync(dto);

                    return RedirectToAction("Index", "Visit");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {

                Log.Error(ex, ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id != Guid.Empty)
            {
                var visitDto = await _visitService.GetVisitByIdAsync(id);
                if (visitDto == null)
                {
                    return BadRequest();
                }

                var editModel = _mapper.Map<VisitModel>(visitDto);

                return View(editModel);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VisitModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dto = _mapper.Map<VisitDto>(model);
                    await _visitService.UpdateAsync(model.Id, dto);

                    return RedirectToAction("Index", "Visit");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> Remove(Guid id)
        {
            if (id != Guid.Empty)
            {
                await _visitService.Remove(id);

                return RedirectToAction("Index", "Visit");
            }

            return BadRequest();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

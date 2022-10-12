using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Mvc;
using MedicineHelper.Business.ServiceImplemintations;
using System.Diagnostics;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using Serilog;
using AutoMapper;
using MedicineHelper.Core.DataTransferObjects;

namespace MedicineHelperApp.Controllers
{
    public class VisitController : Controller

    {
        private readonly IVisitsService _visitsService;
        private readonly IMapper _mapper;


        public VisitController(IVisitsService visitsService, IMapper mapper)
        {
            _visitsService = visitsService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var visits = await _visitsService.GetAllVisitsAsync();
                if (visits.Any())
                {
                    return View(visits);
                }
                else
                {
                    return View("NoVisits");
                }
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

                    var dto = _mapper.Map<VisitsDto>(model);
                    var resule = await _visitsService.CreateVisitAsync(dto);

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
                var visitDto = await _visitsService.GetVisitsByIdAsync(id);
                if (visitDto == null)
                {
                    return BadRequest();
                }

                var editModel = _mapper.Map<VisitsModel>(visitDto);

                return View(editModel);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VisitsModel model)
        {
            try
            {
                if (model != null)
                {
                    var dto = _mapper.Map<VisitsDto>(model);

                    var visitsDto = await _visitsService.GetVisitsByIdAsync(model.Id);

                    //should be sure that dto property naming is the same with entity property naming
                    var patchList = new List<PatchModel>();
                    if (dto != null)
                    {
                        if (dto.Id.Equals(visitsDto.Id))
                        {
                            patchList.Add(new PatchModel()
                            {
                                PropertyName = nameof(model.Name),
                                PropertyValue = dto.Name
                            });
                        }
                    }

                    await _visitsService.PatchAsync(model.Id, patchList);

                    //await _articleService.CreateArticleAsync(dto);

                    return RedirectToAction("Index", "Visit");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return StatusCode(500);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

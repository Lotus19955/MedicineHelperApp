using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Mvc;
using MedicineHelper.Business.ServiceImplemintations;
using System.Diagnostics;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using Serilog;

namespace MedicineHelperApp.Controllers
{
    public class VisitsController : Controller
        
    {
        private readonly IVisitsService _visitsService;
        private int amount = 5;

        public VisitsController(IVisitsService visitsService)
        {
            _visitsService = visitsService;
        }

        public async Task<IActionResult> Index(int number)
        {
            try
            {
                var visits = await _visitsService.GetVisitByNumber(number, amount);
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

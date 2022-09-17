using Microsoft.AspNetCore.Mvc;

namespace MedicineHelperApp.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Register() => ("Registred");

    }
}

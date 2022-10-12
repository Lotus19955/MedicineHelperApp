using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicineHelperApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Email.ToLowerInvariant().Equals("test@email.com"))
                {
                    ModelState.AddModelError(nameof(model.Email), "Email is already exist");
                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult CheckEmail(string email)
        {
            if (email.ToLowerInvariant().Equals("test@email.com"))
            {
                return Ok(false);
            }
            return Ok(true);
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            return Ok("Logged in");
        }
    }
}
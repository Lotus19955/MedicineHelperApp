using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;
using MedicineHelper.Core.Abstractions;
using Microsoft.AspNetCore.Identity;
using MedicineHelper.Core.DataTransferObjects;
using Serilog;
using MedicineHelper.IdentityManagers;
using Microsoft.AspNetCore.Authorization;
using MedicineHelper.Models;
using MedicineHelper.Business.ServicesImplementations;

namespace MedicineHelperApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ISignInManager _signInManager;
        private readonly IRoleService _roleService;

        public AccountController(IUserService userService,
            IRoleService roleService,
            IMapper mapper,
            ISignInManager signInManager)
        {
            _userService = userService;
            _mapper = mapper;
            _signInManager = signInManager;
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var userRoleId = await _roleService.GetRoleIdByNameAsync("User");
                var userDto = _mapper.Map<UserDto>(model);
                if (userDto != null && userRoleId != null)
                {
                    userDto.RoleId = userRoleId;
                    var result = await _userService.RegisterUserAsync(userDto);
                    if (result > 0)
                    {
                        await Authenticate(model.Email);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CheckEmail(string email)
        {
            try
            {
                if (email.ToLowerInvariant().Equals(_userService.IsUserExistsAsync(email)))
                {
                    return Ok(false);
                }
                return Ok(true);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}. {Environment.NewLine} {e.StackTrace}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                await Authenticate(model.Email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CheckLoginData(string password, string email)
        {
            try
            {
                var isPasswordCorrect = await _userService.CheckUserPasswordAsync(email, password);
                if (!isPasswordCorrect)
                {
                    return Ok(false);
                }
                return Ok(true);
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}. {Environment.NewLine} {e.StackTrace}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        private async Task Authenticate(string email)
        {
            var userDto = await _userService.GetUserByEmailAsync(email);

            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userDto.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userDto.RoleName)
            };

            var identity = new ClaimsIdentity(claims,
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
            );

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult IsLoggedIn()
        {
            if (User.Identities.Any(identity => identity.IsAuthenticated))
            {
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpGet]
        public async Task<IActionResult> UserLoginPreview()
        {
            if (User.Identities.Any(identity => identity.IsAuthenticated))
            {
                var userEmail = User.Identity?.Name;
                if (string.IsNullOrEmpty(userEmail))
                {
                    return BadRequest();
                }

                var user = _mapper.Map<UserDataModel>(await _userService.GetUserByEmailAsync(userEmail));
                return View(user);
            }

            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserData()
        {
            var userEmail = User.Identity?.Name;
            if (string.IsNullOrEmpty(userEmail))
            {
                return BadRequest();
            }

            var user = _mapper.Map<UserDataModel>(await _userService.GetUserByEmailAsync(userEmail));
            return Ok(user);
        }
    
       

        //[HttpPost]
        //public async Task<IActionResult> Logout(string returnUrl = null)
        //{
        //    await _signInManager.SignOutAsync();
        //    Log.Information("User logged out.");
        //    if (returnUrl != null)
        //    {
        //        return LocalRedirect(returnUrl);
        //    }
        //    else
        //    {
        //        // This needs to be a redirect so that the browser performs a new
        //        // request and the identity for the user gets updated.
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
    }
}
using MedicineHelper.Core.Abstractions;
using MedicineHelperApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MedicineHelper.Controllers
{
    [Authorize(Roles = "User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrEditUserInfo()
        {
            try
            {
                var userEmail = HttpContext.User.Identity?.Name;
                var userDto = _userService.GetUserByEmailAsync(userEmail);
                var model = new UserModel()
                {
                    LastName = userDto.LastName,
                    FirstName = userDto.FirstName,
                    Birthday = userDto.Birthday,
                    AvatarByte = userDto.Avatar,
                    Email = userDto.Email,
                    Id = userDto.Id,
                };

                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEditAvatar()
        {

            try
            {
                var userEmail = HttpContext.User.Identity?.Name;
                var userDto = _userService.GetUserByEmailAsync(userEmail);
                var model = new UserModel()
                {
                    Email = userDto.Email,
                    AvatarByte = userDto.Avatar,
                    Id = userDto.Id,
                };

                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEditAvatar(UserModel model)
        {
            try
            {
                if(model.Avatar !=null)
                {
                    var dto = _userService.GetUserByEmailAsync(model.Email);
                    byte[] imageData = null;
                    using (BinaryReader binaryReader = new BinaryReader(model.Avatar.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)model.Avatar.Length);
                    }
                    dto.Avatar = imageData;

                    await _userService.UpdateUserAsync(dto, dto.Id);
                }

                return RedirectToAction("GetOrEditUserInfo");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUserInfo(UserModel model)
        {
            try
            {
                var dto = _userService.GetUserByEmailAsync(model.Email);
                dto.LastName = model.LastName;
                dto.FirstName = model.FirstName;
                dto.Birthday = model.Birthday;
                dto.Email = model.Email;
                if(dto.Avatar?.Length == 0)
                {
                    byte[] imageData = null;
                    using (BinaryReader binaryReader = new BinaryReader(model.Avatar.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)model.Avatar.Length);
                    }
                    dto.Avatar = imageData;
                }

                await _userService.UpdateUserAsync(dto, dto.Id);

                return RedirectToAction("GetOrEditUserInfo");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
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
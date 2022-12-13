using AutoMapper;
using MedicineHelper.Business.ServicesImplementations;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperWebAPI.Models.Requests;
using MedicineHelperWebAPI.Models.Responses;
using MedicineHelperWebAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MedicineHelperWebAPI.Controllers
{
    /// <summary>
    /// Controller for work with User
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        private readonly IJwtUtil _jwtUtil;

        public UserController(IUserService userService,
            IMapper mapper,
            IRoleService roleService,
            IJwtUtil jwtUtil)
        {
            _jwtUtil = jwtUtil;
            _userService = userService;
            _mapper = mapper;
            _roleService = roleService;
        }

        /// <summary>
        /// Get user from storage with specified id
        /// </summary>
        /// <param name="id">Id of doctor</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var clinic = _userService.GetUserByEmailAsync(email);
            if (clinic == null)
            {
                return NotFound();
            }
            return Ok(clinic);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUsers()
        {
            IEnumerable<UserDto> users = await _userService.GetAllUserAsync();

            return Ok(users.ToList());
        }

        /// <summary>
        /// Update user information
        /// </summary>
        /// <param name="email">Email of user</param>
        /// <param name="model"></param>
        /// <returns></returns>
        //[HttpPost("{Update}")]
        //[Authorize]
        //public IActionResult UpdateUser(string email, [FromBody] AddOrUpdateUserRequestModel? model)
        //{
        //    if (model != null)
        //    {
        //        var oldValue = _userService.GetUserByEmailAsync(email);

        //        if (oldValue == null)
        //        {
        //            return NotFound();
        //        }
        //        var dto = _mapper.Map<UserDto>(oldValue);
        //        _userService.UpdateUserAsync(dto, email);

        //        return Ok();
        //    }

        //    return BadRequest();
        //}

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="email">Id of email</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(string email)
        {
            try
            {
                await _userService.DeleteUserAsync(email);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorModel { Message = ex.Message });
            }
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterUserRequestModel request)
        {
            try
            {
                var userRoleId = await _roleService.GetRoleIdByNameAsync("User");
                var userDto = _mapper.Map<UserDto>(request);
                var userWIthSameEmailExists = await _userService.IsUserExistAsync(request.Email);
                if (userDto != null 
                    && userRoleId != null 
                    && !userWIthSameEmailExists 
                    && request.Password.Equals(request.PasswordConfirmation))
                {
                    userDto.RoleId = userRoleId.Value;
                    var result = await _userService.RegisterUser(userDto, userDto.Password);
                    if (result > 0)
                    {
                        var userInDbDto = _userService.GetUserByEmailAsync(userDto.Email);

                        var response = await _jwtUtil.GenerateTokenAsync(userInDbDto);

                        return Ok(response);
                    }
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500);
            }
        }
    }
}

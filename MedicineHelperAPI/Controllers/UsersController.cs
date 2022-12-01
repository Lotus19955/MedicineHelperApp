﻿using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelperWebAPI.Models.Requests;
using MedicineHelperWebAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MedicineHelperWebAPI.Controllers
{
    /// <summary>
    /// Controller for work with doctor
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get user from storage with specified id
        /// </summary>
        /// <param name="id">Id of doctor</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDoctorByEmail(string email)
        {
            var clinic = await _userService.GetUserByEmailAsync(email);
            if (clinic == null)
            {
                return NotFound();
            }
            return Ok(clinic);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>Return all users</returns>
        [HttpGet]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUsers()
        {
            IEnumerable<UserDto> users = await _userService.GetAllUserAsync();

            //var jobId = BackgroundJob.Enqueue(() => Console.WriteLine(HttpContext.Request.Method));
            //var jobId2 = BackgroundJob.Schedule(() => Console.WriteLine(HttpContext.Request.Method),
            //    TimeSpan.FromMinutes(1));


            return Ok(users.ToList());
        }

        /// <summary>
        /// Update user information
        /// </summary>
        /// <param name="email">Email of user</param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateUser(string email, [FromBody] AddOrUpdateUserRequestModel? model)
        {
            if (model != null)
            {
                var oldValue = _userService.GetUserByEmailAsync(email);

                if (oldValue == null)
                {
                    return NotFound();
                }
                var dto = _mapper.Map<UserDto>(oldValue);
                _userService.UpdateUserAsync(dto, email);

                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="email">Id of email</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
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
    }
}

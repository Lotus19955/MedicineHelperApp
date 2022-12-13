using AutoMapper;
using MedicineHelper.Core.Abstractions;
using MedicineHelperWebAPI.Models.Requests;
using MedicineHelperWebAPI.Models.Responses;
using MedicineHelperWebAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MedicineHelperWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        private readonly IJwtUtil _jwtUtil;

        public TokenController(IUserService userService,
            IMapper mapper,
            IJwtUtil jwtUtil,
            IRoleService roleService)
        {
            _userService = userService;
            _mapper = mapper;
            _roleService = roleService;
            _jwtUtil = jwtUtil;
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateJwtToken([FromBody] LoginUserRequestModel request)
        {
            try
            {
                var user = _userService.GetUserByEmailAsync(request.Email);
                if (user == null)
                {
                    return BadRequest(new ErrorModel()
                    {
                        Message = "Password is incorrect"
                    });
                }

                var isPassCorrect = await _userService.CheckUserPasswordAsync(request.Email, request.Password);

                if (!isPassCorrect)
                {
                    return BadRequest(new ErrorModel()
                    {
                        Message = "Password is incorrect"
                    });
                }

                var response = await _jwtUtil.GenerateTokenAsync(user);

                return Ok(response);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("Refresh")]
        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestModel request)
        {
            try
            {
                var user = await _userService.GetUserByRefreshTokenAsync(request.RefreshToken);

                var response = await _jwtUtil.GenerateTokenAsync(user);

                //await _jwtUtil.RemoveRefreshTokenAsync(request.RefreshToken);

                return Ok(response);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500);
            }
        }


        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("Revoke")]
        [HttpPost]
        public async Task<IActionResult> RevokeToken([FromBody] RefreshTokenRequestModel request)
        {
            try
            {
                //await _jwtUtil.RemoveRefreshTokenAsync(request.RefreshToken);

                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500);
            }
        }
    }
}

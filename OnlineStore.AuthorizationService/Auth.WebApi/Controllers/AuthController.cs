using Auth.BuisnessLayer.Abstractions.Interfaces;
using Auth.BuisnessLayer.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebApi.Controllers
{
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountServices;
        public AuthController(IAccountService accountServices)
        {
            _accountServices = accountServices;
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /api/login?UserName=Evgeny&password=4454
        /// </remarks>
        /// <param name="LoginUserRequestDto">LoginUserRequestDto object</param>
        /// <returns>Login user (LoginUserRequestDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">The user was not found</response>
        /// <response code="409">The user's authorization failed with an error</response>
        [HttpGet]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> LoginАsync(LoginUserRequestDto loginRequestDto, CancellationToken cancellationToken)
        {
            var user = await _accountServices.LoginUserAsync(loginRequestDto, cancellationToken);

            return Ok(user);            
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /api/register?UserName=Evgeny&Password=4454&ConfirmPassword=4454
        /// </remarks>
        /// <param name="RegisterUserRequestDto">RegisterUserRequestDto object</param>
        /// <returns>Register user (RegisterUserRequestDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="400">User Failed to create</response>
        /// <response code="409">User with this login already exists</response>
        [HttpGet]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]        
        public async Task<IActionResult> RegisterАsync(RegisterUserRequestDto redisterRequestDto, CancellationToken cancellationToken)
        {
            var createdUser = await _accountServices.RegisterUserAsync(redisterRequestDto, cancellationToken);

            return Ok(createdUser);
        }
    }
}
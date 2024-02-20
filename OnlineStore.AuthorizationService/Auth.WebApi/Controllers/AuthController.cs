using Auth.BuisnessLayer.Abstractions.Interfaces;
using Auth.BuisnessLayer.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebApi.Controllers
{
    [Route("api/[controller]")]
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
        /// Post /api/login
        /// {
        ///     name: "NewUser",
        ///     password: "qwer"
        /// }
        /// </remarks>
        /// <param name="LoginUserRequestDto">LoginUserRequestDto object</param>
        /// <returns>Login user (LoginUserRequestDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">The user was not found</response>
        /// <response code="409">The user's authorization failed with an error</response>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> LoginАsync([FromBody] LoginUserRequestDto loginRequestDto, CancellationToken cancellationToken)
        {
            var user = await _accountServices.LoginUserAsync(loginRequestDto, cancellationToken);

            return Ok(user);            
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/register
        /// {
        ///     name: "NewUser",
        ///     password: "qwer",
        ///     confirmPassword: "qwer"
        /// }
        /// </remarks>
        /// <param name="RegisterUserRequestDto">RegisterUserRequestDto object</param>
        /// <returns>Register user (RegisterUserRequestDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="400">User Failed to create</response>
        /// <response code="409">User with this login already exists</response>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]        
        public async Task<IActionResult> RegisterАsync([FromBody] RegisterUserRequestDto redisterRequestDto, CancellationToken cancellationToken)
        {
            var createdUser = await _accountServices.RegisterUserAsync(redisterRequestDto, cancellationToken);

            return Ok(createdUser);
        }

        [HttpPost]
        [Route("register1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> RegisterАsync1(RegisterUserRequestDto redisterRequestDto, CancellationToken cancellationToken)
        {
            return Ok();
        }
    }
}
using Auth.BuisnessLayer.Abstractions.Interfaces;
using Auth.BuisnessLayer.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAccountService _accountServices;

        public UsersController(IAccountService accountServices)
        {
            _accountServices = accountServices;
        }

        /// <summary>
        /// Gets the list of users
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/Users
        /// {
        ///     pageSize: 10,
        ///     pageCount: 1
        /// }
        /// </remarks>
        /// <returns>PageOfUser (UsersPageResponseDto)</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync([FromBody] GetUserRequestDto getUserRequestDto, CancellationToken cancellationToken)
        {
            var usersPage = await _accountServices.GetAllUserAsync(getUserRequestDto, cancellationToken);

            return Ok(usersPage);
        }

        /// <summary>
        /// Get the user by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/Users/46b5821f-944d-48db-87f4-4664039ffb6c
        /// </remarks>
        /// <param name="id">Guid object</param>
        /// <returns>User (GetUserResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">The user was not found</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _accountServices.GetUserByIdAsync(id, cancellationToken);

            return Ok(user);
        }

        /// <summary>
        /// Change the user's password
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /api/Users
        /// {
        ///     "Name": "Evgeny",
        ///     "CurrentPassword": "4454",
        ///     "NewPassword": "5483"
        /// }
        /// </remarks>
        /// <param name="changePasswordRequestDto">СhangePasswordRequestDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">User Failed to update</response>
        /// <response code="404">The user was not found</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> СhangePasswordAsync([FromBody] СhangePasswordRequestDto changePasswordRequestDto, CancellationToken cancellationToken)
        {
            await _accountServices.СhangePasswordAsync(changePasswordRequestDto, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Delete the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /api/Users/46b5821f-944d-48db-87f4-4664039ffb6c
        /// </remarks>
        /// <param name="id">Guid object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">User Failed to delete</response>
        /// <response code="404">The user was not found</response>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _accountServices.DeleteUserByIdAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
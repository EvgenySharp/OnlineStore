using Auth.BuisnessLayer.Abstractions.Interfaces;
using Auth.BuisnessLayer.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebApi.Controllers
{
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _accountServices;

        public UserController(IAccountService accountServices)
        {
            _accountServices = accountServices;
        }

        /// <summary>
        /// Gets the list of users
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/User/GetAll
        /// </remarks>
        /// <returns>ListOfUser (<IEnumerable<GetUserResponseDto>>)</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var listOfUser = await _accountServices.GetAllUserAsync(cancellationToken);

            return Ok(listOfUser);
        }

        /// <summary>
        /// Get the user by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/User/GetById?id=08be1a02-c955-4451-8cab-5e87462f3ded
        /// </remarks>
        /// <param name="id">Guid object</param>
        /// <returns>User (GetUserResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">The user was not found</response>
        [HttpGet]
        [Route("user/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            var user = await _accountServices.GetUserByIdAsync(id, cancellationToken);

            return Ok(user);
        }

        /// <summary>
        /// Update the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /api/User/updatePassword
        /// {
        ///     "Name": "Evgeny",
        ///     "CurrentPassword": "4454",
        ///     "NewPassword": "5483"
        /// }
        /// </remarks>
        /// <param name="updateUserRequestDto">UpdateUserRequestDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">User Failed to update</response>
        /// <response code="404">The user was not found</response>
        [HttpPut]
        [Route("user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdateUserRequestDto updateUserRequestDto, CancellationToken cancellationToken)
        {
            await _accountServices.UpdatePasswordAsync(updateUserRequestDto, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Delete the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /api/User/Delete?id=773b2323-7205-481a-84ae-a7e96826beff
        /// </remarks>
        /// <param name="id">Guid object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">User Failed to delete</response>
        /// <response code="404">The user was not found</response>
        [HttpDelete]
        [Route("user/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _accountServices.DeleteUserByIdAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
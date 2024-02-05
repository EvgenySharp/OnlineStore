using Auth.BuisnessLayer.Abstractions.Interfaces;
using Auth.BuisnessLayer.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebApi.Controllers
{
    [Route("api")]
    public class RoleController : ControllerBase
    {
        private readonly IAccountService _accountServices;
        public RoleController(IAccountService accountServices)
        {
            _accountServices = accountServices;
        }

        /// <summary>
        /// Create role
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/Role/GetAll
        /// </remarks>
        /// <returns>ListOfRole (<IEnumerable<RoleResponseDto>>)</returns>
        /// <response code="200">Success</response>
        /// <response code="400">The role failed to create</response>
        /// <response code="409">The role already exists</response>
        [HttpPost]
        [Route("role/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create(RoleRequestDto roleRequestDto, CancellationToken cancellationToken)
        {
            var role = await _accountServices.СreateRoleAsync(roleRequestDto, cancellationToken);

            return Ok(role);
        }

        /// <summary>
        /// Gets the list of roles
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/roles
        /// </remarks>
        /// <returns>ListOfRole (<IEnumerable<RoleResponseDto>>)</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var listOfUser = await _accountServices.GetAllRoleAsync(cancellationToken);

            return Ok(listOfUser);
        }

        /// <summary>
        /// Get the role by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Role/GetById?roleName=Admin
        /// </remarks>
        /// <param name="roleRequestDto">string object</param>
        /// <returns>Role (RoleResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">The role was not found</response>
        [HttpGet]
        [Route("role/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRoleByName(RoleRequestDto roleRequestDto, CancellationToken cancellationToken)
        {
            var user = await _accountServices.GetRoleByNameAsync(roleRequestDto, cancellationToken);

            return Ok(user);

        }

        /// <summary>
        /// Delete the role
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /Role/Delete?roleName=Admin
        /// </remarks>
        /// <param name="roleRequestDto">Guid object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">Role Failed to delete</response>
        /// <response code="404">The role was not found</response>
        [HttpDelete]
        [Route("role/{name}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(RoleRequestDto roleRequestDto, CancellationToken cancellationToken)
        {
            await _accountServices.DeleteRoleByNameAsync(roleRequestDto, cancellationToken);

            return NoContent();
        }
    }
}
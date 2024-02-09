using Auth.BuisnessLayer.Abstractions.Interfaces;
using Auth.BuisnessLayer.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Create role
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/Role
        /// {
        ///     name: "roleName"
        /// }
        /// </remarks>
        /// <returns>Role (RoleResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="400">The role failed to create</response>
        /// <response code="409">The role already exists</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAsync([FromBody] RoleRequestDto roleRequestDto, CancellationToken cancellationToken)
        {
            var role = await _roleService.СreateRoleAsync(roleRequestDto, cancellationToken);

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var listOfRole = await _roleService.GetAllRoleAsync(cancellationToken);

            return Ok(listOfRole);
        }

        /// <summary>
        /// Get the role by name
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/Roles/User
        /// </remarks>
        /// <param name="name">string object</param>
        /// <returns>Role (RoleResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">The role was not found</response>
        [HttpGet]
        [Route("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRoleByNameAsync(string name, CancellationToken cancellationToken)
        {
            var role = await _roleService.GetRoleByNameAsync(name, cancellationToken);

            return Ok(role);
        }

        /// <summary>
        /// Delete the role
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /api/Roles/User
        /// </remarks>
        /// <param name="roleRequestDto">Guid object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">Role Failed to delete</response>
        /// <response code="404">The role was not found</response>
        [HttpDelete]
        [Route("{name}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(string name, CancellationToken cancellationToken)
        {
            await _roleService.DeleteRoleByNameAsync(name, cancellationToken);

            return NoContent();
        }
    }
}
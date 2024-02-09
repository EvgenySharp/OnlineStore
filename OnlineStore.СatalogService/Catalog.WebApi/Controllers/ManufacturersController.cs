using Catalog.Application.DTOs.RequestDtos;
using Catalog.Application.Manufacturers.Commands.CreateManufacturer;
using Catalog.Application.Manufacturers.Commands.UpdateBook;
using Catalog.Application.Manufacturers.Queries.GetManufacturerDetails;
using Catalog.Application.Manufacturers.Queries.GetManufacturerList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebApi.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    
    public class ManufacturersController : ControllerBase
    {
        private IMediator _mediator;

        public ManufacturersController(IMediator mediator) 
        { 
            _mediator = mediator;
        }

        /// <summary>
        /// Create manufacturers
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/manufacturers
        /// {
        ///     title: "ManufacturerTitle"
        /// }
        /// </remarks>
        /// <returns>Manufacturer (ManufacturerResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="400">The manufacturer failed to create</response>
        /// <response code="409">The manufacturer already exists</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateManufacturerRequestDto CreateManufacturerRequestDto, CancellationToken cancellationToken)
        {
            var command = new CreateManufacturerCommand()
            {
                ManufacturerTitle = CreateManufacturerRequestDto.Title,
            };
            var manufacturer = await _mediator.Send(command, cancellationToken);

            return Ok(manufacturer);
        }

        /// <summary>
        /// Gets the list of manufacturer
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/manufacturer
        /// </remarks>
        /// <returns>ListOfManufacturer (<IEnumerable<ManufacturerResponseDto>>)</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var command = new GetManufacturerListQuery();
            var listOfManufacturer = await _mediator.Send(command, cancellationToken);

            return Ok(listOfManufacturer);
        }

        /// <summary>
        /// Get the manufacturer by title
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/manufacturers/Samsung
        /// </remarks>
        /// <param title="title">string object</param>
        /// <returns>Manufacturer (ManufacturerResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">The manufacturer was not found</response>
        [HttpGet]
        [Route("api/manufacturers/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRoleByNameAsync(string title, CancellationToken cancellationToken)
        {
            var command = new GetManufacturerDetailsQuery()
            { 
                Title = title,
            };
            var manufacturer = await _mediator.Send(command, cancellationToken);

            return Ok(manufacturer);
        }

        /// <summary>
        /// Change the manufacturer's title
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /api/manufacturers
        /// {
        ///     "title": "Aple"
        /// }
        /// </remarks>
        /// <param name="changePasswordRequestDto">UptadeManufacturerRequestDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">Manufacturer Failed to update</response>
        /// <response code="404">The manufacturer was not found</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> СhangeTitleAsync([FromBody] UptadeManufacturerRequestDto uptadeManufacturerRequestDto, CancellationToken cancellationToken)
        {
            var command = new UpdateManufacturerCommand()
            {
                Title = uptadeManufacturerRequestDto.Tiitle,
            };

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Delete the manufacturer
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /api/manufacturers/Samsung
        /// </remarks>
        /// <param name="title">string object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">Manufacturer Failed to delete</response>
        /// <response code="404">The manufacturer was not found</response>
        [HttpDelete]
        [Route("{title}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(string title, CancellationToken cancellationToken)
        {
            //var command = new UpdateManufacturerCommand()
            //{
            //    Title = uptadeManufacturerRequestDto.Tiitle,
            //};

            //await _mediator.Send(command, cancellationToken);

            //return NoContent();
        }
    }
}
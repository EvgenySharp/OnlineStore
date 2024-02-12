using Catalog.Application.DTOs.RequestDtos.Manufacturers;
using Catalog.Application.Manufacturers.Commands.CreateManufacturer;
using Catalog.Application.Manufacturers.Commands.DeleteManufacturer;
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
        /// <param name="manufacturerRequestDto">CreateManufacturerRequestDto object</param>
        /// <returns>Manufacturer (CreateManufacturerResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="400">The manufacturer failed to create</response>
        /// <response code="409">The manufacturer already exists</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateManufacturerRequestDto manufacturerRequestDto, CancellationToken cancellationToken)
        {
            var command = new CreateManufacturerCommand() { CreateManufacturerRequestDto = manufacturerRequestDto };
            var manufacturerDto = await _mediator.Send(command, cancellationToken);

            return Ok(manufacturerDto);
        }

        /// <summary>
        /// Gets the list of manufacturer
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/manufacturers/page
        /// {
        ///     pageSize: 2,
        ///     pageCount: 1
        /// }
        /// </remarks>
        /// <param name="manufacturerDto">GetManufacturerRequestDto object</param>
        /// <returns>ListOfManufacturer (<IEnumerable<GetManufacturerResponseDto>>)</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("page")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync([FromBody] GetManufacturerRequestDto manufacturerDto, CancellationToken cancellationToken)
        {
            var command = new GetManufacturerListQuery() { GetManufacturerRequestDto = manufacturerDto };
            var listOfManufacturer = await _mediator.Send(command, cancellationToken);

            return Ok(listOfManufacturer);
        }

        /// <summary>
        /// Get the manufacturer by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/manufacturers/7200f6a3-132c-46c9-8b9f-27b9b3c2d122
        /// </remarks>
        /// <param name="id">Guid object</param>
        /// <returns>Manufacturer (GetManufacturerResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">The manufacturer was not found</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var command = new GetManufacturerDetailsQuery() { Id = id };
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
        ///     "id": "7200f6a3-132c-46c9-8b9f-27b9b3c2d122"
        ///     "newTitle": "Aple"
        /// }
        /// </remarks>
        /// <param name="manufacturerRequestDto">UptadeManufacturerRequestDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">Manufacturer Failed to update</response>
        /// <response code="404">The manufacturer was not found</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> СhangeTitleAsync([FromBody] UptadeManufacturerRequestDto manufacturerRequestDto, CancellationToken cancellationToken)
        {
            var command = new UpdateManufacturerCommand() { uptadeManufacturerRequestDto = manufacturerRequestDto };

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Delete the manufacturer
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /api/manufacturers/7200f6a3-132c-46c9-8b9f-27b9b3c2d122
        /// </remarks>
        /// <param name="id">Guid object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">Manufacturer Failed to delete</response>
        /// <response code="404">The manufacturer was not found</response>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteManufacturerCommand() { Id = id };

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
using Catalog.Application.Categories.Commands.CreateCategories;
using Catalog.Application.Categories.Commands.DeleteCategory;
using Catalog.Application.Categories.Commands.UpdateCategory;
using Catalog.Application.Categories.Queries.GetCategoryList;
using Catalog.Application.Categories.Queries.GetCategoryDetails;
using Catalog.Application.DTOs.RequestDtos.Categories;
using Catalog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create category
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/categories
        /// {
        ///     title: "CategoryTitle"
        /// }
        /// </remarks>
        /// <param name="categoryRequestDto">CreateCategoryRequestDto object</param>
        /// <returns>Category (CreateCategoryResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="400">The category failed to create</response>
        /// <response code="409">The category already exists</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryRequestDto categoryRequestDto, CancellationToken cancellationToken)
        {
            var command = new CreateCategoryCommand() { CreateCategoryRequestDto = categoryRequestDto };
            var categoryResponseDto = await _mediator.Send(command, cancellationToken);

            return Ok(categoryResponseDto);
        }

        /// <summary>
        /// Gets the list of category
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/categories/page?pageSize=2&pageCount=1
        /// </remarks>
        /// <param name="categoryRequestDto">GetCategoryRequestDto object</param>
        /// <returns>ListOfCategory (<IEnumerable<GetCategoryResponseDto>>)</returns>
        /// <response code="200">Success</response>
        [HttpPost("page")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPageAsync([FromQuery] int pageSize, [FromQuery] int pageCount, CancellationToken cancellationToken)
        {
            var command = new GetCategoryPageQuery() 
            { 
                PageSize = pageSize,
                PageCount = pageCount
            };
            var listOfCategory = await _mediator.Send(command, cancellationToken);

            return Ok(listOfCategory);
        }

        /// <summary>
        /// Gets the list of category
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/categories
        /// </remarks>
        /// <returns>ListOfCategory (<IEnumerable<GetCategoryResponseDto>>)</returns>
        /// <response code="200">Success</response>
        [HttpGet("categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var command = new GetCategoryListQuery();

            var listOfCategory = await _mediator.Send(command, cancellationToken);

            return Ok(listOfCategory);
        }

        /// <summary>
        /// Get the category by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/categories/7200f6a3-132c-46c9-8b9f-27b9b3c2d122
        /// </remarks>
        /// <param name="id">Guid object</param>
        /// <returns>Category (GetCategoryResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">The category was not found</response>
        [HttpGet("category/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var command = new GetCategoryDetailsQuery() { Id = id };
            var category = await _mediator.Send(command, cancellationToken);

            return Ok(category);
        }

        /// <summary>
        /// Change the category's title
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Patch /api/categories/27fbb7ae-297f-4403-80fb-0da3a0312198
        /// [
        ///     {
        ///         "operationType": 0,
        ///         "path": "Title",
        ///         "op": "replace",
        ///         "from": "string",
        ///         "value": "NewTitle"
        ///     }
        /// ]
        /// </remarks>
        /// <param name="jsonPatchCategoryDto">JsonPatchDocument<Category> object</param>
        /// <param name="id">Guid object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">Category failed to update</response>
        /// <response code="404">The category was not found</response>
        [HttpPatch("category/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> СhangeTitleAsync([FromBody] JsonPatchDocument<Category> jsonPatchCategoryDto, Guid id, CancellationToken cancellationToken)
        {
            var command = new UpdateCategoryCommand() { JsonPatchCategoryDto = jsonPatchCategoryDto, CategoryId = id };
            
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Delete the category
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /api/categories/7200f6a3-132c-46c9-8b9f-27b9b3c2d122
        /// </remarks>
        /// <param name="id">Guid object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">Category Failed to delete</response>
        /// <response code="404">The category was not found</response>
        [HttpDelete("category/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteCategoryCommand() { Id = id };

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
using Catalog.Application.DTOs.RequestDtos.Products;
using Catalog.Application.Products.Commands.CreateProduct;
using Catalog.Application.Products.Commands.DeleteProduct;
using Catalog.Application.Products.Commands.UpdateProduct.UpdateCategory;
using Catalog.Application.Products.Commands.UpdateProduct.UpdateManufacturer;
using Catalog.Application.Products.Commands.UpdateProduct.UpdateTitle;
using Catalog.Application.Products.Queries.GetProductDetails;
using Catalog.Application.Products.Queries.GetProductList;
using Catalog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create product
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/products
        /// {
        ///     title: "producTitle",
        ///     manufacturerId: "6e513972-8541-4563-01b3-08dc2bd840ff",
        ///     categoryId: "74c93f5c-3098-4165-b444-262986281df1"
        /// }
        /// </remarks>
        /// <param name="productRequestDto">CreateProductRequestDto object</param>
        /// <returns>productResponseDto (CreateProductResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="400">The product failed to create</response>
        /// <response code="409">The product already exists</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductRequestDto productRequestDto, CancellationToken cancellationToken)
        {
            var command = new CreateProductCommand() { CreateProtuctRequestDto = productRequestDto };
            var productResponseDto = await _mediator.Send(command, cancellationToken);

            return Ok(productResponseDto);
        }

        /// <summary>
        /// Gets the list of product
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Post /api/products/page?pageSize=2&pageCount=1
        /// </remarks>
        /// <param name="productRequestDto">GetProductRequestDto object</param>
        /// <returns>listOfProduct (<IEnumerable<GetProductResponseDto>>)</returns>
        /// <response code="200">Success</response>
        [HttpPost("page")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync([FromQuery] int pageSize, [FromQuery] int pageCount, CancellationToken cancellationToken)
        {
            var command = new GetProductListQueries()
            {
                PageSize = pageSize,
                PageCount = pageCount
            };
            var listOfProduct = await _mediator.Send(command, cancellationToken);

            return Ok(listOfProduct);
        }

        /// <summary>
        /// Get the product by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /api/products/7200f6a3-132c-46c9-8b9f-27b9b3c2d122
        /// </remarks>
        /// <param name="id">Guid object</param>
        /// <returns>product (GetProductResponseDto)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">The product was not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var command = new GetProductDetailsQueries() { Id = id };
            var product = await _mediator.Send(command, cancellationToken);

            return Ok(product);
        }

        /// <summary>
        /// Change the produrt's title
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Patch /api/products/title/7200f6a3-132c-46c9-8b9f-27b9b3c2d122
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
        /// <param name="jsonPatchProductDto">JsonPatchDocument<Product> object</param>
        /// <param name="id">Guid object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">Product failed to update</response>
        /// <response code="404">The product was not found</response>
        [HttpPatch("title/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> СhangeTitleAsync([FromBody] JsonPatchDocument<Product> jsonPatchProductDto, Guid id, CancellationToken cancellationToken)
        {
            var command = new UpdateProductTitleCommand() { JsonPatchProductDto = jsonPatchProductDto, ProductId = id };

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Change the produrt's category
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Patch /api/products/categories/7200f6a3-132c-46c9-8b9f-27b9b3c2d122
        /// [
        ///     {
        ///         "operationType": 0,
        ///         "path": "CategoryId",
        ///         "op": "replace",
        ///         "from": "string",
        ///         "value": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///     }
        /// ]
        /// </remarks>
        /// <param name="jsonPatchProductDto">JsonPatchDocument<Product> object</param>
        /// <param name="id">Guid object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">Product failed to update</response>
        /// <response code="404">The product or сategory was not found</response>
        [HttpPatch("categories/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> СhangeCategoryIdAsync([FromBody] JsonPatchDocument<Product> jsonPatchProductDto, Guid id, CancellationToken cancellationToken)
        {
            var command = new UpdateProductCategoryCommand() { JsonPatchProductDto = jsonPatchProductDto, ProductId = id };

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Change the produrt's manufacturer
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Patch /api/products/manufacturers/7200f6a3-132c-46c9-8b9f-27b9b3c2d122
        /// [
        ///     {
        ///         "operationType": 0,
        ///         "path": "ManufacturerId",
        ///         "op": "replace",
        ///         "from": "string",
        ///         "value": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///     }
        /// ]
        /// </remarks>
        /// <param name="jsonPatchProductDto">JsonPatchDocument<Product> object</param>
        /// <param name="id">Guid object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">Product failed to update</response>
        /// <response code="404">The product or manufacturer was not found</response>
        [HttpPatch("manufacturers/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> СhangeManufacturerIdAsync([FromBody] JsonPatchDocument<Product> jsonPatchProductDto, Guid id, CancellationToken cancellationToken)
        {
            var command = new UpdateProductManufacturerCommand() { JsonPatchProductDto = jsonPatchProductDto, ProductId = id };

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Delete the product
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /api/products/7200f6a3-132c-46c9-8b9f-27b9b3c2d122
        /// </remarks>
        /// <param name="id">Guid object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">Product Failed to delete</response>
        /// <response code="404">The product was not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteProductCommand() { Id = id };

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
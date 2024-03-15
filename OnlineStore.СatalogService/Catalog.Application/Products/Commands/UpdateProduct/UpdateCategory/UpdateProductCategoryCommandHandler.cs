using Catalog.Application.Exceptions.Categories;
using Catalog.Application.Exceptions.Products;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateCategory
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateProductCategoryCommandHandler(
            IProductRepository productRepository, 
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var foundProduct = await _productRepository.FindByIdAsync(request.ProductId, cancellationToken);

            if (foundProduct is null)
            {
                throw new ProductNotFoundException();
            }

            string guidString = request.JsonPatchProductDto.Operations.FirstOrDefault()?.value.ToString();

            if (!Guid.TryParse(guidString, out Guid parsedGuid))
            {
                throw new InvalidOperationException("The provided GUID is not valid.");
            }

            var foundCategory = await _categoryRepository.FindByIdAsync(parsedGuid, cancellationToken);

            if (foundCategory is null)
            {
                throw new CategoryNotFoundException();
            }

            var productChangeResult = await _productRepository.UpdateAsync(foundProduct, request.JsonPatchProductDto, cancellationToken);

            if (!productChangeResult.Succeeded)
            {
                throw new ProductUpdateException();
            }

            return Unit.Value;
        }
    }
}
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
            var productRequestDto = request.UptadeProductCategoryRequestDto;
            var foundProduct = await _productRepository.FindByIdAsync(productRequestDto.Id, cancellationToken);

            if (foundProduct is null)
            {
                throw new ProductNotFoundException();
            }

            var foundCategory = await _categoryRepository.FindByIdAsync(productRequestDto.NewCategoryId, cancellationToken);

            if (foundCategory is null)
            {
                throw new CategoryNotFoundException();
            }

            var productChangeResult = await _productRepository.ChangeCategoryIdAsync(foundProduct, productRequestDto.NewCategoryId, cancellationToken);

            if (!productChangeResult.Succeeded)
            {
                throw new ProductUpdateException();
            }

            return Unit.Value;
        }
    }
}
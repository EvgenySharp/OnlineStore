using Catalog.Application.Exceptions.Products;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateTitle
{
    public class UpdateProductTitleCommandHandler : IRequestHandler<UpdateProductTitleCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductTitleCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductTitleCommand request, CancellationToken cancellationToken)
        {
            var productRequestDto = request.UptadeProductTitleRequestDto;
            var foundProduct = await _productRepository.FindByIdAsync(productRequestDto.Id, cancellationToken);

            if (foundProduct is null)
            {
                throw new ProductNotFoundException();
            }

            var productChangeResult = await _productRepository.ChangeTitleAsync(foundProduct, productRequestDto.NewTiitle, cancellationToken);

            if (!productChangeResult.Succeeded)
            {
                throw new ProductUpdateException();
            }

            return Unit.Value;
        }
    }
}
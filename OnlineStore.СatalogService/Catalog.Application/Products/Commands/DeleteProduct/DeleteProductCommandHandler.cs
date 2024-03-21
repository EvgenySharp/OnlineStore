using Catalog.Application.Exceptions.Products;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var foundProduct = await _productRepository.FindByIdAsync(request.Id, cancellationToken);

            if (foundProduct is null)
            {
                throw new ProductNotFoundException();
            }

            var productDeleteResult = await _productRepository.DeleteAsync(foundProduct, cancellationToken);

            if (!productDeleteResult.Succeeded)
            {
                throw new ProductDeleteException();
            }

            return Unit.Value;
        }
    }
}
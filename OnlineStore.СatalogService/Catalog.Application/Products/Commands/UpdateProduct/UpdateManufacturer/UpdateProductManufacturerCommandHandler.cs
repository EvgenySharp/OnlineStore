using Catalog.Application.Exceptions.Manufacturers;
using Catalog.Application.Exceptions.Products;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateManufacturer
{
    public class UpdateProductManufacturerCommandHandler : IRequestHandler<UpdateProductManufacturerCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IManufacturerRepository _manufacturerRepository;

        public UpdateProductManufacturerCommandHandler(
            IProductRepository productRepository,
            IManufacturerRepository manufacturerRepository)
        {
            _productRepository = productRepository;
            _manufacturerRepository = manufacturerRepository;
        }

        public async Task<Unit> Handle(UpdateProductManufacturerCommand request, CancellationToken cancellationToken)
        {
            var productRequestDto = request.UptadeProductManufacturerRequestDto;
            var foundProduct = await _productRepository.FindByIdAsync(productRequestDto.Id, cancellationToken);

            if (foundProduct is null)
            {
                throw new ProductNotFoundException();
            }

            var foundManufacturer = await _manufacturerRepository.FindByIdAsync(productRequestDto.NewManufacturerId, cancellationToken);

            if (foundManufacturer is null)
            {
                throw new ManufacturerNotFoundException();
            }

            var productChangeResult = await _productRepository.ChangeManufacturerIdAsync(foundProduct, productRequestDto.NewManufacturerId, cancellationToken);

            if (!productChangeResult.Succeeded)
            {
                throw new ProductUpdateException();
            }

            return Unit.Value;
        }
    }
}
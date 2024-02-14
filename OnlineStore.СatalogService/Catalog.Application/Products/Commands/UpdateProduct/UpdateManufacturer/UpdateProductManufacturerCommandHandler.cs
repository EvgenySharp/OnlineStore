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

            var foundManufacturer = await _manufacturerRepository.FindByIdAsync(parsedGuid, cancellationToken);

            if (foundManufacturer is null)
            {
                throw new ManufacturerNotFoundException();
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
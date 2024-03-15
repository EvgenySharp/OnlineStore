using Catalog.Application.Exceptions.Manufacturers;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Manufacturers.Commands.DeleteManufacturer
{
    public class DeleteManufacturerCommandHandler : IRequestHandler<DeleteManufacturerCommand>
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public DeleteManufacturerCommandHandler(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public async Task<Unit> Handle(DeleteManufacturerCommand request, CancellationToken cancellationToken)
        {
            var foundManufacturer = await _manufacturerRepository.FindByIdAsync(request.Id, cancellationToken);

            if (foundManufacturer is null)
            {
                throw new ManufacturerNotFoundException();
            }

            var manufacturerDeleteResult = await _manufacturerRepository.DeleteAsync(foundManufacturer, cancellationToken);

            if (!manufacturerDeleteResult.Succeeded)
            {
                throw new ManufacturerDeleteException();
            }

            return Unit.Value;
        }
    }
}
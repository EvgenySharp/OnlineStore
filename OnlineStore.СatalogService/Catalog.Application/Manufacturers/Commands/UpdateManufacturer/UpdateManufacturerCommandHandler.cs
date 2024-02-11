using Catalog.Application.Exceptions.Manufacturers;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Manufacturers.Commands.UpdateBook
{
    public class UpdateManufacturerCommandHandler : IRequestHandler<UpdateManufacturerCommand>
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public UpdateManufacturerCommandHandler(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public async Task<Unit> Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var manufacturerRequestDto = request.uptadeManufacturerRequestDto;
            var foundManufacturer = await _manufacturerRepository.FindByIdAsync(manufacturerRequestDto.Id, cancellationToken);

            if (foundManufacturer is null)
            {
                throw new ManufacturerNotFoundException();
            }

            var manufacturerChangeResult = await _manufacturerRepository.ChangeTitleAsync(foundManufacturer, manufacturerRequestDto.NewTiitle, cancellationToken);

            if (!manufacturerChangeResult.Succeeded)
            {
                throw new ManufacturerUpdateException();
            }

            return Unit.Value;
        }
    }
}
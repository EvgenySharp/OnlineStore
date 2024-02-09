using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Manufacturers.Commands.UpdateBook
{
    public class UpdateManufacturerCommandHandlerL : IRequestHandler<UpdateManufacturerCommand>
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;

        public UpdateManufacturerCommandHandlerL(
            IManufacturerRepository manufacturerRepository,
            IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var foundManufacturer = await _manufacturerRepository.FindByTitleAsync(request.Title);

            if (foundManufacturer is null)
            {
                throw new ManufacturerNotFoundException();
            }

            var manufacturerChangeResult = await _manufacturerRepository.ChangeTitleAsync(foundManufacturer, request.Title);

            if (!manufacturerChangeResult.Succeeded)
            {
                throw new ManufacturerUpdateException();
            }

            return Unit.Value;
        }
    }
}
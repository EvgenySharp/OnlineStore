using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos;
using Catalog.Application.Exceptions;
using Catalog.Domain.Entities;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Manufacturers.Commands.CreateManufacturer
{
    public class CreateManufacturerCommandHandler: IRequestHandler<CreateManufacturerCommand, ManufacturerResponseDto>
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;

        public CreateManufacturerCommandHandler(
            IManufacturerRepository manufacturerRepository,
            IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;            
        }

        public async Task<ManufacturerResponseDto> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var foundManufacturer = await _manufacturerRepository.FindByTitleAsync(request.ManufacturerTitle);

            if (foundManufacturer is not null)
            {
                throw new ManufacturerAlreadyExistsException();
            }

            var newManufacturer = _mapper.Map<Manufacturer>(request);           
            var ManufacturerCreationResult = await _manufacturerRepository.CreateAsync(newManufacturer);

            if (!ManufacturerCreationResult.Succeeded)
            {
                throw new ManufacturerCreationException();
            }

            var manufacturerResponseDtos = _mapper.Map<ManufacturerResponseDto>(newManufacturer);

            return manufacturerResponseDtos;
        }
    }
}
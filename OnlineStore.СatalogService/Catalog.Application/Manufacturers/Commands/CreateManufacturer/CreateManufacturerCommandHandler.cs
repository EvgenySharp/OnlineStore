using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Manufacturers;
using Catalog.Application.Exceptions.Manufacturers;
using Catalog.Domain.Entities;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Manufacturers.Commands.CreateManufacturer
{
    public class CreateManufacturerCommandHandler: IRequestHandler<CreateManufacturerCommand, CreateManufacturerResponseDto>
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

        public async Task<CreateManufacturerResponseDto> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var manufacturerRequestDto = request.CreateManufacturerRequestDto;
            var foundManufacturer = await _manufacturerRepository.FindByTitleAsync(manufacturerRequestDto.Title, cancellationToken);

            if (foundManufacturer is not null)
            {
                throw new ManufacturerAlreadyExistsException();
            }

            var newManufacturer = _mapper.Map<Manufacturer>(manufacturerRequestDto);           
            var manufacturerCreationResult = await _manufacturerRepository.CreateAsync(newManufacturer, cancellationToken);

            if (!manufacturerCreationResult.Succeeded)
            {
                throw new ManufacturerCreationException();
            }

            var manufacturerResponseDtos = _mapper.Map<CreateManufacturerResponseDto>(newManufacturer);

            return manufacturerResponseDtos;
        }
    }
}
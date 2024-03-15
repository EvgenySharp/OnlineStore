using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Manufacturers;
using Catalog.Application.Exceptions.Manufacturers;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Manufacturers.Queries.GetManufacturerDetails
{
    public class GetManufacturerDetailsQueryHandler : IRequestHandler<GetManufacturerDetailsQuery, GetManufacturerResponseDto>
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;

        public GetManufacturerDetailsQueryHandler(
            IManufacturerRepository manufacturerRepository,
            IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        public async Task<GetManufacturerResponseDto> Handle(GetManufacturerDetailsQuery request, CancellationToken cancellationToken)
        {
            var foundManufacturer = await _manufacturerRepository.FindByIdAsync(request.Id, cancellationToken);

            if (foundManufacturer is null)
            {
                throw new ManufacturerNotFoundException();
            }

            var manufacturerResponseDto = _mapper.Map<GetManufacturerResponseDto>(foundManufacturer);

            return manufacturerResponseDto;
        }
    }
}
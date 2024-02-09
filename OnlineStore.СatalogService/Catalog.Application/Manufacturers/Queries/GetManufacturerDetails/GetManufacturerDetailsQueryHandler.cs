using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos;
using Catalog.Application.Exceptions;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR; 

namespace Catalog.Application.Manufacturers.Queries.GetManufacturerDetails
{
    public class GetManufacturerDetailsQueryHandler : IRequestHandler<GetManufacturerDetailsQuery, ManufacturerResponseDto>
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

        public async Task<ManufacturerResponseDto> Handle(GetManufacturerDetailsQuery request, CancellationToken cancellationToken)
        {
            var foundManufacturer = await _manufacturerRepository.FindByTitleAsync(request.Title);

            if (foundManufacturer is null)
            {
                throw new ManufacturerNotFoundException();
            }

            var manufacturerResponseDto = _mapper.Map<ManufacturerResponseDto>(foundManufacturer);

            return manufacturerResponseDto;
        }
    }
}
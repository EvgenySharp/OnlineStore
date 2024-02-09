using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Manufacturers.Queries.GetManufacturerList
{
    public class GetManufacturerListQueryHandler : IRequestHandler<GetManufacturerListQuery, IEnumerable<ManufacturerResponseDto>>
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;

        public GetManufacturerListQueryHandler(
            IManufacturerRepository manufacturerRepository,
            IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ManufacturerResponseDto>> Handle(GetManufacturerListQuery request, CancellationToken cancellationToken)
        {
            var manufacturerList = await _manufacturerRepository.GetAllAsync();
            var manufacturerResponseDtoList = _mapper.Map<List<ManufacturerResponseDto>>(manufacturerList);

            return manufacturerResponseDtoList;
        }
    }
}
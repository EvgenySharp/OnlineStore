using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Manufacturers;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Manufacturers.Queries.GetManufacturerList
{
    public class GetManufacturerPageQueryHandler : IRequestHandler<GetManufacturerPageQuery, IEnumerable<GetManufacturerResponseDto>>
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;

        public GetManufacturerPageQueryHandler(
            IManufacturerRepository manufacturerRepository,
            IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetManufacturerResponseDto>> Handle(GetManufacturerPageQuery request, CancellationToken cancellationToken)
        {
            var manufacturerList = await _manufacturerRepository.GetPageAsync(request.PageSize, request.PageCount, cancellationToken);
            var manufacturerResponseDtoList = _mapper.Map<List<GetManufacturerResponseDto>>(manufacturerList);

            return manufacturerResponseDtoList;
        }
    }
}
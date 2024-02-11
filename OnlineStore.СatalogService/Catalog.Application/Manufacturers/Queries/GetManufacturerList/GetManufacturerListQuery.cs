using Catalog.Application.DTOs.RequestDtos.Manufacturers;
using Catalog.Application.DTOs.ResponseDtos.Manufacturers;
using MediatR;

namespace Catalog.Application.Manufacturers.Queries.GetManufacturerList
{
    public class GetManufacturerListQuery : IRequest<IEnumerable<GetManufacturerResponseDto>>
    {
        public GetManufacturerRequestDto GetManufacturerRequestDto;
    }
}
using Catalog.Application.DTOs.ResponseDtos.Manufacturers;
using MediatR;

namespace Catalog.Application.Manufacturers.Queries.Get
{
    public class GetManufacturerListQuery : IRequest<IEnumerable<GetManufacturerResponseDto>>
    {
    }
}
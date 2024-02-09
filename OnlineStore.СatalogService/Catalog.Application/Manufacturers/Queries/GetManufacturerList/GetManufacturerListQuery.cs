using Catalog.Application.DTOs.ResponseDtos;
using MediatR;

namespace Catalog.Application.Manufacturers.Queries.GetManufacturerList
{
    public class GetManufacturerListQuery : IRequest<IEnumerable<ManufacturerResponseDto>>
    {
    }
}
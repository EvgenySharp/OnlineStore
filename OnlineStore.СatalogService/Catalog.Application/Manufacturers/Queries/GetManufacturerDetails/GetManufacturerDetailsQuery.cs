using Catalog.Application.DTOs.ResponseDtos.Manufacturers;
using MediatR;

namespace Catalog.Application.Manufacturers.Queries.GetManufacturerDetails
{
    public class GetManufacturerDetailsQuery : IRequest<GetManufacturerResponseDto>
    {
        public Guid Id { get; set; }
    }
}
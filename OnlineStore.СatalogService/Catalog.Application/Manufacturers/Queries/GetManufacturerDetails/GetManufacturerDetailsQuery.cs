using Catalog.Application.DTOs.ResponseDtos;
using MediatR;

namespace Catalog.Application.Manufacturers.Queries.GetManufacturerDetails
{
    public class GetManufacturerDetailsQuery : IRequest<ManufacturerResponseDto>
    {
        public string Title { get; set; }
    }
}
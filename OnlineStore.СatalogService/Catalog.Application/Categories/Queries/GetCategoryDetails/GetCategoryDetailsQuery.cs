using Catalog.Application.DTOs.ResponseDtos.Categories;
using MediatR;

namespace Catalog.Application.Categories.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQuery : IRequest<GetCategoryResponseDto>
    {
        public Guid Id { get; set; }
    }
}
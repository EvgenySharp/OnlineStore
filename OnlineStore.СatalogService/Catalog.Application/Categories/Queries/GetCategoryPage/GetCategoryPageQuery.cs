using Catalog.Application.DTOs.ResponseDtos.Categories;
using MediatR;

namespace Catalog.Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryPageQuery : IRequest<IEnumerable<GetCategoryResponseDto>>
    {
        public int PageCount { get; set; }
        public int PageSize { get; set; }
    }
}
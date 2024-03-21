using Catalog.Application.DTOs.ResponseDtos.Categories;
using MediatR;

namespace Catalog.Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<IEnumerable<GetCategoryResponseDto>>
    {
    }
}

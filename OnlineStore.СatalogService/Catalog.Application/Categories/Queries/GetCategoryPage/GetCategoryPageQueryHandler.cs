using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Categories;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryPageQueryHandler : IRequestHandler<GetCategoryPageQuery, IEnumerable<GetCategoryResponseDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryPageQueryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCategoryResponseDto>> Handle(GetCategoryPageQuery request, CancellationToken cancellationToken)
        {
            var categoryList = await _categoryRepository.GetPageAsync(request.PageSize, request.PageCount, cancellationToken);
            var categoryResponseDtoList = _mapper.Map<List<GetCategoryResponseDto>>(categoryList);

            return categoryResponseDtoList;
        }
    }
}
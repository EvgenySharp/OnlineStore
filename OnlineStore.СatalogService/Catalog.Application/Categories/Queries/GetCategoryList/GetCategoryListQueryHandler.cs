using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Categories;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, IEnumerable<GetCategoryResponseDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCategoryResponseDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categoryDto = request.GetCategoryRequestDto;
            var categoryList = await _categoryRepository.GetAllAsync(categoryDto.PageSize, categoryDto.PageCount, cancellationToken);
            var categoryResponseDtoList = _mapper.Map<List<GetCategoryResponseDto>>(categoryList);

            return categoryResponseDtoList;
        }
    }
}
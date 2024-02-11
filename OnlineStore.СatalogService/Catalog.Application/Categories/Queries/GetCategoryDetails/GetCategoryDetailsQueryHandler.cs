using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Categories;
using Catalog.Application.Exceptions.Categories;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Categories.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, GetCategoryResponseDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryDetailsQueryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetCategoryResponseDto> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var foundCategory = await _categoryRepository.FindByIdAsync(request.Id, cancellationToken);

            if (foundCategory is null)
            {
                throw new CategoryNotFoundException();
            }

            var categoryResponseDto = _mapper.Map<GetCategoryResponseDto>(foundCategory);

            return categoryResponseDto;
        }
    }
}
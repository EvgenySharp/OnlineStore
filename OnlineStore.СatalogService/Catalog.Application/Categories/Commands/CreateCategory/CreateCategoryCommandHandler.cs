using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Categories;
using Catalog.Application.Exceptions.Categories;
using Catalog.Domain.Entities;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Categories.Commands.CreateCategories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponseDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryResponseDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryRequestDto = request.CreateCategoryRequestDto;
            var foundCategory = await _categoryRepository.FindByTitleAsync(categoryRequestDto.Title, cancellationToken);

            if (foundCategory is not null)
            {
                throw new CategoryAlreadyExistsException();
            }

            var newCategory = _mapper.Map<Category>(categoryRequestDto);
            var categoryCreationResult = await _categoryRepository.CreateAsync(newCategory, cancellationToken);

            if (!categoryCreationResult.Succeeded)
            {
                throw new CategoryCreationException();
            }

            var categoryResponseDtos = _mapper.Map<CreateCategoryResponseDto>(newCategory);

            return categoryResponseDtos;
        }
    }
}